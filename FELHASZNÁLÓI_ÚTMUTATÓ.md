# Hernád-Véd Diszpécser Rendszer - Felhasználói Útmutató

## Alkalmazás Áttekintése

A Hernád-Véd egy modern Windows asztali alkalmazás, amely a Hernád folyó védelmi rendszerének diszpécser funkcióit valósítja meg.

## Főbb Funkciók

### 1. Bejelentkezési Képernyő

A bejelentkezési képernyő a következő elemeket tartalmazza:

```
╔═══════════════════════════════════════════════╗
║              Hernád-Véd                       ║
║           Diszpécser Rendszer                 ║
╠═══════════════════════════════════════════════╣
║                                               ║
║  Email cím:                                   ║
║  [____________________________________]       ║
║                                               ║
║  Jelszó:                                      ║
║  [••••••••••••••••••••••••••••••••]          ║
║                                               ║
║  [!] Helytelen email vagy jelszó!            ║
║                                               ║
║          [ Bejelentkezés ]                    ║
║                                               ║
║     Bejelentkezés folyamatban...             ║
║                                               ║
╚═══════════════════════════════════════════════╝
```

**Funkciók:**
- Email cím megadása
- Jelszó biztonságos megadása (rejtett karakterek)
- Hibaüzenetek megjelenítése
- Betöltési állapot jelzése

### 2. Főablak - Adminisztrátor Nézet

Adminisztrátori jogosultsággal (gal.miklos1976@gmail.com) való belépés után:

```
╔═══════════════════════════════════════════════════════════════════╗
║ Hernád-Véd Diszpécser Rendszer    gal.miklos1976@gmail.com      ║
║                                    Szerepkör: Admin [Kijelentkezés]║
╠═══════════════════════════════════════════════════════════════════╣
║                                                                   ║
║        Üdvözöljük a Hernád-Véd rendszerben!                     ║
║                                                                   ║
║    Ön adminisztrátorként jelentkezett be. Teljes                 ║
║    hozzáféréssel rendelkezik a rendszer összes                   ║
║    funkciójához.                                                 ║
║                                                                   ║
║   ┌──────────────────────────────────────────────┐              ║
║   │    Adminisztrátori Funkciók                  │              ║
║   ├──────────────────────────────────────────────┤              ║
║   │  [ Felhasználók kezelése            ]        │              ║
║   │  [ Rendszer beállítások             ]        │              ║
║   │  [ Riasztások áttekintése           ]        │              ║
║   └──────────────────────────────────────────────┘              ║
║                                                                   ║
╠═══════════════════════════════════════════════════════════════════╣
║         © 2025 Hernád-Véd - Minden jog fenntartva               ║
╚═══════════════════════════════════════════════════════════════════╝
```

**Admin Funkciók:**
- Felhasználók kezelése
- Rendszer beállítások
- Riasztások áttekintése

### 3. Főablak - Diszpécser Nézet

Diszpécser jogosultsággal való belépés után:

```
╔═══════════════════════════════════════════════════════════════════╗
║ Hernád-Véd Diszpécser Rendszer    dispatcher@hernadved.hu       ║
║                                    Szerepkör: Dispatcher [Kijelentkezés]║
╠═══════════════════════════════════════════════════════════════════╣
║                                                                   ║
║        Üdvözöljük a Hernád-Véd rendszerben!                     ║
║                                                                   ║
║    Ön diszpécserként jelentkezett be. Hozzáférése van           ║
║    a diszpécser funkciókhoz.                                     ║
║                                                                   ║
║   ┌──────────────────────────────────────────────┐              ║
║   │    Diszpécser Funkciók                       │              ║
║   ├──────────────────────────────────────────────┤              ║
║   │  [ Aktuális riasztások          ]            │              ║
║   │  [ Eseménynapló                 ]            │              ║
║   │  [ Jelentések                   ]            │              ║
║   └──────────────────────────────────────────────┘              ║
║                                                                   ║
╠═══════════════════════════════════════════════════════════════════╣
║         © 2025 Hernád-Véd - Minden jog fenntartva               ║
╚═══════════════════════════════════════════════════════════════════╝
```

**Diszpécser Funkciók:**
- Aktuális riasztások kezelése
- Eseménynapló megtekintése
- Jelentések készítése

## Használati Útmutató

### Bejelentkezés folyamata

1. **Indítás**: Az alkalmazás elindítása után megjelenik a bejelentkezési képernyő
2. **Email megadása**: Írja be az email címét
3. **Jelszó megadása**: Írja be a jelszavát (rejtett karakterek)
4. **Bejelentkezés**: Kattintson a "Bejelentkezés" gombra
5. **Validáció**: Az alkalmazás ellenőrzi az adatokat az API-n keresztül
6. **Átirányítás**: Sikeres bejelentkezés után a főablak jelenik meg

### Szerepkör-alapú hozzáférés

#### Adminisztrátor
- **Email**: `gal.miklos1976@gmail.com`
- **Jogosultságok**: Teljes hozzáférés
- **Elérhető funkciók**:
  - Felhasználók kezelése
  - Rendszer beállítások módosítása
  - Összes riasztás áttekintése

#### Diszpécser
- **Email**: Bármilyen más érvényes email
- **Jogosultságok**: Diszpécser funkciók
- **Elérhető funkciók**:
  - Aktuális riasztások kezelése
  - Eseménynapló megtekintése
  - Jelentések készítése

### Kijelentkezés

1. Kattintson a "Kijelentkezés" gombra a jobb felső sarokban
2. Az alkalmazás visszatér a bejelentkezési képernyőre

## Technikai Részletek

### API Integráció

Az alkalmazás a következő API-t használja:
- **Endpoint**: `https://api.hernadved.hu/users?email={email}`
- **Metódus**: GET
- **Válasz**: JSON formátumú felhasználói adatok

### Biztonsági Funkciók

- Jelszó mezők rejtett karakterekkel
- API alapú autentikáció
- Szerepkör-alapú hozzáférés ellenőrzés
- HTTPS kommunikáció

### Hibaüzenetek

Az alkalmazás magyar nyelvű hibaüzeneteket jelenít meg:
- "Helytelen email vagy jelszó!" - sikertelen bejelentkezés esetén
- "Hiba történt a bejelentkezés során: {hiba}" - technikai hibák esetén

## Rendszerkövetelmények

- **Operációs rendszer**: Windows 10/11
- **.NET Runtime**: .NET 8.0 vagy újabb
- **Internet kapcsolat**: Szükséges az API eléréséhez
- **Képernyő felbontás**: Minimum 1024x768

## Támogatás

A Hernád-Véd rendszer működésével kapcsolatos kérdések esetén forduljon a rendszergazdához.

---
© 2025 Hernád-Véd - Minden jog fenntartva
