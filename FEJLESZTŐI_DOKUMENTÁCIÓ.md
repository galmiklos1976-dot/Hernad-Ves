# Hernád-Véd Diszpécser Rendszer - Fejlesztői Dokumentáció

## Projekt Áttekintés

A Hernád-Véd egy modern C# WPF alkalmazás, amely .NET 8.0-t használ és Windows 10/11 platformon fut.

## Architektúra

### MVVM (Model-View-ViewModel) Pattern

Az alkalmazás az MVVM design pattern-t követi, amely tiszta szétválasztást biztosít a UI és az üzleti logika között.

```
┌─────────────────────────────────────────────────────────────┐
│                         View Layer                          │
│  ┌──────────────────────┐  ┌──────────────────────┐       │
│  │   LoginWindow.xaml   │  │   MainWindow.xaml    │       │
│  └──────────────────────┘  └──────────────────────┘       │
└─────────────────────────────────────────────────────────────┘
                            ▲
                            │ Data Binding
                            │ Commands
                            ▼
┌─────────────────────────────────────────────────────────────┐
│                      ViewModel Layer                        │
│  ┌──────────────────────┐  ┌──────────────────────┐       │
│  │   LoginViewModel     │  │   ViewModelBase      │       │
│  │   RelayCommand       │  │                      │       │
│  └──────────────────────┘  └──────────────────────┘       │
└─────────────────────────────────────────────────────────────┘
                            ▲
                            │
                            ▼
┌─────────────────────────────────────────────────────────────┐
│                       Model Layer                           │
│  ┌──────────────────────┐  ┌──────────────────────┐       │
│  │       User           │  │    ApiService        │       │
│  └──────────────────────┘  └──────────────────────┘       │
└─────────────────────────────────────────────────────────────┘
```

## Komponensek Részletesen

### Models

#### User.cs
```csharp
public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public string Name { get; set; }
    public bool IsAdmin => Email.Equals("gal.miklos1976@gmail.com", ...);
}
```

**Felelősség**: Felhasználói adatok tárolása és admin ellenőrzés

### ViewModels

#### ViewModelBase.cs
- **INotifyPropertyChanged** implementáció
- Property change notification
- Base osztály minden ViewModel-hez

#### RelayCommand.cs
- **ICommand** implementáció
- Command pattern WPF-hez
- CanExecute és Execute logika

#### LoginViewModel.cs
```csharp
public class LoginViewModel : ViewModelBase
{
    // Properties
    public string Email { get; set; }
    public string Password { get; set; }
    public string ErrorMessage { get; set; }
    public bool IsLoading { get; set; }
    
    // Commands
    public ICommand LoginCommand { get; }
    
    // Methods
    private async Task LoginAsync()
    private bool CanLogin()
}
```

**Felelősség**:
- Bejelentkezési logika
- Input validáció
- API kommunikáció koordináció
- Navigáció a főablakhoz

### Views

#### LoginWindow.xaml
```xml
<Window>
    <Grid>
        <TextBox Text="{Binding Email}" />
        <PasswordBox PasswordChanged="PasswordBox_PasswordChanged" />
        <Button Command="{Binding LoginCommand}" />
    </Grid>
</Window>
```

**Jellemzők**:
- Data binding az Email-hez
- Event handler a jelszó változáshoz
- Command binding a bejelentkezéshez

#### MainWindow.xaml
```xml
<Window>
    <Grid>
        <Border x:Name="AdminPanel" Visibility="..." />
        <Border x:Name="DispatcherPanel" Visibility="..." />
    </Grid>
</Window>
```

**Jellemzők**:
- Szerepkör-alapú UI megjelenítés
- Felhasználói információk
- Funkcionális gombok

### Services

#### ApiService.cs
```csharp
public class ApiService
{
    private readonly HttpClient _httpClient;
    
    public async Task<User?> GetUserByEmailAsync(string email)
    public async Task<User?> AuthenticateUserAsync(string email, string password)
}
```

**Felelősség**:
- HTTP kommunikáció az API-val
- JSON deszerializáció
- Hibakezelés

### Converters

#### BoolToVisibilityConverter
- Bool értékek konvertálása Visibility-re

#### InverseBoolConverter
- Bool értékek invertálása

#### StringToVisibilityConverter
- String értékek konvertálása Visibility-re

## API Integráció

### Endpoint Specifikáció

```
GET https://api.hernadved.hu/users?email={email}
```

**Request**:
- Method: GET
- Query Parameter: email (string)

**Response** (Példa):
```json
[
    {
        "id": 1,
        "email": "gal.miklos1976@gmail.com",
        "password": "hashed_password",
        "role": "Admin",
        "name": "Gál Miklós"
    }
]
```

### Autentikáció Flow

1. Felhasználó megadja az email-t és jelszót
2. `ApiService.AuthenticateUserAsync()` hívás
3. `GetUserByEmailAsync()` lekéri a felhasználót az API-ról
4. Jelszó összehasonlítás
5. Sikeres esetén User objektum visszaadása
6. LoginViewModel navigál a MainWindow-ra

