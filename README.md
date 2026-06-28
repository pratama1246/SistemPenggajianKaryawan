# 💳 Employee Payroll Information System (PNC)

**Sistem Informasi Penggajian Karyawan** (Employee Payroll Information System) is a desktop application based on **Windows Forms (C# .NET Framework 4.8)** designed to manage employee profiles, track daily attendance, configure custom salary components, calculate monthly payroll automatically, and print/view salary slips. This project was built as a practical assignment for the Object-Oriented Programming (OOP) Lab Course at **Politeknik Negeri Cilacap**.

The application supports 4 distinct user roles:

- **Admin**: Manages user accounts (CRUD), manages master employee records (CRUD), handles password management, and views high-level system statistics.
- **HRD**: Manages attendance records (manual logs, shift configurations, and late tolerances), configures salary components (allowances & deductions), processes monthly payroll, and reviews historical attendance & payment summaries.
- **Employee (Karyawan)**: Accesses a personal dashboard (showing attendance stats and active status), reviews attendance history, and prints monthly salary slips.
- **Kiosk (Webcam Attendance)**: A dedicated terminal screen for contactless check-in/out by scanning printed employee QR Code cards using a live webcam feed.

> The application integrates a webcam scanning system using computer vision to read QR Codes for automated kiosk-mode attendance processing.
> Practical Object-Oriented Programming Project — Department of Informatics Engineering, Politeknik Negeri Cilacap.

---

[![C#](https://img.shields.io/badge/C%23-8.0-blueviolet?style=for-the-badge&logo=csharp&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![.NET Framework](https://img.shields.io/badge/.NET_Framework-4.8-blue?style=for-the-badge&logo=.net&logoColor=white)](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48)
[![Windows Forms](https://img.shields.io/badge/Windows_Forms-v4.8-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/)
[![MySQL](https://img.shields.io/badge/MySQL-9.7+-4479A1?style=for-the-badge&logo=mysql&logoColor=white)](https://mysql.com)
[![ZXing.Net](https://img.shields.io/badge/ZXing.Net-0.16.9-orange?style=for-the-badge&logo=nuget&logoColor=white)](https://www.nuget.org/packages/ZXing.Net/)
[![AForge.NET](https://img.shields.io/badge/AForge.Video-2.2.5-green?style=for-the-badge&logo=nuget&logoColor=white)](https://www.nuget.org/packages/AForge.Video.DirectShow/)
[![Bouncy Castle](https://img.shields.io/badge/Bouncy_Castle-v2.6.2-yellowgreen?style=for-the-badge&logo=nuget&logoColor=white)](https://www.nuget.org/packages/BouncyCastle.Cryptography/)
[![Visual Studio 2022](https://img.shields.io/badge/Visual_Studio-2022-5C2D91?style=for-the-badge&logo=visual-studio&logoColor=white)](https://visualstudio.microsoft.com/)

---

## Table of Contents

- [Key Features](#key-features)
- [Folder Structure](#folder-structure)
- [Visual Design & Theme](#visual-design--theme)
- [Tech Stack](#tech-stack)
- [Requirements](#requirements)
- [Local Setup](#local-setup)
- [Default Testing Credentials](#default-testing-credentials)
- [Database Configuration & Schema](#database-configuration--schema)
- [Coding Conventions](#coding-conventions)
- [How to Run](#how-to-run)
- [Team](#team)
- [License](#license)

---

## Key Features

### 🔑 Authentication & Security
- Secure login and logout flows using custom password cryptography implemented in [Auth_serv](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/Service/Auth_serv.cs).
- Dynamic dashboard redirection based on the authenticated user's role (Admin, HRD, Employee, or Kiosk).
- Secure password reset utility accessible in [FormGantiPassword](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/FormGantiPassword.cs).

### 👥 Administrator Panel
- **User Management**: Complete CRUD operations for login accounts in [FormManajemenUser](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/FormManajemenUser.cs).
- **Employee Management**: CRUD operations for employee master profiles (Permanent, Contract, Daily) in [FormKaryawan](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/FormKaryawan.cs).
- **QR Identity Cards**: Automatically generate and download employee QR identity badges as PNG files via [FormQRPreview](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/FormQRPreview.cs).

### 💼 HRD Panel
- **Attendance Management**: Log daily attendance manually (Present, Sick, Leave, Alpha) in [FormAbsensi](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/FormAbsensi.cs).
- **Shift Settings**: Set normal start time, end time, and grace period (late tolerance) in minutes.
- **Salary Components**: Configure allowances and deductions dynamically (by nominal values or percentages) and apply them to specific employee categories in [FormKomponenGaji](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/FormKomponenGaji.cs).
- **Payroll Processing**: Automatic monthly payroll calculation based on basic salary, active allowances, deductions, and attendance records in [FormProsesGaji](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/FormProsesGaji.cs).
- **Recaps & Reports**: View detailed attendance history in [FormRekapAbsensi](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/FormRekapAbsensi.cs) and payroll payout summaries in [FormRekapGaji](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/FormRekapGaji.cs).

### 🖥️ Kiosk Mode (Webcam Scanner)
- Contactless self-attendance clocking.
- Integrates `AForge` library to capture live webcam streams.
- Decodes scanned employee QR codes instantly using `ZXing.Net`.
- Automated late penalty detection based on predefined shift parameters.

### 📄 Employee Portal
- Personal dashboard showing real-time attendance statistics and active payroll history in [FormDashboardKaryawan](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/FormDashboardKaryawan.cs).
- Access to print-ready monthly salary slips rendered dynamically using GDI+ in [FormSlipGaji](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/FormSlipGaji.cs).

---

## Folder Structure

The project's architectural structure is organized as follows:

```
SistemPenggajianKaryawan/
├── Konfigurasi/
│   ├── DatabaseSeeder.cs      ← Automatic database seeder & schema initialization
│   ├── Koneksi.cs             ← Concrete MySQL connection execution layer
│   ├── Konfigurasi.cs         ← Abstract database configuration contract
│   └── UserSession.cs         ← Static class for active user session management
├── Model/
│   ├── BaseKaryawan.cs        ← Abstract base class representing OOP employee hierarchy
│   ├── KaryawanTetap.cs       ← Permanent employee model class
│   ├── KaryawanKontrak.cs     ← Contract employee model class
│   ├── KaryawanHarian.cs      ← Daily employee model class
│   ├── KomponenGaji.cs        ← Salary component definition model
│   └── DataAbsensi.cs         ← Attendance log record model
├── Service/
│   ├── Auth_serv.cs           ← Login authentication & cryptography algorithms
│   ├── Karyawan_serv.cs       ← Employee database CRUD operations
│   ├── Absensi_serv.cs        ← Attendance logging CRUD operations
│   └── Gaji_serv.cs           ← Salary calculation business rules & factories
├── Resources/
│   └── Politeknik_Negeri_Cilacap.png  ← Logo asset representing the university brand
├── App.config                 ← Application runtime configurations and assemblies
├── FormAbsensi.cs             ← Manual logs and kiosk scanner webcam controller
├── FormAuthExit.cs            ← Secure dialog verifying credentials before exiting Kiosk
├── FormDashboardAdmin.cs      ← Administrator landing panel dashboard
├── FormDashboardHRD.cs        ← HRD landing panel dashboard
├── FormDashboardKaryawan.cs   ← Employee dashboard and status panel
├── FormGantiPassword.cs       ← User password update screen
├── FormKaryawan.cs            ← Employee master editor and management
├── FormKomponenGaji.cs        ← Allowance & deduction editor
├── FormLogin.cs               ← User gateway credentials checker
├── FormManajemenUser.cs       ← Administrator credentials editor
├── FormProsesGaji.cs          ← Monthly payroll calculations trigger
├── FormQRPreview.cs           ← QR Badge generator and download panel
├── FormRekapAbsensi.cs        ← HRD attendance logs table
├── FormRekapGaji.cs          ← HRD payout logs table
├── FormSlipGaji.cs            ← Employee dynamic salary slip rendering
├── FormSplash.cs              ← Loader screen running seeder on initialization
├── Program.cs                 ← Main process execution bootstrap entry
└── SistemPenggajianKaryawan.csproj ← Visual Studio project definition file
```

---

## Visual Design & Theme

The user interface follows strict design specifications detailed in [DESIGN.md](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/DESIGN.md). The styling incorporates the branding colors of Politeknik Negeri Cilacap for a professional and modern look.

### 🎨 Color Tokens
- **Primary Color (`#5BC8F5`)**: Used for main actions, active selections, top accent bars, and input borders.
- **Primary Dark Color (`#1E90FF`)**: Applied to save operations and hover states.
- **Accent Color (`#F5A623`)**: Used for highlights, alert badges, and secondary elements.
- **Neutral Background (`#F4F6F9`)**: Default canvas color for all forms.
- **Surface Background (`#FFFFFF`)**: Input sections, group boxes, and cards.
- **Typography Font**: Standardized **Segoe UI** typography hierarchy used application-wide.

---

## Tech Stack

**Core Technology & Infrastructure**
- **Programming Language**: C# (`.NET Framework 4.8`)
- **UI Framework**: Windows Forms (WinForms)
- **Database Engine**: MySQL Server
- **Database Driver**: ADO.NET Provider (`MySql.Data` `v9.7.0`)
- **IDE**: Visual Studio 2022

**Third-Party Libraries & Transitive Dependencies (NuGet Packages)**
- **AForge.Video & AForge.Video.DirectShow** (`v2.2.5`): High-performance webcam acquisition tools.
- **AForge** (`v2.2.5`): Base computer vision frameworks.
- **ZXing.Net** (`v0.16.9`): Multi-format 1D/2D barcode image processing library.
- **BouncyCastle.Cryptography** (`v2.6.2`): Advanced cryptography provider for securing passwords.
- **Google.Protobuf** (`v3.32.0`): Protocol Buffers message serialization library.
- **ZstdSharp.Port** (`v0.8.6`): Port of Zstandard compression algorithm for MySQL connection optimization.
- **K4os.Compression.LZ4 & LZ4.Streams** (`v1.3.8`): LZ4 compression algorithms.
- **System.Configuration.ConfigurationManager** (`v8.0.0`): Access to local machine configuration parameters.
- **System.IO.Pipelines** (`v5.0.2`): High-performance buffer pipeline management.
- **System.Memory** (`v4.5.5`): Shared structures for memory optimizations.
- **System.Runtime.CompilerServices.Unsafe** (`v6.0.0`): Support for low-level memory operations.


---

## Requirements

Ensure your workstation meets these prerequisites before running or building the project:
- **Operating System**: Windows 10 or 11
- **IDE**: Visual Studio 2022 (with *Desktop development with .NET* workload)
- **Framework**: .NET Framework 4.8 SDK & Runtime
- **Database**: MySQL Server (supported via XAMPP, Laragon, or standalone native setups)

---

## Local Setup

Deploy the application locally by following these steps:

```bash
# 1) Clone the repository to your local machine
git clone https://github.com/pratama1246/SistemPenggajianKaryawan.git
cd SistemPenggajianKaryawan

# 2) Create the database in MySQL
# Open phpMyAdmin, DBeaver, or command line client and execute:
CREATE DATABASE penggajian;

# 3) Database Connection Setup (Optional)
# The default connection parameters are: server=localhost, database=penggajian, user=root, password=empty.
# Adjust the connection settings if yours differ in:
# SistemPenggajianKaryawan/Konfigurasi/Koneksi.cs (line 13)
```

No database importing step is needed. The system employs a self-healing auto-seeder in the [DatabaseSeeder](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/Konfigurasi/DatabaseSeeder.cs) class. Upon starting the app for the first time, it will:
1. Build the database structure if tables are missing (`CREATE TABLE IF NOT EXISTS`).
2. Adjust schema columns and enforce relational constraints.
3. Seed sample data including employees, payroll definitions, May 2026 attendance, and testing user credentials.

---

## Default Testing Credentials

Use these default user accounts to explore different features after launching the application:

| Role | Username | Password | Intended Use / Features |
|---|---|---|---|
| **Administrator** | `admin` | `admin123` | Employee/User CRUD control, QR badges downloads. |
| **HRD** | `hrd` | `hrd123` | Payroll calculations, shift settings, attendance updates, reports. |
| **Kiosk Mode** | `kiosk` | `kiosk123` | Live webcam QR scanner check-in panel. |
| **Employee (Karyawan)** | `karyawan` | `karyawan123` | Personal stats, individual attendance history, printing slip salary. |

---

## Coding Conventions

Developers must adhere to standard coding styles documented in [AGENTS.md](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/AGENTS.md):

- **Class Names**: PascalCase nouns (e.g. `KaryawanTetap`, `FormAbsensi`).
- **Service Classes**: PascalCase nouns with `_serv` suffix (e.g. `Gaji_serv`).
- **Model Fields**: Properties defined in `snake_case` mapping to backing fields starting with an underscore (e.g. `_kode_karyawan` & `kode_karyawan`).
- **UI Controls**: Suffix abbreviations based on type (e.g. `simpan_btn`, `cari_txt`, `absensi_dgv`, `bulan_cmb`).

---

## How to Run

1. Open the Solution file `SistemPenggajianKaryawan.slnx` or Project file `SistemPenggajianKaryawan.csproj` in Visual Studio 2022.
2. Allow Visual Studio to restore all required NuGet packages automatically.
3. Ensure your MySQL server is running and the `penggajian` schema has been created.
4. Press **F5** or click **Start** in Visual Studio to build and launch the application.
5. The Splash screen will run the database seeder on initialization and redirect you to the login screen.

---

## 👥 Team

This practical application was built by the student group from Politeknik Negeri Cilacap:
- **[Your Name]** - Lead Developer / Programmer
- **[Teammate Name 1]** - Database Engineer / System Analyst
- **[Teammate Name 2]** - UI Designer / System Tester

Developed for the Object-Oriented Programming (OOP) Practical Assignment at Politeknik Negeri Cilacap, Department of Informatics Engineering.

**Class**: Informatics Engineering [Your Class]  
**Course**: Object-Oriented Programming (OOP) Lab  
**Institution**: Politeknik Negeri Cilacap

---

## License

This project is licensed under the terms of the [MIT License](LICENSE).
