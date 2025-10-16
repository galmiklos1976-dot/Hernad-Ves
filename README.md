# Hernád-Véd Diszpécser Rendszer

Windows asztali C# WPF (.NET 8) alkalmazás a Hernád-Véd diszpécser rendszer számára.

## Funkciók

### ✅ Login képernyő
- Email és jelszó mezők
- Admin/Dispatcher szerepkör kezelése
- Adminisztrátori jogosultság: csak a `gal.miklos1976@gmail.com` emaillel lehet adminként belépni
- Bejelentkezés Web API GET `/users` endpoint segítségével (`https://api.hernadved.hu/users?email=`)

### Felhasználói szerepkörök
- **Admin**: Teljes hozzáférés a rendszer összes funkciójához
- **Dispatcher**: Hozzáférés a diszpécser funkciókhoz

## Technológiák

- **.NET 8.0** (Windows)
- **WPF (Windows Presentation Foundation)**
- **MVVM (Model-View-ViewModel)** architektúra
- **Newtonsoft.Json** - JSON szerializáció/deszerializáció
- **HttpClient** - Web API kommunikáció

## Projekt struktúra

```
HernadVed/
├── Models/
│   └── User.cs                    # Felhasználói modell
├── ViewModels/
│   ├── ViewModelBase.cs          # Alap ViewModel osztály
│   ├── RelayCommand.cs           # Command pattern implementáció
│   └── LoginViewModel.cs         # Login ViewModel
├── Views/
│   ├── LoginWindow.xaml          # Login ablak
│   ├── LoginWindow.xaml.cs       # Login code-behind
│   ├── MainWindow.xaml           # Főablak
│   └── MainWindow.xaml.cs        # Főablak code-behind
├── Services/
│   └── ApiService.cs             # Web API kommunikáció
├── Converters/
│   └── Converters.cs             # XAML konverterek
├── App.xaml                      # Alkalmazás erőforrások
└── App.xaml.cs                   # Alkalmazás belépési pont
```

## Telepítés és futtatás

### Előfeltételek
- Windows 10/11 operációs rendszer
- .NET 8.0 SDK vagy újabb

### Build

```bash
cd HernadVed
dotnet restore
dotnet build
```

### Futtatás

```bash
dotnet run
```

Vagy Visual Studio-ban: nyissa meg a projektet és nyomja meg az F5 billentyűt.

## API Integráció

Az alkalmazás a következő API endpointot használja:

- **GET** `https://api.hernadved.hu/users?email={email}`
  - Felhasználó lekérése email cím alapján
  - Válasz: User objektum lista

## Bejelentkezés

1. Indítsa el az alkalmazást
2. Adja meg az email címét
3. Adja meg a jelszavát
4. Kattintson a "Bejelentkezés" gombra
5. Sikeres bejelentkezés után megjelenik a főablak a megfelelő szerepkör szerint

### Adminisztrátori belépés
- Email: `gal.miklos1976@gmail.com`
- Jelszó: az API által validált jelszó

## Képernyők

### Login ablak
- Email mező
- Jelszó mező
- Bejelentkezés gomb
- Hibaüzenetek megjelenítése
- Betöltés jelző

### Főablak (Admin)
- Felhasználó információk megjelenítése
- Adminisztrátori funkciók panel:
  - Felhasználók kezelése
  - Rendszer beállítások
  - Riasztások áttekintése
- Kijelentkezés funkció

### Főablak (Dispatcher)
- Felhasználó információk megjelenítése
- Diszpécser funkciók panel:
  - Aktuális riasztások
  - Eseménynapló
  - Jelentések
- Kijelentkezés funkció

## Biztonsági funkciók

- Jelszó mező: `PasswordBox` vezérlő használata (jelszó nem látható)
- Admin jogosultság ellenőrzés
- API kommunikáció hibakezelés
- Input validáció

## Fejlesztés

### MVVM Pattern
Az alkalmazás az MVVM (Model-View-ViewModel) mintát követi:
- **Model**: Üzleti logika és adatok (`User`)
- **View**: XAML fájlok (UI)
- **ViewModel**: Adatkötés és parancsok (`LoginViewModel`)

### Adatkötés
- Two-way binding az input mezőkhöz
- Command binding a gombok akcióihoz
- Konverterek a UI állapotokhoz

## Licence

© 2025 Hernád-Véd - Minden jog fenntartva
