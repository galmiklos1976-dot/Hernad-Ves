# Alkalmazás Folyamatábra

## Teljes Felhasználói Flow

```
┌─────────────────────────────────────────────────────────────────┐
│                    ALKALMAZÁS INDÍTÁSA                          │
│                                                                 │
│                    HernadVed.exe Start                         │
│                           │                                     │
│                           ▼                                     │
│                   ┌───────────────┐                            │
│                   │   App.xaml    │                            │
│                   │  Resources    │                            │
│                   └───────┬───────┘                            │
│                           │                                     │
│                           ▼                                     │
└─────────────────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────────────────┐
│                    LOGIN KÉPERNYŐ                               │
│                                                                 │
│   ┌──────────────────────────────────────────────────┐        │
│   │         LoginWindow.xaml (View)                   │        │
│   │                                                   │        │
│   │   Hernád-Véd Diszpécser Rendszer                │        │
│   │   ─────────────────────────────────              │        │
│   │                                                   │        │
│   │   Email cím:                                     │        │
│   │   [________________________________]              │        │
│   │                                                   │        │
│   │   Jelszó:                                        │        │
│   │   [••••••••••••••••••••••••••••]                │        │
│   │                                                   │        │
│   │   [ ❌ Helytelen email vagy jelszó! ]           │        │
│   │                                                   │        │
│   │            [  Bejelentkezés  ]                   │        │
│   │                                                   │        │
│   │     ⏳ Bejelentkezés folyamatban...             │        │
│   └──────────────────────────────────────────────────┘        │
│                           │                                     │
│                           │ Data Binding                        │
│                           ▼                                     │
│   ┌──────────────────────────────────────────────────┐        │
│   │      LoginViewModel (ViewModel)                   │        │
│   │                                                   │        │
│   │  Properties:                                     │        │
│   │  • Email                                         │        │
│   │  • Password                                      │        │
│   │  • ErrorMessage                                  │        │
│   │  • IsLoading                                     │        │
│   │                                                   │        │
│   │  Commands:                                       │        │
│   │  • LoginCommand                                  │        │
│   │                                                   │        │
│   │  Methods:                                        │        │
│   │  • LoginAsync()                                  │        │
│   │  • CanLogin()                                    │        │
│   └──────────────────┬───────────────────────────────┘        │
│                      │                                          │
│                      │ API Call                                 │
│                      ▼                                          │
└─────────────────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────────────────┐
│                    API KOMMUNIKÁCIÓ                             │
│                                                                 │
│   ┌──────────────────────────────────────────────────┐        │
│   │         ApiService (Service)                      │        │
│   │                                                   │        │
│   │  Methods:                                        │        │
│   │  • GetUserByEmailAsync(email)                   │        │
│   │  • AuthenticateUserAsync(email, password)       │        │
│   └──────────────────┬───────────────────────────────┘        │
│                      │                                          │
│                      │ HTTP GET                                 │
│                      ▼                                          │
│   ┌──────────────────────────────────────────────────┐        │
│   │     https://api.hernadved.hu/users?email={email} │        │
│   │                                                   │        │
│   │     Response: JSON Array[User]                   │        │
│   └──────────────────┬───────────────────────────────┘        │
│                      │                                          │
│                      │ JSON Parse                               │
│                      ▼                                          │
│   ┌──────────────────────────────────────────────────┐        │
│   │           User Model                              │        │
│   │                                                   │        │
│   │  Properties:                                     │        │
│   │  • Id                                            │        │
│   │  • Email                                         │        │
│   │  • Password                                      │        │
│   │  • Role                                          │        │
│   │  • Name                                          │        │
│   │  • IsAdmin (computed)                            │        │
│   └──────────────────┬───────────────────────────────┘        │
│                      │                                          │
│                      │ Password Validation                      │
│                      ▼                                          │
└─────────────────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────────────────┐
│                   SZEREPKÖR ELLENŐRZÉS                          │
│                                                                 │
│                      User.IsAdmin?                              │
│                           │                                     │
│              ┌────────────┴────────────┐                       │
│              ▼                         ▼                        │
│         Email ==               Email !=                         │
│   "gal.miklos1976@gmail.com"  "gal.miklos1976@gmail.com"      │
│              │                         │                        │
│              ▼                         ▼                        │
│         Role = "Admin"          Role = "Dispatcher"            │
└─────────────────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────────────────┐
│                    FŐABLAK - ADMIN                              │
│                                                                 │
│   ┌──────────────────────────────────────────────────┐        │
│   │         MainWindow.xaml (Admin View)              │        │
│   │                                                   │        │
│   │   Hernád-Véd Diszpécser Rendszer                │        │
│   │   ────────────────────────────────               │        │
│   │                            gal.miklos1976@...    │        │
│   │                            Szerepkör: Admin      │        │
│   │                            [Kijelentkezés]       │        │
│   │                                                   │        │
│   │   Üdvözöljük a Hernád-Véd rendszerben!          │        │
│   │                                                   │        │
│   │   Ön adminisztrátorként jelentkezett be.        │        │
│   │   Teljes hozzáféréssel rendelkezik.             │        │
│   │                                                   │        │
│   │   ┌─────────────────────────────────┐           │        │
│   │   │  Adminisztrátori Funkciók       │           │        │
│   │   ├─────────────────────────────────┤           │        │
│   │   │  [Felhasználók kezelése    ]    │           │        │
│   │   │  [Rendszer beállítások     ]    │           │        │
│   │   │  [Riasztások áttekintése   ]    │           │        │
│   │   └─────────────────────────────────┘           │        │
│   └──────────────────────────────────────────────────┘        │
└─────────────────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────────────────┐
│                  FŐABLAK - DISPATCHER                           │
│                                                                 │
│   ┌──────────────────────────────────────────────────┐        │
│   │       MainWindow.xaml (Dispatcher View)           │        │
│   │                                                   │        │
│   │   Hernád-Véd Diszpécser Rendszer                │        │
│   │   ────────────────────────────────               │        │
│   │                         dispatcher@hernadved.hu  │        │
│   │                         Szerepkör: Dispatcher    │        │
│   │                         [Kijelentkezés]          │        │
│   │                                                   │        │
│   │   Üdvözöljük a Hernád-Véd rendszerben!          │        │
│   │                                                   │        │
│   │   Ön diszpécserként jelentkezett be.            │        │
│   │   Hozzáférése van a diszpécser funkciókhoz.     │        │
│   │                                                   │        │
│   │   ┌─────────────────────────────────┐           │        │
│   │   │  Diszpécser Funkciók            │           │        │
│   │   ├─────────────────────────────────┤           │        │
│   │   │  [Aktuális riasztások      ]    │           │        │
│   │   │  [Eseménynapló             ]    │           │        │
│   │   │  [Jelentések               ]    │           │        │
│   │   └─────────────────────────────────┘           │        │
│   └──────────────────────────────────────────────────┘        │
└─────────────────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────────────────┐
│                      KIJELENTKEZÉS                              │
│                                                                 │
│                 [Kijelentkezés] Button Click                    │
│                           │                                     │
│                           ▼                                     │
│                  Close MainWindow                               │
│                           │                                     │
│                           ▼                                     │
│                  Show LoginWindow                               │
│                           │                                     │
│                           ▼                                     │
│                  Return to Login Screen                         │
└─────────────────────────────────────────────────────────────────┘

## MVVM Architektúra

```
┌─────────────────────┐
│       VIEW          │  XAML Files
│  ┌──────────────┐   │  - LoginWindow.xaml
│  │ LoginWindow  │   │  - MainWindow.xaml
│  │ MainWindow   │   │
│  └──────────────┘   │  Responsibility:
│                     │  - UI Layout
│                     │  - User Input
│                     │  - Visual Display
└─────────┬───────────┘
          │
          │ Data Binding
          │ Commands
          │ Events
          ▼
