# Tesztelési Terv - Hernád-Véd Diszpécser Rendszer

## Teszt Stratégia

### Teszt Piramis

```
        /\
       /  \      E2E Tests (5%)
      /    \     - Teljes workflow tesztek
     /------\    
    /        \   Integration Tests (15%)
   /          \  - API integráció
  /            \ - Adatbázis kommunikáció
 /--------------\
/                \ Unit Tests (80%)
                   - ViewModel logika
                   - Service metódusok
                   - Model validáció
```

## Unit Tesztek

### LoginViewModel Tesztek

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HernadVed.ViewModels;

namespace HernadVed.Tests.ViewModels
{
    [TestClass]
    public class LoginViewModelTests
    {
        [TestMethod]
        public void CanLogin_WithEmptyEmail_ReturnsFalse()
        {
            // Arrange
            var viewModel = new LoginViewModel();
            viewModel.Email = "";
            viewModel.Password = "password123";

            // Act
            var result = viewModel.CanLogin();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CanLogin_WithEmptyPassword_ReturnsFalse()
        {
            // Arrange
            var viewModel = new LoginViewModel();
            viewModel.Email = "test@example.com";
            viewModel.Password = "";

            // Act
            var result = viewModel.CanLogin();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CanLogin_WithValidInputs_ReturnsTrue()
        {
            // Arrange
            var viewModel = new LoginViewModel();
            viewModel.Email = "test@example.com";
            viewModel.Password = "password123";
            viewModel.IsLoading = false;

            // Act
            var result = viewModel.CanLogin();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanLogin_WhenIsLoading_ReturnsFalse()
        {
            // Arrange
            var viewModel = new LoginViewModel();
            viewModel.Email = "test@example.com";
            viewModel.Password = "password123";
            viewModel.IsLoading = true;

            // Act
            var result = viewModel.CanLogin();

            // Assert
            Assert.IsFalse(result);
        }
    }
}
```

### User Model Tesztek

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HernadVed.Models;

namespace HernadVed.Tests.Models
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void IsAdmin_WithAdminEmail_ReturnsTrue()
        {
            // Arrange
            var user = new User
            {
                Email = "gal.miklos1976@gmail.com"
            };

            // Act
            var isAdmin = user.IsAdmin;

            // Assert
            Assert.IsTrue(isAdmin);
        }

        [TestMethod]
        public void IsAdmin_WithNonAdminEmail_ReturnsFalse()
        {
            // Arrange
            var user = new User
            {
                Email = "dispatcher@hernadved.hu"
            };

            // Act
            var isAdmin = user.IsAdmin;

            // Assert
            Assert.IsFalse(isAdmin);
        }

        [TestMethod]
        public void IsAdmin_WithDifferentCasing_ReturnsTrue()
        {
            // Arrange
            var user = new User
            {
                Email = "GAL.MIKLOS1976@GMAIL.COM"
            };

            // Act
            var isAdmin = user.IsAdmin;

            // Assert
            Assert.IsTrue(isAdmin);
        }
    }
}
```

### ApiService Tesztek (Moq használatával)

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using HernadVed.Services;
using HernadVed.Models;

namespace HernadVed.Tests.Services
{
    [TestClass]
    public class ApiServiceTests
    {
        [TestMethod]
        public async Task GetUserByEmailAsync_ValidEmail_ReturnsUser()
        {
            // Arrange
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(
                        "[{\"id\":1,\"email\":\"test@example.com\",\"password\":\"pass123\",\"role\":\"Dispatcher\",\"name\":\"Test User\"}]"
                    )
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri("https://api.hernadved.hu")
            };

            var apiService = new ApiService(httpClient);

            // Act
            var user = await apiService.GetUserByEmailAsync("test@example.com");

            // Assert
            Assert.IsNotNull(user);
            Assert.AreEqual("test@example.com", user.Email);
        }

        [TestMethod]
        public async Task AuthenticateUserAsync_ValidCredentials_ReturnsUser()
        {
            // Arrange
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(
                        "[{\"id\":1,\"email\":\"test@example.com\",\"password\":\"correct_password\",\"role\":\"Dispatcher\",\"name\":\"Test User\"}]"
                    )
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri("https://api.hernadved.hu")
            };

            var apiService = new ApiService(httpClient);

            // Act
            var user = await apiService.AuthenticateUserAsync("test@example.com", "correct_password");

            // Assert
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public async Task AuthenticateUserAsync_InvalidPassword_ReturnsNull()
        {
            // Arrange
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(
                        "[{\"id\":1,\"email\":\"test@example.com\",\"password\":\"correct_password\",\"role\":\"Dispatcher\",\"name\":\"Test User\"}]"
                    )
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri("https://api.hernadved.hu")
            };

            var apiService = new ApiService(httpClient);

            // Act
            var user = await apiService.AuthenticateUserAsync("test@example.com", "wrong_password");

            // Assert
            Assert.IsNull(user);
        }
    }
}
```

## Integration Tesztek

### API Integration Teszt

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HernadVed.Services;

namespace HernadVed.Tests.Integration
{
    [TestClass]
    public class ApiIntegrationTests
    {
        [TestMethod]
        [TestCategory("Integration")]
        public async Task GetUserByEmailAsync_RealAPI_ReturnsData()
        {
            // Arrange
            var apiService = new ApiService();

            // Act
            var user = await apiService.GetUserByEmailAsync("gal.miklos1976@gmail.com");

            // Assert
            Assert.IsNotNull(user);
        }
    }
}
```

## UI Tesztek (Manuális)

### Login Screen Test Cases

| Test ID | Teszt Leírás | Lépések | Várt Eredmény |
|---------|--------------|---------|---------------|
| UI-001 | Üres email bejelentkezés | 1. Email mező üresen hagyása<br>2. Jelszó kitöltése<br>3. Bejelentkezés gomb kattintás | Gomb inaktív/hibaüzenet |
| UI-002 | Üres jelszó bejelentkezés | 1. Email kitöltése<br>2. Jelszó mező üresen hagyása<br>3. Bejelentkezés gomb kattintás | Gomb inaktív/hibaüzenet |
| UI-003 | Sikeres admin bejelentkezés | 1. Email: gal.miklos1976@gmail.com<br>2. Jelszó: {valid}<br>3. Bejelentkezés | Admin főablak megnyílik |
| UI-004 | Sikeres dispatcher bejelentkezés | 1. Email: dispatcher@hernadved.hu<br>2. Jelszó: {valid}<br>3. Bejelentkezés | Dispatcher főablak megnyílik |
| UI-005 | Hibás jelszó | 1. Email: valid@email.com<br>2. Jelszó: wrong<br>3. Bejelentkezés | Hibaüzenet: "Helytelen email vagy jelszó!" |
| UI-006 | Loading indicator | 1. Email kitöltése<br>2. Jelszó kitöltése<br>3. Bejelentkezés gomb kattintás | Loading szöveg megjelenik |
| UI-007 | Kijelentkezés | 1. Bejelentkezés<br>2. Kijelentkezés gomb kattintás | Visszatérés login képernyőre |

### Main Window Test Cases

| Test ID | Teszt Leírás | Lépések | Várt Eredmény |
|---------|--------------|---------|---------------|
| MW-001 | Admin panel láthatóság | 1. Admin bejelentkezés | Admin panel látható, dispatcher panel rejtett |
| MW-002 | Dispatcher panel láthatóság | 1. Dispatcher bejelentkezés | Dispatcher panel látható, admin panel rejtett |
| MW-003 | Felhasználó név megjelenítés | 1. Bejelentkezés | Felhasználó neve/email megjelenik |
| MW-004 | Szerepkör megjelenítés | 1. Bejelentkezés | Szerepkör megjelenik (Admin/Dispatcher) |

## Performance Tesztek

### Válaszidő Tesztek

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using HernadVed.Services;

namespace HernadVed.Tests.Performance
{
    [TestClass]
    public class PerformanceTests
    {
        [TestMethod]
        [TestCategory("Performance")]
        public async Task ApiCall_CompletesInAcceptableTime()
        {
            // Arrange
            var apiService = new ApiService();
            var stopwatch = new Stopwatch();

            // Act
            stopwatch.Start();
            await apiService.GetUserByEmailAsync("test@example.com");
            stopwatch.Stop();

            // Assert
            Assert.IsTrue(stopwatch.ElapsedMilliseconds < 5000, 
                $"API call took {stopwatch.ElapsedMilliseconds}ms, expected < 5000ms");
        }
    }
}
```

## Teszt Lefedettség Cél

- **Unit Tests**: 80%+ kód lefedettség
- **Integration Tests**: Kritikus API endpoints
- **UI Tests**: Összes fő felhasználói flow

## CI/CD Pipeline

### GitHub Actions Workflow (javaslat)

```yaml
name: CI/CD

on:
  push:
    branches: [ main ]
  pull_request:
    branches: [ main ]

jobs:
  test:
    runs-on: windows-latest
    
