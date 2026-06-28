# DESIGN.md — Sistem Penggajian Karyawan

> Dokumen ini adalah **sumber kebenaran visual** untuk semua AI coding agent yang mengerjakan UI project ini.
> Baca sebelum menulis satu komponen pun. Berpasangan dengan `AGENTS.md` sebagai sumber kebenaran teknis.

---

## Overview

Aplikasi desktop WinForms untuk sistem penggajian karyawan Politeknik Negeri Cilacap.
Vibe keseluruhan: **profesional, terang, bersih** — terinspirasi dari warna logo PNC.
Bukan meniru web app. Bukan flat design generik. Konsisten dari splash sampai slip gaji.

Identitas visual dibangun dari tiga warna utama logo PNC:
- Biru langit (gedung kiri) sebagai primary
- Abu terang (gedung tengah) sebagai neutral
- Amber/oranye (gedung kanan) sebagai accent

---

## Color Tokens

### Primary Palette

| Token | Hex | Penggunaan |
|---|---|---|
| `primary` | `#5BC8F5` | Tombol utama, highlight aktif, accent bar, border fokus |
| `primary-dark` | `#1E90FF` | Tombol simpan, hover state primary |
| `accent` | `#F5A623` | Label matkul/tahun, badge warning, elemen highlight kedua |
| `accent-dark` | `#D4891A` | Hover state accent |

### Neutral Palette

| Token | Hex | Penggunaan |
|---|---|---|
| `bg-base` | `#F4F6F9` | Background utama semua form |
| `bg-surface` | `#FFFFFF` | Panel kiri/sidebar, groupbox, card area, row aktivitas |
| `bg-elevated` | `#E2E8F0` | Input background saat hover, divider line |
| `bg-input` | `#FFFFFF` | Background TextBox, ComboBox |
| `border` | `#CBD5E1` | Border subtle antar elemen |
| `neutral` | `#718096` | Teks sekunder terang |

### Text Colors

| Token | Hex | Penggunaan |
|---|---|---|
| `text-primary` | `#2D3748` | Judul, heading, teks utama |
| `text-secondary` | `#718096` | Label field, subtitle, keterangan |
| `text-muted` | `#A0AEC0` | Placeholder, versi, teks tidak aktif |
| `text-on-primary` | `#1A1A1A` | Teks di atas tombol primary |

### Semantic Colors

| Token | Hex | Penggunaan |
|---|---|---|
| `success` | `#4CAF50` | Notifikasi berhasil |
| `error` | `#CD5C5C` | Tombol hapus, pesan error, validasi gagal |
| `warning` | `#F5A623` | Peringatan, konfirmasi |
| `info` | `#5BC8F5` | Informasi netral |

### DataGridView Specific

| Token | Hex | Penggunaan |
|---|---|---|
| `dgv-header-bg` | `#4682B4` | Header DataGridView |
| `dgv-header-fg` | `#FFFFFF` | Teks header DataGridView |
| `dgv-row-even` | `#F0F8FF` | Baris genap (Alice Blue) |
| `dgv-row-odd` | `#B0C4DE` | Baris ganjil (Light Steel Blue) |

---

## Typography

Satu font family di seluruh aplikasi. Tidak ada pengecualian.

| Level | Font | Size | Weight | Hex | Penggunaan |
|---|---|---|---|---|---|
| `display` | Segoe UI | 18pt | Bold | `#FFFFFF` | Judul splash, heading form login |
| `heading` | Segoe UI | 13-14pt | Bold | `#FFFFFF` | Nama app, judul section utama |
| `subheading` | Segoe UI | 11pt | Regular | `#5BC8F5` | Nama kampus, subtitle form |
| `body` | Segoe UI | 9-10pt | Regular | `#B0B0B0` | Label field, teks biasa |
| `caption` | Segoe UI | 8pt | Regular | `#F5A623` | Matkul/tahun, badge kecil |
| `micro` | Segoe UI | 7pt | Regular | `#707070` | Versi app, copyright |

Set font di level Form (`this.Font = new Font("Segoe UI", 9F)`), bukan per kontrol.
Override hanya untuk level display/heading yang butuh ukuran berbeda.

---

## Spacing

Base unit: **8px**. Semua jarak adalah kelipatan 8 atau turunannya (4px untuk kasus kecil).

| Token | Value | Penggunaan |
|---|---|---|
| `spacing-xs` | 4px | Jarak antar inline element, icon ke teks |
| `spacing-sm` | 8px | Margin minimum antar kontrol |
| `spacing-md` | 16px | Padding dalam Panel/GroupBox |
| `spacing-lg` | 24px | Jarak antar section |
| `spacing-xl` | 40px | Margin tepi form ke konten |

---

## Components

### Accent Bar

Garis horizontal tipis di bagian paling atas setiap form. Wajib ada di semua form.