## Biztonsági Megfontolások

### Jelenlegi Implementáció

- ✅ Jelszó rejtve a UI-ban (PasswordBox)
- ✅ HTTPS kommunikáció az API-val
- ✅ Szerepkör-alapú UI
- ✅ Admin email whitelist

### Továbbfejlesztési Javaslatok

- 🔄 Jelszó hash-elés
- 🔄 Token-alapú autentikáció (JWT)
- 🔄 Session timeout
- 🔄 Brute force védelem
- 🔄 Audit logging

## Adatfolyam

### Bejelentkezési Folyamat

```
User Input (Email + Password)
    ↓
LoginViewModel.LoginCommand.Execute()
    ↓
LoginViewModel.LoginAsync()
    ↓
ApiService.AuthenticateUserAsync()
    ↓
HttpClient.GetAsync("/users?email=...")
    ↓
JSON Response Parsing
    ↓
Password Validation
    ↓
User Object Creation
    ↓
Role Assignment (IsAdmin check)
    ↓
MainWindow.Show(user)
    ↓
LoginWindow.Close()
```

## Függőségek

### NuGet Packages

```xml
<PackageReference Include="Newtonsoft.Json" Version="13.0.3" />
```

### Framework References

- **System.Net.Http** - HTTP kommunikáció
- **System.Windows** - WPF
- **System.ComponentModel** - INotifyPropertyChanged

## Build és Deploy

### Fejlesztői Build

```bash
cd HernadVed
dotnet restore
dotnet build
```

### Release Build

```bash
dotnet publish -c Release -r win-x64 --self-contained true
```

**Output**: `bin/Release/net8.0-windows/win-x64/publish/`

### Visual Studio

1. Nyissa meg a `HernadVed.sln` fájlt
2. Set build configuration: Release
3. Build → Build Solution
4. Build → Publish HernadVed

## Tesztelés

### Unit Testing (Javaslat)

```csharp
[TestClass]
public class LoginViewModelTests
{
    [TestMethod]
    public void CanLogin_WithValidInputs_ReturnsTrue()
    {
        var viewModel = new LoginViewModel();
        viewModel.Email = "test@example.com";
        viewModel.Password = "password123";
        
        Assert.IsTrue(viewModel.CanLogin());
    }
}
```

### Manuális Tesztelés

1. **Login sikeres** - valid email/jelszó
2. **Login sikertelen** - invalid email/jelszó
3. **Admin role** - gal.miklos1976@gmail.com
4. **Dispatcher role** - más email
5. **Kijelentkezés** - visszatérés login-hoz
6. **API hiba kezelés** - invalid API response

## Hibaelhárítás

### Gyakori Problémák

#### "The project targets 'net8.0-windows' but the current SDK only supports up to 'net7.0'"

**Megoldás**: .NET 8 SDK telepítése vagy TargetFramework módosítása

#### "API connection failed"

**Megoldás**:
- Ellenőrizze az internet kapcsolatot
- Ellenőrizze az API elérhetőségét
- Ellenőrizze a tűzfal beállításokat

#### "Could not load file or assembly"

**Megoldás**:
```bash
dotnet restore
dotnet clean
dotnet build
```

## Kód Konvenciók

### Naming

- **Classes**: PascalCase
- **Methods**: PascalCase
- **Properties**: PascalCase
- **Private fields**: _camelCase
- **Parameters**: camelCase

### File Organization

```
HernadVed/
├── Models/          # Domain models
├── ViewModels/      # MVVM ViewModels
├── Views/           # XAML views
├── Services/        # Business services
├── Converters/      # Value converters
└── App.xaml         # Application resources
```

## Performance Optimizáció

### Javaslatok

1. **Async/Await használata** - UI thread nem blokkolódik
2. **Lazy Loading** - csak szükséges adatok betöltése
3. **Caching** - API válaszok cache-elése
4. **Virtual Scrolling** - nagy listák esetén

## Továbbfejlesztési Lehetőségek

### Funkcionális

- [ ] Felhasználó regisztráció
- [ ] Jelszó visszaállítás
- [ ] Multi-language támogatás
- [ ] Offline mód
- [ ] Real-time értesítések

### Technikai

- [ ] Dependency Injection
- [ ] Unit tesztek
- [ ] Integration tesztek
- [ ] Logging framework (Serilog)
- [ ] Configuration management

## Verziókezelés

### Git Workflow

```bash
# Feature branch
git checkout -b feature/new-feature

# Development
git add .
git commit -m "Add new feature"

# Push
git push origin feature/new-feature

# Pull Request
```

## License

© 2025 Hernád-Véd - Minden jog fenntartva

---

**Utolsó frissítés**: 2025-10-16
**Verzió**: 1.0.0
**Szerző**: GitHub Copilot