┌─────────────────────┐
│    VIEW MODEL       │  C# Classes
│  ┌──────────────┐   │  - LoginViewModel
│  │LoginViewModel│   │  - ViewModelBase
│  │RelayCommand  │   │  - RelayCommand
│  └──────────────┘   │
│                     │  Responsibility:
│                     │  - Business Logic
│                     │  - Data Binding
│                     │  - Commands
│                     │  - Validation
└─────────┬───────────┘
          │
          │ Service Calls
          │ Model Updates
          │
          ▼
┌─────────────────────┐
│      MODEL          │  C# Classes
│  ┌──────────────┐   │  - User
│  │    User      │   │  - ApiService
│  │  ApiService  │   │
│  └──────────────┘   │  Responsibility:
│                     │  - Data Models
│                     │  - API Communication
│                     │  - Business Rules
└─────────────────────┘
```

## Data Flow Diagram

```
User Input (Email + Password)
    │
    ▼
LoginWindow.xaml
    │ Data Binding
    ▼
LoginViewModel
    │
    ├─→ Email Property
    ├─→ Password Property
    ├─→ ErrorMessage Property
    └─→ IsLoading Property
    │
    ▼ LoginCommand.Execute()
LoginViewModel.LoginAsync()
    │
    ▼
ApiService.AuthenticateUserAsync()
    │
    ├─→ ApiService.GetUserByEmailAsync()
    │       │
    │       ▼
    │   HttpClient.GetAsync()
    │       │
    │       ▼
    │   https://api.hernadved.hu/users?email={email}
    │       │
    │       ▼
    │   JSON Response
    │       │
    │       ▼
    │   JsonConvert.DeserializeObject<List<User>>()
    │       │
    │       ▼
    │   User Object
    │
    ├─→ Password Validation
    │
    ▼
User Object with Role
    │
    ├─→ if (User.IsAdmin) → Role = "Admin"
    └─→ else → Role = "Dispatcher"
    │
    ▼
new MainWindow(user)
    │
    ▼
MainWindow.Show()
    │
    ├─→ if (Admin) → Show AdminPanel
    └─→ else → Show DispatcherPanel
    │
    ▼
LoginWindow.Close()
```

## Komponens Kapcsolatok

```
                    ┌──────────────┐
                    │   App.xaml   │
                    │  Application │
                    └──────┬───────┘
                           │ StartupUri
                           ▼
        ┌──────────────────────────────────────┐
        │                                      │
        ▼                                      ▼
┌───────────────┐                    ┌─────────────────┐
│ LoginWindow   │                    │   MainWindow    │
│               │                    │                 │
│ - EmailBox    │                    │ - UserInfo      │
│ - PasswordBox │                    │ - AdminPanel    │
│ - LoginButton │                    │ - DispatcherPnl │
└───────┬───────┘                    └────────┬────────┘
        │                                     │
        │ DataContext                         │ User object
        ▼                                     ▼
┌───────────────┐                    ┌─────────────────┐
│LoginViewModel │                    │  (Code-behind)  │
│               │                    │                 │
│ Uses:         │                    │ - Initialize UI │
│ - ApiService  │◄───────────────────┤ - Handle Logout │
│ - RelayCommand│                    └─────────────────┘
└───────┬───────┘
        │
        │ Inherits
        ▼
┌───────────────┐
│ViewModelBase  │
│               │
│ INotifyProp...│
└───────────────┘
```

---

**Dokumentum célja**: Vizuális áttekintés az alkalmazás működéséről és komponensek kapcsolatáról.

© 2025 Hernád-Véd - Minden jog fenntartva