```csharp
// Selalu tambahkan ini di setiap form
accentPanel.Location  = new Point(0, 0);
accentPanel.Size      = new Size(lebarForm, 4);
accentPanel.BackColor = Color.FromArgb(91, 200, 245); // primary #5BC8F5
```

Fungsi: penanda visual konsistensi, "cap" bahwa ini satu keluarga app.

---

### Button

| Jenis | BackColor | ForeColor | FlatStyle | Penggunaan |
|---|---|---|---|---|
| Primary | `#5BC8F5` | `#1A1A1A` | Flat, BorderSize=0 | Login, aksi utama |
| Simpan | `#1E90FF` | `#FFFFFF` | Flat, BorderSize=0 | Simpan data |
| Hapus | `#CD5C5C` | `#FFFFFF` | Flat, BorderSize=0 | Hapus data |
| Batal/Tutup | `#3A3A3A` | `#B0B0B0` | Flat, BorderSize=1 | Batal, kembali |

```csharp
// Contoh tombol Simpan
simpan_btn.BackColor = Color.FromArgb(30, 144, 255);
simpan_btn.ForeColor = Color.White;
simpan_btn.FlatStyle = FlatStyle.Flat;
simpan_btn.FlatAppearance.BorderSize = 0;
simpan_btn.Font      = new Font("Segoe UI", 9.5F, FontStyle.Bold);
simpan_btn.Size      = new Size(90, 30);
simpan_btn.Cursor    = Cursors.Hand;
```

Urutan tombol dalam form CRUD: **Simpan → Hapus → Batal** (kiri ke kanan).

---

### TextBox

```csharp
txt.BackColor   = Color.White;                    // bg-input
txt.ForeColor   = Color.FromArgb(45, 55, 72);    // text-primary
txt.BorderStyle = BorderStyle.FixedSingle;
txt.Font        = new Font("Segoe UI", 10F);
txt.Size        = new Size(lebarInput, 26);
```

Password field wajib `PasswordChar = '●'`.

---

### ComboBox

```csharp
cmb.BackColor   = Color.White;
cmb.ForeColor   = Color.FromArgb(45, 55, 72);
cmb.FlatStyle   = FlatStyle.Flat;
cmb.Font        = new Font("Segoe UI", 9F);
```

---

### DataGridView

Konfigurasi wajib di semua DataGridView, set di `Form_Load`:

```csharp
dgv.ReadOnly                          = true;
dgv.SelectionMode                     = DataGridViewSelectionMode.FullRowSelect;
dgv.MultiSelect                       = false;
dgv.AllowUserToAddRows                = false;
dgv.AllowUserToDeleteRows             = false;
dgv.AutoSizeColumnsMode               = DataGridViewAutoSizeColumnsMode.Fill;
dgv.EnableHeadersVisualStyles         = false;
dgv.BackgroundColor                   = Color.FromArgb(244, 246, 249); // bg-base
dgv.GridColor                         = Color.FromArgb(226, 232, 240); // border
dgv.BorderStyle                       = BorderStyle.None;

dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(70, 130, 180); // #4682B4
dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
dgv.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 9, FontStyle.Bold);
dgv.ColumnHeadersHeight                     = 32;
```

Alternating row color via method `warnaiBaris()` — wajib dipanggil setiap refresh grid:

```csharp
void warnaiBaris(DataGridView dgv)
{
    foreach (DataGridViewRow row in dgv.Rows)
        foreach (DataGridViewCell cell in row.Cells)
            cell.Style.BackColor = row.Index % 2 == 0
                ? Color.FromArgb(240, 248, 255)  // #F0F8FF Alice Blue
                : Color.FromArgb(176, 196, 222); // #B0C4DE Light Steel Blue
}
```

---

### Panel (Left/Right Split Layout)

Form CRUD menggunakan layout dua panel: kiri input (40%), kanan grid (60%).

```csharp
// Panel kiri
panel_left.BackColor = Color.White;                    // bg-surface

// Panel kanan
panel_right.BackColor = Color.FromArgb(244, 246, 249); // bg-base
```

---

### ProgressBar (Splash Screen)

```csharp
loading_bar.Style     = ProgressBarStyle.Continuous;
loading_bar.ForeColor = Color.FromArgb(91, 200, 245); // primary
loading_bar.Size      = new Size(300, 6);
```

---

### Label Error / Validasi

```csharp
error_lbl.ForeColor = Color.FromArgb(220, 80, 80); // lebih soft dari pure red
error_lbl.Font      = new Font("Segoe UI", 8.5F);
error_lbl.Visible   = false; // default hidden, tampil saat ada error
```

---

## Layout

### Form CRUD Standar

