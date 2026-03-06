# 🔧 AutoserviceMI — Sistem de Gestiune Autoservice

O aplicație desktop dezvoltată în **C# / WPF** cu **Entity Framework Core** și **SQLite**, destinată gestionării complete a activității unui autoservice auto.

---

## 📋 Descriere

AutoserviceMI permite administrarea clienților, vehiculelor, programărilor, reparațiilor și stocului de piese dintr-o singură interfață intuitivă. Aplicația include autentificare cu roluri, un dashboard cu informații în timp real și operațiuni CRUD complete pentru fiecare modul.

---

## 🚀 Funcționalități principale

### 🔐 Autentificare
- Login cu username și parolă
- Gestionare utilizatori cu roluri (stocate în baza de date)

### 📊 Dashboard
- Carduri cu numărul de programări urgente, programări azi, reparații în progres și produse cu stoc mic
- Liste rapide cu programările urgente și cele din ziua curentă
- Alertă vizuală pentru produsele cu stoc sub limita minimă

### 👤 Clienți
- Adăugare, modificare și ștergere clienți
- Validări: nume/prenume cu literă mare, fără cifre, max 30 caractere; telefon în format `+373`, max 12 caractere; oraș valid
- Filtrare după nume, prenume, telefon și oraș

### 🚗 Vehicule
- Adăugare și modificare vehicule asociate clienților
- Validare VIN (17 caractere, regex strict)
- Filtrare după număr de înmatriculare, marcă, model, VIN

### 📅 Programări
- Creare programări cu client, vehicul, dată, tip intervenție și mecanic
- Schimbare stare: `Planificată` → `În progres` → `Finalizată`
- Filtrare după client, vehicul, dată și stare

### 🔩 Reparații
- Adăugare reparații cu tip intervenție din listă predefinită, mecanic și cost estimat
- Actualizare stare și dată de finalizare
- Filtrare avansată (client, vehicul, status, tip intervenție, interval de date)
- Normalizare automată a statusurilor inconsistente din baza de date

### 📦 Depozit (Piese)
- Gestiune produse cu: cod produs, denumire, producător, preț, stoc curent și stoc minim
- Alertă pentru produse sub stocul minim (vizibil în Dashboard)
- Filtrare după cod, denumire, producător și preț

---

## 🛠️ Tehnologii folosite

| Tehnologie | Rol |
|---|---|
| C# / WPF | Interfață grafică desktop |
| Entity Framework Core | ORM pentru accesul la date |
| SQLite | Bază de date locală |
| SQLitePCL | Provider SQLite pentru .NET |
| LINQ | Interogări și filtrare date |

---

## 📁 Structura proiectului

```
AutoserviceMI/
├── Data/
│   ├── ProductDbContext.cs       # Contextul Entity Framework
│   └── Adaugare_client.xaml.cs   # (în namespace AutoserviceMI.Data)
├── Detalii/
│   ├── Client.cs                 # Model client
│   ├── Vehicul.cs                # Model vehicul
│   ├── Programare.cs             # Model programare
│   ├── Reparatie.cs              # Model reparație
│   └── Produs.cs                 # Model produs depozit
├── Views/
│   ├── MainWindow.xaml(.cs)      # Ecran de login
│   ├── Dashboard.xaml(.cs)       # Pagina principală
│   ├── Clienti.xaml(.cs)         # Gestiune clienți
│   ├── Vehicule.xaml(.cs)        # Gestiune vehicule
│   ├── Programari.xaml(.cs)      # Gestiune programări
│   ├── Reparatii.xaml(.cs)       # Gestiune reparații
│   └── Depozit.xaml(.cs)         # Gestiune depozit
├── Forms/
│   ├── Adaugare_client.xaml(.cs)
│   ├── Adaugare_Vehicul.xaml(.cs)
│   ├── Adaugare_Programare.xaml(.cs)
│   ├── Adaugare_Reparatie.xaml(.cs)
│   ├── Adaugare_Depozit.xaml(.cs)
│   ├── Modificare_client.xaml(.cs)
│   ├── Modificare_Vehicul.xaml(.cs)
│   ├── Modificare_Programare.xaml(.cs)
│   ├── Modificare_Reparatie.xaml(.cs)
│   ├── Modificare_Depozit.xaml(.cs)
│   └── Filtrare_Reparatii.xaml(.cs)
└── App.xaml(.cs)                 # Punct de intrare, inițializare DB
```

---

## ⚙️ Instalare și rulare

### Cerințe
- Visual Studio 2022 (sau mai nou)
- .NET Framework / .NET 6+
- NuGet packages: `Microsoft.EntityFrameworkCore`, `Microsoft.EntityFrameworkCore.Sqlite`, `SQLitePCLRaw`

### Pași

```bash
# 1. Clonează repository-ul
git clone https://github.com/username/AutoserviceMI.git

# 2. Deschide soluția în Visual Studio
# AutoserviceMI.sln

# 3. Restaurează pachetele NuGet
# Tools → NuGet Package Manager → Restore

# 4. Rulează aplicația (F5)
# Baza de date SQLite se creează automat la primul start
```

---

## 🗄️ Modele de date

```
Client          → Vehicul (1:N)
Client          → Programare (1:N)
Client          → Reparatie (1:N)
Vehicul         → Programare (1:N)
Vehicul         → Reparatie (1:N)
Produs                              (independent)
User                                (autentificare)
```

---

## 📸 Interfață

| Modul | Descriere |
|---|---|
| Login | Autentificare cu username/parolă |
| Dashboard | Vedere de ansamblu cu alerte și statistici |
| Clienți | Tabel cu filtrare și CRUD complet |
| Vehicule | Asociate clienților, validare VIN |
| Programări | Calendar cu schimbare rapidă de stare |
| Reparații | Urmărire completă cu filtrare avansată |
| Depozit | Stoc piese cu alertă stoc minim |

---

## 👨‍💻 Autor

Proiect realizat ca aplicație de gestiune pentru un autoservice, cu accent pe validări robuste, filtrare flexibilă și interfață prietenoasă.

---