    steps:
    - uses: actions/checkout@v2
    
    - name: Setup .NET
      uses: actions/setup-dotnet@v1
      with:
        dotnet-version: 8.0.x
        
    - name: Restore dependencies
      run: dotnet restore
      
    - name: Build
      run: dotnet build --no-restore
      
    - name: Test
      run: dotnet test --no-build --verbosity normal --collect:"XPlat Code Coverage"
      
    - name: Code Coverage Report
      uses: codecov/codecov-action@v2
```

## Teszt Adatok

### Test Users

```json
{
    "admin": {
        "email": "gal.miklos1976@gmail.com",
        "password": "admin_password",
        "role": "Admin"
    },
    "dispatcher": {
        "email": "dispatcher@hernadved.hu",
        "password": "dispatcher_password",
        "role": "Dispatcher"
    }
}
```

## Teszt Eszközök

- **MSTest** - Unit testing framework
- **Moq** - Mocking framework
- **FluentAssertions** - Assertion library
- **Coverlet** - Code coverage
- **ReportGenerator** - Coverage reports

## Test Project Setup

```bash
# Create test project
dotnet new mstest -n HernadVed.Tests

# Add references
dotnet add HernadVed.Tests reference HernadVed/HernadVed.csproj

# Add packages
dotnet add HernadVed.Tests package Moq
dotnet add HernadVed.Tests package FluentAssertions
dotnet add HernadVed.Tests package coverlet.collector

# Run tests
dotnet test
```

---

**Megjegyzés**: Ez a dokumentum egy részletes tesztelési terv. A tényleges tesztek implementálása a fejlesztési folyamat következő fázisában történik.
