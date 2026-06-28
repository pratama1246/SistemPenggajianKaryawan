# 💳 Sistem Informasi Penggajian Karyawan (PNC)

**Sistem Informasi Penggajian Karyawan** adalah sebuah aplikasi desktop berbasis **Windows Forms (C# .NET Framework 4.8)** yang dirancang untuk mengelola data karyawan, pencatatan absensi, pengelolaan komponen gaji, pemrosesan gaji bulanan secara otomatis, serta pencetakan slip gaji. Proyek ini dibangun sebagai bagian dari praktikum mata kuliah Pemrograman Berorientasi Objek (PBO) di **Politeknik Negeri Cilacap**.

Aplikasi ini mendukung 4 peran (roles) utama dengan alur kerja masing-masing:

- **Admin**: Mengelola user login (CRUD), mengelola master data karyawan (CRUD), mengganti password, serta melihat ringkasan statistik sistem.
- **HRD**: Mengelola absensi harian karyawan, konfigurasi jam kerja dan toleransi keterlambatan, manajemen komponen gaji (tunjangan & potongan), memproses gaji bulanan karyawan, serta melihat rekapitulasi absensi & gaji.
- **Karyawan**: Mengakses dashboard pribadi (informasi status aktif dan total kehadiran), melihat riwayat absensi, serta melihat dan mencetak slip gaji bulanan secara mandiri.
- **Kiosk (Webcam Attendance)**: Mode khusus untuk pencatatan absensi mandiri karyawan menggunakan pemindaian kartu identitas QR Code melalui integrasi kamera webcam secara real-time.

> Aplikasi ini menggunakan pencatatan absensi berbasis kamera (kiosk mode) yang secara otomatis mendeteksi dan menerjemahkan QR Code karyawan untuk pencatatan jam masuk & keluar secara presisi.
> Proyek Praktikum Pemrograman Berorientasi Objek — Jurusan Teknik Informatika, Politeknik Negeri Cilacap.

---

[![C#](https://img.shields.io/badge/C%23-8.0-blueviolet?style=for-the-badge&logo=csharp&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![.NET Framework](https://img.shields.io/badge/.NET_Framework-4.8-blue?style=for-the-badge&logo=.net&logoColor=white)](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48)
[![MySQL](https://img.shields.io/badge/MySQL-9.7+-4479A1?style=for-the-badge&logo=mysql&logoColor=white)](https://mysql.com)
[![ZXing.Net](https://img.shields.io/badge/ZXing.Net-0.16.9-orange?style=for-the-badge&logo=nuget&logoColor=white)](https://www.nuget.org/packages/ZXing.Net/)
[![AForge.NET](https://img.shields.io/badge/AForge.Video-2.2.5-green?style=for-the-badge&logo=nuget&logoColor=white)](https://www.nuget.org/packages/AForge.Video.DirectShow/)

---

## Table of Contents

- [Key Features](#key-features)
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
- [Disclaimer](#disclaimer)

---

## Key Features

### 🔑 Authentication & Security
- Sistem Login & Logout yang aman berbasis enkripsi password satu arah menggunakan algoritma custom di kelas [Auth_serv](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/Service/Auth_serv.cs).
- Pengalihan antarmuka dashboard secara dinamis berdasarkan role yang terautentikasi (Admin, HRD, Karyawan, Kiosk).
- Fitur ganti password aman bagi seluruh pengguna melalui [FormGantiPassword](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/FormGantiPassword.cs).

### 👥 Administrator Panel
- **Manajemen User**: Operasi CRUD akun pengguna di [FormManajemenUser](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/FormManajemenUser.cs).
- **Manajemen Karyawan**: Operasi CRUD data master karyawan (Tetap, Kontrak, Harian) di [FormKaryawan](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/FormKaryawan.cs).
- **Kartu Identitas QR Code**: Menghasilkan kartu identitas dengan QR Code unik yang dapat diunduh sebagai berkas PNG melalui [FormQRPreview](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/FormQRPreview.cs).

### 💼 HRD Panel
- **Manajemen Absensi**: Pencatatan manual kehadiran, sakit, izin, atau alpha di [FormAbsensi](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/FormAbsensi.cs).
- **Konfigurasi Jam Kerja**: Mengatur batas jam masuk normal, jam pulang, serta toleransi keterlambatan dalam menit.
- **Komponen Gaji**: Menentukan besaran tunjangan dan potongan secara dinamis berdasarkan nominal atau persentase, serta batas berlaku per jenis karyawan di [FormKomponenGaji](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/FormKomponenGaji.cs).
- **Proses Gaji**: Pemrosesan kalkulasi gaji bulanan otomatis yang menggabungkan gaji pokok, tunjangan, potongan, serta akumulasi kehadiran di [FormProsesGaji](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/FormProsesGaji.cs).
- **Rekapitulasi**: Mengakses laporan rekap absensi di [FormRekapAbsensi](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/FormRekapAbsensi.cs) dan rekap penggajian di [FormRekapGaji](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/FormRekapGaji.cs).

### 🖥️ Kiosk Mode (Webcam Scanner)
- Pencatatan kehadiran mandiri tanpa kontak fisik.
- Menggunakan library `AForge` untuk menangkap feed kamera secara real-time.
- Pemindaian dan pembacaan QR Code secara instan dengan `ZXing.Net`.
- Validasi data keterlambatan otomatis berdasarkan toleransi jam kerja yang telah ditentukan.

### 📄 Karyawan Portal
- Tampilan dashboard dengan statistik kehadiran berjalan di [FormDashboardKaryawan](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/FormDashboardKaryawan.cs).
- Melihat riwayat penerimaan gaji bulanan.
- Cetak slip gaji terformat rapi dengan struktur rincian detail menggunakan rendering GDI+ di [FormSlipGaji](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/FormSlipGaji.cs).

---

## Visual Design & Theme

Desain visual aplikasi ini mengikuti panduan ketat yang tertuang di [DESIGN.md](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/DESIGN.md). Desain ini mengambil inspirasi warna dari logo institusi Politeknik Negeri Cilacap untuk menghadirkan kesan profesional, terang, dan bersih.

### 🎨 Color Tokens
- **Primary Color (`#5BC8F5`)**: Digunakan sebagai tombol utama, sorotan aktif, accent bar atas, dan garis batas fokus input.
- **Primary Dark Color (`#1E90FF`)**: Digunakan sebagai tombol simpan data serta efek hover tombol primary.
- **Accent Color (`#F5A623`)**: Digunakan untuk penanda badge kecil, peringatan, dan detail highlight.
- **Neutral Background (`#F4F6F9`)**: Background dasar utama form.
- **Surface Background (`#FFFFFF`)**: Background panel input, groupbox, serta elemen kartu aktivitas.
- **Typography Font**: Menggunakan satu rumpun font **Segoe UI** di seluruh antarmuka dengan skala ukuran yang konsisten.

---

## Tech Stack

**Core Technology & Infrastructure**
- **Bahasa Pemrograman**: C# (`.NET Framework 4.8`)
- **Tampilan Antarmuka**: Windows Forms (WinForms)
- **Database Engine**: MySQL Server
- **Database Driver**: ADO.NET Provider (`MySql.Data` `v9.7.0`)

**Third-Party Libraries (NuGet Packages)**
- **ZXing.Net** (`v0.16.9`): Generator dan pembaca QR Code secara terprogram.
- **AForge.Video & AForge.Video.DirectShow** (`v2.2.5`): Antarmuka kontrol dan capture stream webcam perangkat keras secara asinkron.
- **BouncyCastle.Cryptography** (`v2.6.2`): Menyediakan algoritma pengolahan data kriptografis terenkripsi.

---

## Requirements

Untuk menjalankan, memodifikasi, atau melakukan kompilasi proyek ini, pastikan komputer Anda memenuhi syarat minimum berikut:
- **Sistem Operasi**: Windows 10/11
- **IDE**: Visual Studio 2022 (dengan modul *Desktop development with .NET* terpasang)
- **Runtime**: .NET Framework 4.8 SDK & Runtime
- **Database**: MySQL Server (menggunakan XAMPP, Laragon, Docker, atau instalasi native)

---

## Local Setup

Ikuti langkah-langkah di bawah ini untuk memasang proyek ini di lingkungan lokal Anda:

```bash
# 1) Clone repository ke komputer lokal Anda
git clone https://github.com/pratama1246/SistemPenggajianKaryawan.git
cd SistemPenggajianKaryawan

# 2) Buat database baru di MySQL
# Nyalakan MySQL Server Anda, lalu buka MySQL client (CLI, phpMyAdmin, DBeaver, dll.) dan buat schema database:
CREATE DATABASE penggajian;

# 3) Konfigurasi Database Connection (Opsional)
# Koneksi default adalah server=localhost, database=penggajian, user=root, password=kosong.
# Jika kredensial database Anda berbeda, Anda bisa menyesuaikan string koneksi di file:
# SistemPenggajianKaryawan/Konfigurasi/Koneksi.cs baris 13
```

Setelah database dibuat, Anda **tidak perlu mengimpor file SQL secara manual**. Aplikasi ini dilengkapi dengan mekanisme inisialisasi mandiri (auto-seeder). Saat aplikasi pertama kali dijalankan dari Visual Studio, kelas [DatabaseSeeder](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/Konfigurasi/DatabaseSeeder.cs) secara otomatis akan:
1. Membuat seluruh tabel yang diperlukan jika belum ada (`CREATE TABLE IF NOT EXISTS`).
2. Melakukan migrasi/penyesuaian tipe kolom yang dibutuhkan secara asinkron.
3. Menyuntikkan (seeding) contoh data master karyawan, komponen gaji standar, rekam absensi Mei 2026, dan akun pengguna default untuk pengujian.

---

## Default Testing Credentials

Setelah program berhasil diluncurkan pertama kali, Anda dapat login menggunakan kredensial pengujian bawaan berikut:

| Peran (Role) | Username | Password | Deskripsi / Kegunaan |
|---|---|---|---|
| **Administrator** | `admin` | `admin123` | Mengelola data karyawan, master user login, dan preview kartu QR. |
| **HRD** | `hrd` | `hrd123` | Mengatur komponen gaji, mengolah absen manual, memproses gaji, rekap laporan. |
| **Kiosk Mode** | `kiosk` | `kiosk123` | Membuka layar kiosk scanner webcam untuk proses scan kartu QR karyawan. |
| **Karyawan** | `karyawan` | `karyawan123` | Melihat data absensi personal, dashboard kehadiran, dan cetak slip gaji. |

---

## Database Configuration & Schema

Proyek ini mendefinisikan skema basis data relasional yang terdiri atas beberapa tabel utama:

1. **`karyawan`**: Menyimpan biodata, jabatan, tipe kontrak, dan gaji pokok karyawan.
2. **`users`**: Menyimpan kredensial login, peran akses (Admin/HRD/Karyawan/Kiosk), dan relasi kunci asing ke tabel karyawan.
3. **`absensi`**: Mencatat log harian presensi berupa tanggal, jam masuk, jam keluar, status (Hadir/Izin/Sakit/Alpha), dan keterangan tambahan.
4. **`konfigurasi_absensi`**: Konfigurasi parameter operasional shift jam kerja default beserta batas toleransi menit telat.
5. **`komponen_gaji`**: Menyimpan definisi tunjangan penambah atau potongan pengurang gaji.
6. **`penggajian`**: Menyimpan riwayat hitung gaji bulanan bersih karyawan yang diproses oleh pihak HRD.

Koneksi relasi antar tabel dipetakan menggunakan *Foreign Keys* dengan aksi cascading tertentu demi menjaga integritas data relasional.

---

## Coding Conventions

Seluruh kode yang ditulis dalam proyek ini wajib mematuhi standar pengembangan yang terdokumentasi pada [AGENTS.md](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/AGENTS.md):

### 📁 Struktur Folder Proyek
- `Konfigurasi/`: Berisi infrastruktur database, kelas abstrak [Konfigurasi](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/Konfigurasi/Konfigurasi.cs), implementasi konkret [Koneksi](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/Konfigurasi/Koneksi.cs), dan class penyimpanan session [UserSession](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/Konfigurasi/UserSession.cs).
- `Model/`: Berisi cetak biru data murni (property & constructor) seperti class warisan [BaseKaryawan](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/Model/BaseKaryawan.cs). Tidak diperbolehkan ada logika SQL/Query database di folder ini.
- `Service/`: Semua pemrosesan query SQL ADO.NET mentah dan logika bisnis didefinisikan di sini (misal: [Karyawan_serv](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/Service/Karyawan_serv.cs), [Absensi_serv](file:///D:/Coder%20Project/Praktikum%20PBO/SistemPenggajianKaryawan/SistemPenggajianKaryawan/Service/Absensi_serv.cs)).
- `(Root)`: Semua class form Windows Forms ditempatkan langsung di tingkat root proyek untuk menjaga kesederhanaan kompilasi praktikum.

### 🏷️ Naming Convention
- **Nama Kelas**: Menggunakan gaya `PascalCase` kata benda (e.g. `KaryawanTetap`, `FormAbsensi`).
- **Nama Service**: Menggunakan format `PascalCase` dengan akhiran `_serv` (e.g. `Gaji_serv`).
- **Variabel Model**: Menggunakan format property `snake_case` publik dengan backing field privat berawalan garis bawah (e.g. `_kode_karyawan` & `kode_karyawan`).
- **Komponen Form**: Menggunakan akhiran singkatan tipe kontrol (e.g. `simpan_btn`, `cari_txt`, `absensi_dgv`, `bulan_cmb`).

---

## How to Run

1. Buka berkas solusi `SistemPenggajianKaryawan.slnx` atau berkas proyek `SistemPenggajianKaryawan.csproj` menggunakan Visual Studio 2022.
2. Tunggu Visual Studio memulihkan (restore) seluruh pustaka NuGet secara otomatis.
3. Pastikan MySQL Server Anda dalam kondisi aktif dan database `penggajian` sudah dibuat.
4. Klik tombol **Start (F5)** pada Visual Studio untuk memulai kompilasi dan menjalankan program.
5. Pertama kali diluncurkan, layar Splash Screen akan menginisialisasi tabel database dan menyuntikkan data seed secara otomatis, kemudian memunculkan Form Login.

---

## 👥 Team

Proyek praktikum ini dikerjakan oleh kelompok mahasiswa Politeknik Negeri Cilacap:
- **[Nama Anda]** - Developer Utama / Programmer
- **[Nama Rekan 1]** - Database Engineer / Analis Sistem
- **[Nama Rekan 2]** - UI/UX Designer / Penguji Sistem

Dibangun sebagai proyek akhir praktikum pemrograman desktop di Politeknik Negeri Cilacap, Jurusan Teknik Informatika.

**Kelas**: Teknik Informatika [Kelas Anda]  
**Mata Kuliah**: Praktikum Pemrograman Berorientasi Objek (PBO)  
**Institusi**: Politeknik Negeri Cilacap  

---

## License

Proyek praktikum ini dilisensikan di bawah ketentuan [MIT License](LICENSE).

---

## ⚠️ Disclaimer

Seluruh logo, informasi nama, dan instansi yang digunakan di dalam data sampel maupun demo visual program ini murni ditujukan untuk pemenuhan tugas akademik praktikum perkuliahan Pemrograman Berorientasi Objek (PBO) Politeknik Negeri Cilacap. Tidak ada maksud komersialisasi maupun pelanggaran hak cipta.

---

[![GitHub](https://img.shields.io/badge/GitHub-pratama1246-black?logo=github)](https://github.com/pratama1246)
