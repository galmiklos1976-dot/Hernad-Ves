# Changelog

Az összes jelentős változás ezen a projekten ebben a fájlban van dokumentálva.

A formátum a [Keep a Changelog](https://keepachangelog.com/en/1.0.0/) alapján készült,
és a projekt a [Semantic Versioning](https://semver.org/spec/v2.0.0.html) verziószámozást követi.

## [1.0.0] - 2025-10-16

### Hozzáadva
- 🎉 Kezdeti kiadás
- ✨ Login képernyő email és jelszó mezőkkel
- ✨ Admin/Dispatcher szerepkör kezelés
- ✨ Adminisztrátori jogosultság ellenőrzés (gal.miklos1976@gmail.com)
- ✨ Web API integráció (GET /users endpoint)
- ✨ MVVM architektúra implementáció
- ✨ ViewModelBase alap osztály INotifyPropertyChanged-del
- ✨ RelayCommand implementáció
- ✨ LoginViewModel teljes funkcionalitással
- ✨ User model IsAdmin tulajdonsággal
- ✨ ApiService HTTP kommunikációhoz
- ✨ LoginWindow XAML felület
- ✨ MainWindow szerepkör-alapú UI-val
- ✨ Admin panel funkciókkal
- ✨ Dispatcher panel funkciókkal
- ✨ Value converters (BoolToVisibility, InverseBool, StringToVisibility)
- ✨ Stílusos alkalmazás design
- ✨ Hibaüzenetek megjelenítése
- ✨ Loading indikátor
- ✨ Kijelentkezés funkció
- 📚 Komplex dokumentáció (Magyar nyelven)
- 📚 README.md részletes leírással
- 📚 Felhasználói útmutató
- 📚 Fejlesztői dokumentáció
- 📚 Tesztelési terv
- 📚 Gyors kezdés útmutató
- 🔧 .gitignore konfiguráció
- 🔧 Visual Studio solution file
- 🔧 .NET 8.0 Windows WPF projekt
- 🔧 Newtonsoft.Json NuGet package

### Technikai Specifikáció
- **Framework**: .NET 8.0 (Windows)
- **UI Framework**: WPF (Windows Presentation Foundation)
- **Architektúra**: MVVM (Model-View-ViewModel)
- **HTTP Client**: System.Net.Http
- **JSON Serialization**: Newtonsoft.Json 13.0.3
- **Nyelv**: C# 11
- **Platform**: Windows 10/11

### API Integráció
- **Base URL**: https://api.hernadved.hu
- **Endpoint**: GET /users?email={email}
- **Response Format**: JSON Array[User]

### Biztonsági Funkciók
- Jelszó rejtés (PasswordBox)
- HTTPS API kommunikáció
- Szerepkör-alapú hozzáférés ellenőrzés
- Admin email whitelist

### Ismert Korlátozások
- Az alkalmazás csak Windows platformon futtatható (WPF követelmény)
- API hívások szinkron módon validálnak (nincs offline mód)
- Jelszó plain text-ben van tárolva az API válaszban (biztonsági fejlesztés szükséges)

### Fejlesztői Jegyzetek
- Build sikeres Linux környezetben EnableWindowsTargeting flag-gel
- Unit tesztek még nem implementáltak (tesztelési terv kész)
- UI tesztelés Windows környezetben szükséges

## [Tervezett - 1.1.0]

### Tervezve
- 🔐 Token-alapú autentikáció (JWT)
- 🔐 Jelszó hash-elés
- 💾 Session management
- 🌐 Offline mód alapvető funkciókkal
- 📊 Dashboard riasztásokkal
- 📋 Eseménynapló implementáció
- 📈 Jelentés generálás
- 👥 Felhasználó kezelés (CRUD)
- ⚙️ Rendszer beállítások panel
- 🔔 Real-time értesítések (SignalR)
- 🌍 Multi-language támogatás (Magyar/Angol)
- 🧪 Unit tesztek
- 🧪 Integration tesztek
- 📱 Responsive design fejlesztések
- 🎨 Dark mode téma

## [Tervezett - 1.2.0]

### Tervezve
- 📊 Fejlett analitika
- 📈 Trend vizualizáció
- 🗺️ Térkép integráció
- 📷 Kamera stream megtekintés
- 🔍 Keresés és szűrés fejlesztések
- 💾 Local cache implementáció
- 🔄 Auto-update funkció
- 📝 Audit log
- 📧 Email értesítések
- 📱 Mobile companion app integráció

## Verzió Történet

### Semantic Versioning Formátum
```
MAJOR.MINOR.PATCH
  │     │     │
  │     │     └─── Bug fix, apró változás
  │     └───────── Új funkció, backward compatible
  └─────────────── Breaking change, API változás
```

### Kiadási Jegyzetek
- **1.0.0** (2025-10-16): Kezdeti stabil kiadás alapvető funkciókkal

---

## Hozzájárulás

A változtatások dokumentálásához kérjük kövesse ezt a formátumot:
- **Hozzáadva** - Új funkcionalitás
- **Változtatva** - Meglévő funkcionalitás módosítása
- **Deprecated** - Hamarosan eltávolítandó funkciók
- **Eltávolítva** - Eltávolított funkciók
- **Javítva** - Bármilyen bug fix
- **Biztonság** - Biztonsági javítások

## Támogatott Verziók

| Verzió | Támogatott | Kiadás Dátuma | Támogatás Vége |
|--------|-----------|---------------|----------------|
| 1.0.x  | ✅ Igen   | 2025-10-16    | TBD            |

---

**Megjegyzés**: Ez egy élő dokumentum, amely minden kiadással frissül.

© 2025 Hernád-Véd - Minden jog fenntartva
