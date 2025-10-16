# Hozzájárulási Útmutató

Köszönjük, hogy hozzá szeretne járulni a Hernád-Véd projekthez! Ez a dokumentum útmutatást nyújt a projekt fejlesztéséhez.

## 🤝 Hogyan Járulhatok Hozzá?

### Hibajelentés

Ha hibát talál az alkalmazásban:

1. Ellenőrizze, hogy a hiba már nincs-e bejelentve a [GitHub Issues](https://github.com/galmiklos1976-dot/Hernad-Ves/issues) oldalon
2. Hozzon létre egy új issue-t a következő információkkal:
   - Világos és leíró cím
   - Részletes leírás a hibáról
   - Lépések a hiba reprodukálásához
   - Várt eredmény vs. tényleges eredmény
   - Képernyőképek (ha releváns)
   - Környezeti információk (OS verzió, .NET verzió, stb.)

### Funkció Javaslat

Új funkció javaslat esetén:

1. Nyisson egy issue-t "Feature Request" címkével
2. Írja le részletesen a javasolt funkciót
3. Magyarázza el, miért lenne hasznos ez a funkció
4. Adjon példákat a felhasználási esetekre

### Pull Request

1. **Fork** a repository-t
2. **Clone** a saját fork-odat
3. Hozz létre egy új **branch**-et a változtatásaidhoz
4. Végezd el a változtatásokat
5. **Commit**-old a változtatásokat világos üzenetekkel
6. **Push**-old a branch-et a fork-odba
7. Nyiss egy **Pull Request**-et

## 📋 Pull Request Követelmények

### Kód Minőség

- ✅ Kövesse a C# kódolási konvenciókat
- ✅ Használja az MVVM pattern-t
- ✅ Írjon tiszta, olvasható kódot
- ✅ Adjon hozzá XML dokumentációs kommenteket a public metódusokhoz
- ✅ Tartsa egyszerűnek a függvényeket (Single Responsibility Principle)

### Tesztelés

- ✅ Írjon unit teszteket az új funkcionalitáshoz
- ✅ Győződjön meg róla, hogy az összes teszt sikeres
- ✅ Ellenőrizze, hogy nem törte-e el a meglévő funkcionalitást

### Dokumentáció

- ✅ Frissítse a README-t, ha szükséges
- ✅ Frissítse a CHANGELOG.md fájlt
- ✅ Adjon hozzá inline kommenteket komplex logikához
- ✅ Frissítse a felhasználói dokumentációt új funkciók esetén

### Commit Üzenetek

Használjon világos és leíró commit üzeneteket:

```
<type>: <subject>

<body>

<footer>
```

**Type-ok:**
- `feat`: Új funkció
- `fix`: Hibajavítás
- `docs`: Dokumentáció változtatás
- `style`: Kód formázás (nem változtatja a funkcionalitást)
- `refactor`: Kód refaktorálás
- `test`: Tesztek hozzáadása/módosítása
- `chore`: Build folyamat vagy segédeszközök változtatása

**Példák:**
```
feat: Add email validation to login form

Implemented comprehensive email validation using regex pattern.
Added error message display for invalid email formats.

Closes #123
```

```
fix: Correct admin role detection

Fixed case-sensitive email comparison in User.IsAdmin property.
Now properly handles email addresses with different casing.

Fixes #456
```

## 🏗️ Fejlesztési Munkafolyamat

### Branch Stratégia

```
main
  ├── develop
  │   ├── feature/login-validation
  │   ├── feature/dashboard
  │   └── bugfix/api-timeout
  └── hotfix/critical-security-issue
```

**Branch típusok:**
- `main`: Stabil, production-ready kód
- `develop`: Fejlesztési branch
- `feature/*`: Új funkciók
- `bugfix/*`: Hibajavítások
- `hotfix/*`: Sürgős javítások a main-re

### Fejlesztési Lépések

1. **Szinkronizálás**
   ```bash
   git checkout develop
   git pull origin develop
   ```

2. **Új Branch Létrehozása**
   ```bash
   git checkout -b feature/my-new-feature
   ```

3. **Fejlesztés**
   ```bash
   # Kód írás
   # Tesztelés
   # Commit-olás
   git add .
   git commit -m "feat: Add new feature"
   ```

4. **Push**
   ```bash
   git push origin feature/my-new-feature
   ```

5. **Pull Request**
   - Nyisson PR-t a `develop` branch-re
   - Töltse ki a PR template-et
   - Kérjen review-t

## 🎨 Kód Stílus

### C# Konvenciók

```csharp
// Classes: PascalCase
public class UserService { }

// Methods: PascalCase
public async Task<User> GetUserAsync() { }

// Properties: PascalCase
public string Email { get; set; }

// Private fields: _camelCase
private string _email;

// Parameters: camelCase
public void SendEmail(string emailAddress) { }

// Constants: PascalCase
private const string ApiBaseUrl = "https://api.hernadved.hu";

// Local variables: camelCase
var userList = new List<User>();
```

### XAML Konvenciók

```xml
<!-- Element names: PascalCase -->
<Button Content="Click Me" />

<!-- Property names: PascalCase -->
<TextBox Text="{Binding Email}" />

<!-- Resource keys: PascalCase -->
<SolidColorBrush x:Key="PrimaryBrush" Color="#2196F3" />
```

### Naming Guidelines

- **Kerülje**: Rövidítéseket (kivéve általánosan ismert: API, UI, ID)
- **Használjon**: Leíró neveket
- **Kerülje**: Magyar nyelvű változóneveket
- **Használjon**: Angol nyelvű kódot, magyar kommentekkel (opcionális)

## 🧪 Tesztelés

### Unit Tesztek Írása

```csharp
[TestClass]
public class LoginViewModelTests
{
    [TestMethod]
    public void TestMethod_Scenario_ExpectedBehavior()
    {
        // Arrange
        var viewModel = new LoginViewModel();
        
        // Act
        var result = viewModel.SomeMethod();
        
        // Assert
        Assert.IsTrue(result);
    }
}
```

### Tesztelési Checklist

- [ ] Unit tesztek írása új funkcionalitáshoz
- [ ] Integration tesztek kritikus komponensekhez
- [ ] Manuális UI tesztelés
- [ ] Edge case-ek tesztelése
- [ ] Performance tesztelés nagy adatmennyiség esetén

## 📦 Build és Deploy

### Local Build

```bash
dotnet restore
dotnet build
dotnet test
```

### Release Build

```bash
dotnet publish -c Release -r win-x64 --self-contained
```

## 🔍 Code Review Folyamat

### Reviewer Checklist

- [ ] Kód olvasható és érthető
- [ ] Követi a projekt konvencióit
- [ ] Nincs duplikált kód
- [ ] Hibakezelés megfelelő
- [ ] Tesztek léteznek és sikeresek
- [ ] Dokumentáció frissítve
- [ ] Nincs security issue
- [ ] Performance megfelelő

### Author Checklist (PR előtt)

- [ ] Kód self-review elvégezve
- [ ] Tesztek sikeresek
- [ ] Dokumentáció frissítve
- [ ] Commit-ok tiszták és logikusak
- [ ] Branch naprakész a target branch-csel
- [ ] CHANGELOG.md frissítve

## 📞 Kapcsolat

Ha kérdése van:
- Nyisson egy GitHub Discussion-t
- Írjon email-t: [projekt email]
- Vegye fel a kapcsolatot a maintainer-ekkel

## 📜 Licensz

A hozzájárulásával elfogadja, hogy a kódját ugyanazon licensz alatt teszi közzé, mint a projekt.

## 🙏 Köszönet

Köszönjük minden hozzájárulót, aki segít a Hernád-Véd projekt fejlesztésében!

---

© 2025 Hernád-Véd - Minden jog fenntartva
