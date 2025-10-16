# Hernád-Véd Gyors Kezdés

## 🚀 Gyors Telepítés

### 1. Előfeltételek Ellenőrzése

Telepítse a .NET 8.0 SDK-t:
- Töltse le: https://dotnet.microsoft.com/download/dotnet/8.0
- Windows 10 vagy újabb operációs rendszer szükséges

### 2. Projekt Klónozása

```bash
git clone https://github.com/galmiklos1976-dot/Hernad-Ves.git
cd Hernad-Ves
```

### 3. Projekt Build

```bash
cd HernadVed
dotnet restore
dotnet build
```

### 4. Alkalmazás Futtatása

```bash
dotnet run
```

VAGY nyissa meg Visual Studio-ban:
1. Dupla kattintás a `HernadVed.sln` fájlon
2. Nyomja meg az **F5** billentyűt

## 📋 Teszt Bejelentkezési Adatok

### Adminisztrátor
- **Email**: `gal.miklos1976@gmail.com`
- **Jelszó**: (Az API által validált jelszó)

### Diszpécser
- **Email**: Bármilyen más valid email
- **Jelszó**: (Az API által validált jelszó)

## 🎯 Főbb Funkciók

### ✅ Bejelentkezés
1. Indítsa el az alkalmazást
2. Írja be az email címét és jelszavát
3. Kattintson a **Bejelentkezés** gombra

### ✅ Admin Funkciók (gal.miklos1976@gmail.com)
- Felhasználók kezelése
- Rendszer beállítások
- Riasztások áttekintése

### ✅ Diszpécser Funkciók
- Aktuális riasztások
- Eseménynapló
- Jelentések

### ✅ Kijelentkezés
- Kattintson a **Kijelentkezés** gombra a jobb felső sarokban

## 📁 Projekt Struktúra

```
Hernad-Ves/
├── HernadVed/                          # Fő alkalmazás
│   ├── Models/                         # Adatmodellek
│   ├── ViewModels/                     # MVVM ViewModels
│   ├── Views/                          # XAML felületek
│   ├── Services/                       # API szolgáltatások
│   └── Converters/                     # UI konverterek
├── HernadVed.sln                       # Visual Studio solution
├── README.md                           # Projekt README
├── FELHASZNÁLÓI_ÚTMUTATÓ.md           # Felhasználói dokumentáció
├── FEJLESZTŐI_DOKUMENTÁCIÓ.md         # Fejlesztői dokumentáció
└── TESZTELÉSI_TERV.md                 # Tesztelési terv
```

## 🔧 Fejlesztői Mód

### Hot Reload (Visual Studio 2022)
1. Indítsa el az alkalmazást Debug módban (F5)
2. Módosítsa a XAML fájlokat
3. A változások automatikusan alkalmazásra kerülnek

### Debug Mód
```bash
dotnet run --configuration Debug
```

### Release Build
```bash
dotnet publish -c Release -r win-x64 --self-contained
```

Output mappa: `bin/Release/net8.0-windows/win-x64/publish/`

## 🐛 Hibakeresés

### "Could not load file or assembly"
```bash
dotnet clean
dotnet restore
dotnet build
```

### API Connection Error
- Ellenőrizze az internet kapcsolatot
- Ellenőrizze, hogy az API elérhető-e: `https://api.hernadved.hu`

### Build Error
- Győződjön meg róla, hogy .NET 8.0 SDK telepítve van:
```bash
dotnet --version
```

## 📚 További Dokumentáció

- **Felhasználói útmutató**: [FELHASZNÁLÓI_ÚTMUTATÓ.md](FELHASZNÁLÓI_ÚTMUTATÓ.md)
- **Fejlesztői dokumentáció**: [FEJLESZTŐI_DOKUMENTÁCIÓ.md](FEJLESZTŐI_DOKUMENTÁCIÓ.md)
- **Tesztelési terv**: [TESZTELÉSI_TERV.md](TESZTELÉSI_TERV.md)

## 🎨 Képernyőképek

### Login Képernyő
- Modern, tiszta design
- Email és jelszó mezők
- Hibaüzenetek megjelenítése
- Betöltési indikátor

### Főablak - Admin
- Teljes körű adminisztrátori funkciók
- Felhasználó információk
- Kijelentkezés lehetőség

### Főablak - Diszpécser
- Diszpécser specifikus funkciók
- Eseménynapló hozzáférés
- Jelentés készítés

## 💡 Tippek

1. **Első futtatás**: Az első build hosszabb időt vehet igénybe (NuGet package-ek letöltése)
2. **Visual Studio**: Használjon Visual Studio 2022-t a legjobb fejlesztői élményért
3. **XAML Preview**: A XAML Designer segít a UI tervezésében
4. **Hot Reload**: Használja a hot reload funkciót a gyorsabb fejlesztéshez

## ⚡ Gyors Parancsok

```bash
# Build
dotnet build

# Run
dotnet run

# Clean
dotnet clean

# Restore packages
dotnet restore

# Release build
dotnet publish -c Release
```

## 🆘 Támogatás

Problémák esetén:
1. Ellenőrizze a dokumentációt
2. Nézze meg a [GitHub Issues](https://github.com/galmiklos1976-dot/Hernad-Ves/issues) oldalt
3. Hozzon létre új issue-t részletes leírással

## 📝 Licensz

© 2025 Hernád-Véd - Minden jog fenntartva

---

**Verzió**: 1.0.0  
**Utolsó frissítés**: 2025-10-16  
**Platform**: Windows 10/11  
**Framework**: .NET 8.0