```
┌─────────────────────────────────────────────────────────────┐
│ [AccentBar #5BC8F5, 4px]                                    │
├──────────────────────┬──────────────────────────────────────┤
│  Panel Kiri (40%)    │  Panel Kanan (60%)                   │
│  bg: #FFFFFF         │  bg: #F4F6F9                         │
│                      │                                      │
│  Kode  : [TextBox]   │  [Cari: ___________________]         │
│  Nama  : [TextBox]   │                                      │
│  Jenis : [ComboBox]  │  ┌──────────────────────────────┐   │
│                      │  │  DataGridView                │   │
│  [Simpan][Hapus]     │  │  Header: #4682B4             │   │
│  [Batal]             │  │  Row even: #F0F8FF           │   │
│                      │  │  Row odd:  #B0C4DE           │   │
│                      │  └──────────────────────────────┘   │
└──────────────────────┴──────────────────────────────────────┘
```

### Form Login

```
┌─────────────────────────────────────────────────────────────┐
│ [AccentBar #5BC8F5, 4px]                                    │
├─────────────────────┬───────────────────────────────────────┤
│  Panel Kiri (41%)   │  Panel Kanan (59%)                    │
│  bg: #FFFFFF        │  bg: #F4F6F9                          │
│                     │                                       │
│  [Logo PNC]         │  Selamat Datang   (18pt Bold #2D3748) │
│                     │  subtitle         (9pt #718096)       │
│  Sistem Penggajian  │                                       │
│  (13pt Bold #2D3748)│  Username  [___________________]      │
│                     │  Password  [___________________]      │
│  Politeknik Negeri  │                                       │
│  Cilacap (#5BC8F5)  │  [error label, hidden by default]    │
│                     │                                       │
│                     │  [  Masuk  ]  (primary btn, full)    │
│                     │                                       │
│                     │                          v1.0.0      │
└─────────────────────┴───────────────────────────────────────┘
```

### Form Splash

```
┌──────────────────────────────────┐
│ [AccentBar #5BC8F5, 4px]         │
│                                  │
│         [Logo PNC 90x90]         │
│                                  │
│   Sistem Penggajian Karyawan     │  14pt Bold #2D3748
│     Politeknik Negeri Cilacap    │  10pt #5BC8F5
│  Pemrograman Berorientasi Objek  │  8pt #F5A623
│                                  │
│       [====== bar 300px]         │  6px, #5BC8F5
│    Menginisialisasi aplikasi...  │  8pt #707070
│                                  │
│                         v1.0.0   │  7pt #444
└──────────────────────────────────┘
  520x340px, FormBorderStyle.None
```

---

## Form Behavior Rules

| Situasi | Yang Harus Dilakukan |
|---|---|
| `Form_Load` | Panggil `bersihkan()` lalu `tampilGrid()` |
| Klik baris DGV | Isi semua input dari data baris, fokus ke field utama |
| Simpan/hapus berhasil | `bersihkan()` lalu `tampilGrid()` |
| TextBox pencarian berubah | Langsung `tampilGrid()` realtime |
| Sebelum hapus | Wajib `MessageBox.YesNo` dengan ikon `Question` |
| Error validasi | Tampilkan `error_lbl`, jangan `MessageBox` untuk field kosong |
| Operasi DB gagal | `MessageBox.Show` singkat dan jelas |
| Form butuh role tertentu | Cek `UserSession.role` di `Form_Load`, close kalau tidak sesuai |

---

## Do and Don't

### Do
- Selalu tambahkan `accentPanel` di setiap form baru
- Gunakan `warnaiBaris()` setiap kali DataGridView di-refresh
- Set `Cursor = Cursors.Hand` di semua tombol
- Set `FlatStyle = FlatStyle.Flat` + `BorderSize = 0` di tombol primary
- Konsisten: `panel_left` (putih/bg-surface) selalu lebih terang dari `panel_right` (abu-abu/bg-base)

### Don't
- Jangan pakai `BackColor = SystemColors.*` — override semua dengan hex yang sudah ditentukan
- Jangan beda-bedain font antar form — semua Segoe UI
- Jangan buat tombol tanpa Cursor.Hand
- Jangan skip `accentPanel` dengan alasan form kecil
- Jangan pakai warna lain di luar token yang sudah didefinisikan di atas
- Jangan pakai `FormBorderStyle.Sizable` kecuali benar-benar perlu

---

## Form Size Reference

| Form | Size | BorderStyle |
|---|---|---|
| FormSplash | 520 x 340 | None (no border) |
| FormLogin | 780 x 460 | FixedSingle |
| FormKaryawan | 900 x 540 | FixedSingle |
| FormAbsensi | 900 x 540 | FixedSingle |
| FormProsesGaji | 860 x 520 | FixedSingle |
| FormSlipGaji | 640 x 500 | FixedSingle |
| FormDashboard* | 860 x 520 | FixedSingle |

---

*Dokumen ini diperbarui setiap ada keputusan visual baru yang disepakati. Jangan implement warna atau ukuran baru tanpa menambahkannya ke sini terlebih dahulu.*
