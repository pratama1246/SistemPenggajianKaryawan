# AGENTS.md — Panduan Development: Sistem Penggajian Karyawan

> Dokumen ini adalah **sumber kebenaran utama** untuk semua AI coding agent yang terlibat dalam pengembangan project ini.
> Baca seluruh dokumen sebelum menulis satu baris kode pun.

---

## 1. Project Overview

| Atribut | Detail |
|---|---|
| Nama Project | Sistem Informasi Penggajian Karyawan |
| Bahasa | C# (.NET Framework 4.8) |
| UI Framework | Windows Forms (WinForms) |
| Database | MySQL (via `MySql.Data` — ADO.NET, tanpa ORM) |
| Tujuan | Praktikum mata kuliah Pemrograman Berorientasi Objek |

**Apa yang dibangun:** Aplikasi desktop untuk mengelola data karyawan, absensi bulanan, perhitungan gaji otomatis berdasarkan jenis karyawan (Tetap/Kontrak/Harian), dan cetak slip gaji. Tiga role pengguna: Admin, HRD, Karyawan.

---

## 2. Source of Truth

### Referensi utama (urutan prioritas):

1. **`AGENTS.md` ini** — aturan gaya, struktur, dan pola kode yang wajib diikuti.
2. **File yang sudah ada di project ini** — jika ada file yang sudah dibuat, ikuti gaya dan polanya secara konsisten.
3. **Dokumen Perencanaan Project** (`Perencanaan_Project_Penggajian.docx`) — scope dan keputusan arsitektur.

### Prinsip dasar:

- Jika ragu antara "cara baru yang lebih modern" vs "pola yang sudah ditetapkan di dokumen ini" → **ikuti dokumen ini**.
- Jika tidak ada preseden → gunakan pendekatan **paling sederhana** yang konsisten dengan pola yang ada.
- Jangan introduce pattern baru tanpa alasan teknis yang kuat dan eksplisit.
- Skala project ini adalah praktikum. Kesederhanaan dan konsistensi lebih penting dari kesempurnaan arsitektur.

---

## 3. Struktur Folder

```
PenggajianApp/
├── Konfigurasi/
│   ├── Konfigurasi.cs       ← abstract class, kontrak koneksi DB
│   ├── Koneksi.cs           ← implementasi MySQL konkret
│   └── UserSession.cs       ← static class untuk simpan state login
├── Model/
│   ├── BaseKaryawan.cs      ← abstract class (OOP hierarchy)
│   ├── KaryawanTetap.cs
│   ├── KaryawanKontrak.cs
│   ├── KaryawanHarian.cs
│   ├── KomponenGaji.cs
│   └── DataAbsensi.cs
├── Service/
│   ├── Auth_serv.cs         ← login, hash password
│   ├── Karyawan_serv.cs     ← CRUD tbl_Karyawan
│   ├── Absensi_serv.cs      ← CRUD tbl_Absensi
│   └── Gaji_serv.cs         ← hitung gaji + factory method
└── (root namespace)
    ├── FormLogin.cs
    ├── FormDashboardAdmin.cs
    ├── FormDashboardHRD.cs
    ├── FormDashboardKaryawan.cs
    ├── FormKaryawan.cs
    ├── FormAbsensi.cs
    ├── FormProsesGaji.cs
    └── FormSlipGaji.cs
```

### Aturan folder:

- Folder `Model/` → hanya class data (field, property, constructor). **Tidak ada query DB di sini.**
- Folder `Service/` → semua query DB dan logika bisnis. Satu service per entitas utama.
- Folder `Konfigurasi/` → infrastruktur: koneksi DB dan session. Bukan untuk logika bisnis.
- Form berada di **root namespace**, bukan di subfolder `Forms/`.
- **Tidak ada folder tambahan** seperti `Repositories/`, `Helpers/`, `Utils/`, `ViewModels/`, dll.

---

## 4. Naming Convention

Gunakan konvensi berikut secara konsisten di seluruh project. Jangan campur gaya.

### Class dan File

| Tipe | Konvensi | Contoh |
|---|---|---|
| Model class | PascalCase, noun | `Karyawan`, `KomponenGaji` |
| Service class | PascalCase + `_serv` | `Karyawan_serv`, `Gaji_serv` |
| Form class | PascalCase, prefix `Form` | `FormKaryawan`, `FormLogin` |
| Abstract class | PascalCase, noun | `BaseKaryawan`, `Konfigurasi` |
| Static class | PascalCase, noun | `UserSession` |

### Field dan Property di Model

```csharp
// BENAR — private field snake_case dengan underscore prefix, property snake_case
private string _kode_karyawan;
public string kode_karyawan
{
    get { return _kode_karyawan; }
    set { _kode_karyawan = value; }
}

// SALAH — jangan pakai PascalCase atau auto-property
private string KodeKaryawan;
public string KodeKaryawan { get; set; }
```

### Field di Service

```csharp
// BENAR — internal access modifier, snake_case
internal string kode_karyawan;
internal string nama_karyawan;
internal decimal gaji_pokok;
```

### Kontrol Form (WinForms)

| Tipe Kontrol | Konvensi | Contoh |
|---|---|---|
| TextBox | `nama_txt` | `kode_txt`, `nama_txt`, `cari_txt` |
| Button | `aksi_btn` | `simpan_btn`, `hapus_btn`, `batal_btn` |
| DataGridView | `entitas_dgv` | `karyawan_dgv`, `absensi_dgv` |
| ComboBox | `field_cmb` | `jenis_cmb`, `bulan_cmb` |
| Label | `field_lbl` | `kode_lbl`, `total_lbl` |
| NumericUpDown | `field_num` | `tahun_num`, `hadir_num` |

> Pilih satu gaya dan konsisten dalam satu form. Jangan campur `kode_txt` dan `kodeTxt` di form yang sama.

### Method di Service

```csharp
// Nama method yang digunakan di seluruh service class project ini
public bool jikaAda(string kode) { }
public int Save() { }
public DataTable viewAll() { }
public int update(string kodeLama) { }
public int delete(string kode) { }
public DataTable search(string keyword) { }
public string createCode() { }
```

---

## 5. Code Style

### Access Modifier

```csharp
// Model dan Service: internal
internal class Karyawan { }
internal class Karyawan_serv { }

// Form: public partial (di-generate WinForms designer)
public partial class FormKaryawan : Form { }

// Abstract class Konfigurasi: tanpa modifier (internal by default)
abstract class Konfigurasi { }
internal class Koneksi : Konfigurasi { }
```

### Constructor

```csharp
// Model: inisialisasi semua field ke nilai default
public Karyawan()
{
    _kode_karyawan = "";
    _nama_karyawan = "";
    _gaji_pokok    = 0;
}

// Service: inisialisasi Koneksi dan string Query
public Karyawan_serv()
{
    server = new Koneksi();
    Query  = "";
}
```

### Exception Handling

```csharp
// Pola standar project ini: try-catch kosong, return -1 untuk gagal
public int Save()
{
    int nilai = -1;
    try
    {
        nilai = server.eksekusiNonQueryParam(query, param);
    }
    catch (Exception) { }
    return nilai;
}
```

> Jangan tambahkan logging kompleks atau custom exception. Cukup return `-1` untuk gagal, `> 0` untuk berhasil.

### Query: Selalu Gunakan Parameterized Query

```csharp
// SALAH — string concatenation rentan SQL injection
Query = "SELECT * FROM tbl_Karyawan WHERE nik = '" + nik + "'";

// BENAR — parameterized query via Dictionary
string query = "SELECT * FROM tbl_Karyawan WHERE nik = @nik";
var param = new Dictionary<string, object> { { "@nik", nik } };
DataTable dt = server.eksekusiQueryParam(query, param);
```

> **Tidak ada pengecualian untuk aturan ini.** Semua query yang melibatkan input user wajib pakai parameterized query.

---

## 6. Pola Kode yang Digunakan di Project Ini

### 6.1 Pola Koneksi Database

`Konfigurasi.cs` adalah abstract class yang mendefinisikan dua method abstract:

```csharp
// Konfigurasi/Konfigurasi.cs
abstract class Konfigurasi
{
    public abstract int eksekusiNonQuery(string query);
    public abstract DataTable eksekusiQuery(string query);
}
```

`Koneksi.cs` mengimplementasikan abstract class tersebut dan menambahkan dua method berparameter:

```csharp
// Konfigurasi/Koneksi.cs
internal class Koneksi : Konfigurasi
{
    MySqlConnection _connection;
    MySqlCommand    _command;
    MySqlDataAdapter _adapter;
    string _link = "server=localhost;database=penggajian;uid=root;pwd=;";

    public Koneksi()
    {
        _connection = new MySqlConnection(_link);
        _command    = new MySqlCommand();
        _command.Connection = _connection;
        _adapter    = new MySqlDataAdapter(_command);
    }

    void bukaKoneksi()
    {
        if (_connection.State != ConnectionState.Open)
            _connection.Open();
    }

    void tutupKoneksi()
    {
        if (_connection.State == ConnectionState.Open)
            _connection.Close();
    }

    // Method dasar (tanpa parameter) — tetap ada untuk backward compatibility
    public override int eksekusiNonQuery(string query)
    {
        int nilai = -1;
        try
        {
            bukaKoneksi();
            _command.CommandText = query;
            nilai = _command.ExecuteNonQuery();
        }
        catch (Exception) { }
        finally { tutupKoneksi(); }
        return nilai;
    }

    public override DataTable eksekusiQuery(string query)
    {
        DataTable nilai = new DataTable();
        try
        {
            bukaKoneksi();
            _command.CommandText = query;
            _adapter.SelectCommand = _command;
            _adapter.Fill(nilai);
        }
        catch (Exception) { }
        finally { tutupKoneksi(); }
        return nilai;
    }

    // Method berparameter — GUNAKAN INI untuk semua query dengan input user
    public DataTable eksekusiQueryParam(string query, Dictionary<string, object> parameters)
    {
        DataTable hasil = new DataTable();
        try
        {
            bukaKoneksi();
            _command.CommandText = query;
            _command.Parameters.Clear();
            foreach (var p in parameters)
                _command.Parameters.AddWithValue(p.Key, p.Value);
            _adapter.SelectCommand = _command;
            _adapter.Fill(hasil);
        }
        catch (Exception) { }
        finally
        {
            _command.Parameters.Clear();
            tutupKoneksi();
        }
        return hasil;
    }

    public int eksekusiNonQueryParam(string query, Dictionary<string, object> parameters)
    {
        int nilai = -1;
        try
        {
            bukaKoneksi();
            _command.CommandText = query;
            _command.Parameters.Clear();
            foreach (var p in parameters)
                _command.Parameters.AddWithValue(p.Key, p.Value);
            nilai = _command.ExecuteNonQuery();
        }
        catch (Exception) { }
        finally
        {
            _command.Parameters.Clear();
            tutupKoneksi();
        }
        return nilai;
    }
}
```

### 6.2 Pola Service Class

Setiap entitas utama punya satu service class. Strukturnya selalu seperti ini:

```csharp
internal class Karyawan_serv
{
    // Field internal — diisi dari Form sebelum Save/update
    internal string  kode_karyawan;
    internal string  nama_karyawan;
    internal string  jenis_karyawan;
    internal decimal gaji_pokok;

    Koneksi server;
    string  Query;

    public Karyawan_serv()
    {
        server = new Koneksi();
        Query  = "";
    }

    public bool jikaAda(string kode)
    {
        string q = "SELECT * FROM tbl_Karyawan WHERE kode_karyawan = @kode";
        var p = new Dictionary<string, object> { { "@kode", kode } };
        return server.eksekusiQueryParam(q, p).Rows.Count > 0;
    }

    public int Save()
    {
        int nilai = -1;
        string q = "INSERT INTO tbl_Karyawan (kode_karyawan, nama_karyawan, jenis_karyawan, gaji_pokok) " +
                   "VALUES (@kode, @nama, @jenis, @gaji)";
        var p = new Dictionary<string, object>
        {
            { "@kode",  kode_karyawan  },
            { "@nama",  nama_karyawan  },
            { "@jenis", jenis_karyawan },
            { "@gaji",  gaji_pokok     }
        };
        try { nilai = server.eksekusiNonQueryParam(q, p); }
        catch (Exception) { }
        return nilai;
    }

    public DataTable viewAll()
    {
        return server.eksekusiQuery("SELECT * FROM tbl_Karyawan");
    }

    public int update(string kodeLama)
    {
        int nilai = -1;
        string q = "UPDATE tbl_Karyawan SET nama_karyawan = @nama, jenis_karyawan = @jenis, " +
                   "gaji_pokok = @gaji WHERE kode_karyawan = @kode";
        var p = new Dictionary<string, object>
        {
            { "@nama",  nama_karyawan  },
            { "@jenis", jenis_karyawan },
            { "@gaji",  gaji_pokok     },
            { "@kode",  kodeLama       }
        };
        try { nilai = server.eksekusiNonQueryParam(q, p); }
        catch (Exception) { }
        return nilai;
    }

    public int delete(string kode)
    {
        int nilai = -1;
        string q = "DELETE FROM tbl_Karyawan WHERE kode_karyawan = @kode";
        var p = new Dictionary<string, object> { { "@kode", kode } };
        try { nilai = server.eksekusiNonQueryParam(q, p); }
        catch (Exception) { }
        return nilai;
    }

    public DataTable search(string keyword)
    {
        string q = "SELECT * FROM tbl_Karyawan WHERE nama_karyawan LIKE @keyword " +
                   "OR kode_karyawan LIKE @keyword";
        var p = new Dictionary<string, object> { { "@keyword", "%" + keyword + "%" } };
        return server.eksekusiQueryParam(q, p);
    }
}
```

### 6.3 Pola Form ↔ Service

Form tidak boleh berisi query SQL. Semua operasi data dilakukan melalui service.

```csharp
public partial class FormKaryawan : Form
{
    Karyawan_serv karyawan = new Karyawan_serv();

    private void FormKaryawan_Load(object sender, EventArgs e)
    {
        // Cek role sebelum apapun
        if (UserSession.role != "HRD" && UserSession.role != "Admin")
        {
            MessageBox.Show("Akses ditolak.");
            this.Close();
            return;
        }
        bersihkan();
        tampilGrid();
    }

    void bersihkan()
    {
        kode_txt.Text = "";      // atau panggil createCode() jika ada
        nama_txt.Clear();
        jenis_cmb.SelectedIndex = 0;
        nama_txt.Focus();
    }

    void tampilGrid()
    {
        karyawan_dgv.DataSource = cari_txt.Text.Length == 0
            ? karyawan.viewAll()
            : karyawan.search(cari_txt.Text);

        warnaiBaris(karyawan_dgv);
    }

    void warnaiBaris(DataGridView dgv)
    {
        foreach (DataGridViewRow row in dgv.Rows)
            foreach (DataGridViewCell cell in row.Cells)
                cell.Style.BackColor = row.Index % 2 == 0
                    ? Color.AliceBlue
                    : Color.LightSteelBlue;
    }

    private void karyawan_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex > -1)
        {
            DataGridViewRow baris = karyawan_dgv.Rows[e.RowIndex];
            kode_txt.Text  = baris.Cells[0].Value.ToString();
            nama_txt.Text  = baris.Cells[1].Value.ToString();
            jenis_cmb.Text = baris.Cells[2].Value.ToString();
            nama_txt.Focus();
            nama_txt.SelectAll();
        }
    }

    private void simpan_btn_Click(object sender, EventArgs e)
    {
        if (kode_txt.Text == "" || nama_txt.Text == "")
        {
            MessageBox.Show("Semua field wajib diisi.");
            return;
        }

        if (!karyawan.jikaAda(kode_txt.Text))
        {
            karyawan.kode_karyawan  = kode_txt.Text;
            karyawan.nama_karyawan  = nama_txt.Text;
            karyawan.jenis_karyawan = jenis_cmb.Text;

            if (karyawan.Save() > 0)
            {
                MessageBox.Show("Data berhasil disimpan.");
                bersihkan();
                tampilGrid();
            }
            else MessageBox.Show("Data gagal disimpan.");
        }
        else
        {
            if (MessageBox.Show("Yakin ingin mengubah data ini?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                karyawan.kode_karyawan  = kode_txt.Text;
                karyawan.nama_karyawan  = nama_txt.Text;
                karyawan.jenis_karyawan = jenis_cmb.Text;

                if (karyawan.update(kode_txt.Text) > 0)
                {
                    MessageBox.Show("Data berhasil diubah.");
                    bersihkan();
                    tampilGrid();
                }
                else MessageBox.Show("Data gagal diubah.");
            }
        }
    }

    private void hapus_btn_Click(object sender, EventArgs e)
    {
        if (!karyawan.jikaAda(kode_txt.Text))
        {
            MessageBox.Show("Data tidak ditemukan.");
            return;
        }
        if (MessageBox.Show("Yakin ingin menghapus data ini?", "Hapus Data",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            if (karyawan.delete(kode_txt.Text) > 0)
            {
                MessageBox.Show("Data berhasil dihapus.");
                bersihkan();
                tampilGrid();
            }
            else MessageBox.Show("Data gagal dihapus.");
        }
    }

    private void cari_txt_TextChanged(object sender, EventArgs e)
    {
        tampilGrid();
    }
}
```

---

## 7. OOP Hierarchy — Aturan Implementasi

### 7.1 BaseKaryawan

```csharp
// Model/BaseKaryawan.cs
internal abstract class BaseKaryawan
{
    private int     _karyawan_id;
    private string  _nama;
    private string  _jabatan;
    private decimal _gaji_pokok;
    private string  _jenis;

    public int     karyawan_id { get { return _karyawan_id; } set { _karyawan_id = value; } }
    public string  nama        { get { return _nama; }        set { _nama = value; } }
    public string  jabatan     { get { return _jabatan; }     set { _jabatan = value; } }
    public decimal gaji_pokok  { get { return _gaji_pokok; }  set { _gaji_pokok = value; } }
    public string  jenis       { get { return _jenis; }       set { _jenis = value; } }

    // Wajib diimplementasikan oleh setiap subclass — ini yang membentuk polymorphism
    public abstract decimal HitungGaji(DataAbsensi absensi, List<KomponenGaji> komponen);
    public abstract string  GetJenis();

    // Method konkret yang bisa langsung dipakai tanpa override
    public string GetInfo()
    {
        return "[" + _jenis + "] " + _nama + " - " + _jabatan;
    }
}
```

### 7.2 Contoh Subclass

```csharp
// Model/KaryawanTetap.cs
internal class KaryawanTetap : BaseKaryawan
{
    public override string GetJenis() => "Karyawan Tetap";

    public override decimal HitungGaji(DataAbsensi absensi, List<KomponenGaji> komponen)
    {
        decimal total = gaji_pokok;

        foreach (var k in komponen.Where(k => k.tipe == "Tambah"))
            total += k.HitungNominal(gaji_pokok);

        foreach (var k in komponen.Where(k => k.tipe == "Potong"))
            total -= k.HitungNominal(gaji_pokok);

        total -= (gaji_pokok / 22) * absensi.alpha;

        return total < 0 ? 0 : total;
    }
}
```

### 7.3 Factory Method — di dalam Gaji_serv, BUKAN file terpisah

```csharp
// Di dalam Gaji_serv.cs
private BaseKaryawan buatObjekKaryawan(string jenis)
{
    if (jenis == "Tetap")   return new KaryawanTetap();
    if (jenis == "Kontrak") return new KaryawanKontrak();
    if (jenis == "Harian")  return new KaryawanHarian();
    return null;
}
```

> Cukup di sini. Jangan buat file `KaryawanFactory.cs` terpisah — tidak ada manfaatnya di skala ini.

---

## 8. UserSession

```csharp
// Konfigurasi/UserSession.cs
internal static class UserSession
{
    public static int    user_id  { get; set; }
    public static string nama     { get; set; }
    public static string username { get; set; }
    public static string role     { get; set; }  // "Admin" | "HRD" | "Karyawan"

    public static void Clear()
    {
        user_id  = 0;
        nama     = "";
        username = "";
        role     = "";
    }

    public static bool IsLoggedIn() => user_id > 0;
}
```

**Aturan pemakaian:**

- Isi `UserSession` hanya dari `FormLogin` setelah login berhasil.
- Cek `UserSession.role` di `Form_Load` setiap form yang memerlukan role tertentu.
- Kosongkan `UserSession` via `UserSession.Clear()` saat logout.
- Jangan passing `UserSession` sebagai parameter — langsung akses sebagai static.

---

## 9. UI dan Layout WinForms

### 9.1 Prinsip Dasar

- Target tampilan: **rapi, konsisten, mudah dibaca**. Bukan meniru tampilan web.
- Semua form menggunakan font dan warna yang sama.
- Jangan install library UI eksternal apapun.

### 9.2 Font

```
Font form       : Segoe UI, 9pt (set di level Form, bukan per kontrol)
Judul/heading   : Segoe UI, 11pt, Bold
Label field     : Segoe UI, 9pt, Regular
```

### 9.3 Warna

| Elemen | Warna | Hex |
|---|---|---|
| Background form | SystemColor default | — |
| Baris genap DataGridView | Alice Blue | `#F0F8FF` |
| Baris ganjil DataGridView | Light Steel Blue | `#B0C4DE` |
| Header DataGridView | Steel Blue | `#4682B4` |
| Tombol Simpan (opsional) | Dodger Blue | `#1E90FF` |
| Tombol Hapus (opsional) | Indian Red | `#CD5C5C` |

> Warna tombol opsional — default SystemColor juga valid.
> Yang **wajib** konsisten: alternating row color di semua DataGridView.

### 9.4 Spacing

```
Margin antar kontrol    : 8px minimum
Padding dalam GroupBox  : 8–12px
Tinggi TextBox/ComboBox : 23px (default WinForms)
Tinggi Button           : 26–30px
Lebar Button            : minimal 80px, seragam dalam satu form
```

### 9.5 Button

- Form CRUD wajib punya tiga tombol: **Simpan**, **Hapus**, **Batal**.
- Urutan kiri ke kanan: Simpan → Hapus → Batal.
- Form non-CRUD: tombol **Tutup** atau **Kembali**.

### 9.6 DataGridView — Konfigurasi Standar

Set ini di `Form_Load` atau via designer untuk semua DataGridView:

```csharp
dgv.ReadOnly                = true;   // kecuali FormAbsensi
dgv.SelectionMode           = DataGridViewSelectionMode.FullRowSelect;
dgv.MultiSelect             = false;
dgv.AllowUserToAddRows      = false;
dgv.AllowUserToDeleteRows   = false;
dgv.AutoSizeColumnsMode     = DataGridViewAutoSizeColumnsMode.Fill;
dgv.EnableHeadersVisualStyles = false;  // wajib agar warna header berlaku

dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
dgv.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 9, FontStyle.Bold);
```

### 9.7 Form Behavior

| Situasi | Yang harus dilakukan |
|---|---|
| `Form_Load` | Selalu panggil `bersihkan()` lalu `tampilGrid()` |
| Klik baris DataGridView | Isi semua TextBox/ComboBox dari data baris tersebut |
| Setelah simpan/hapus berhasil | Panggil `bersihkan()` lalu `tampilGrid()` |
| TextBox pencarian berubah | Langsung panggil `tampilGrid()` (realtime) |
| Sebelum hapus | Wajib konfirmasi `MessageBox.YesNo` |
| Pesan operasi | `MessageBox.Show` singkat dan jelas |

### 9.8 Layout Umum Form CRUD

```
┌─────────────────────────────────────────────────┐
│  [GroupBox: Input]        [GroupBox: Data]       │
│  Kode  : [TextBox]        [Cari: ____________]  │
│  Nama  : [TextBox]        ┌───────────────────┐  │
│  Jenis : [ComboBox]       │  DataGridView     │  │
│                           │                   │  │
│  [Simpan] [Hapus] [Batal] └───────────────────┘  │
└─────────────────────────────────────────────────┘
```

- Panel kiri (40%) untuk input field.
- Panel kanan (60%) untuk DataGridView dan pencarian.
- Gunakan `SplitContainer` atau dua `Panel` berjejer.

---

## 10. Workflow Implementasi

Kerjakan **berurutan**. Jangan melompat ke tahap berikutnya sebelum tahap sebelumnya bisa dijalankan.

| Tahap | Yang Dikerjakan | Kriteria Selesai |
|---|---|---|
| 1 | `Konfigurasi.cs`, `Koneksi.cs`, schema MySQL | Koneksi berhasil, semua tabel terbuat |
| 2 | `UserSession.cs`, `Auth_serv.cs`, `FormLogin.cs` | Login 3 role berjalan, redirect sesuai role |
| 3 | `FormDashboard` per role | Navigasi antar form berfungsi, role terisolasi |
| 4 | Model OOP: `BaseKaryawan` + 3 subclass + `KomponenGaji` + `DataAbsensi` | Kompilasi berhasil, logika `HitungGaji()` bisa diuji manual |
| 5 | `Karyawan_serv.cs` + `FormKaryawan.cs` | CRUD karyawan lengkap dengan pencarian |
| 6 | `Absensi_serv.cs` + `FormAbsensi.cs` | Input absensi bulanan tersimpan ke DB |
| 7 | `Gaji_serv.cs` + `FormProsesGaji.cs` | Kalkulasi gaji otomatis tampil dan tersimpan |
| 8 | `FormSlipGaji.cs` + cetak | Slip gaji dapat dilihat dan dicetak |

---

## 11. Hal yang Harus Dihindari

### Arsitektur

| Jangan lakukan | Alasan |
|---|---|
| Membuat folder `Repositories/` | Tidak diperlukan di skala project ini |
| Membuat folder `Helpers/` atau `Utils/` | Taruh di `Konfigurasi/` jika memang perlu |
| Membuat `KaryawanFactory.cs` sebagai file terpisah | 5 baris kode — cukup di dalam `Gaji_serv.cs` |
| Menggunakan interface `IGajian` terpisah | `BaseKaryawan` abstract sudah cukup sebagai kontrak |
| Menambahkan ORM (Entity Framework, Dapper, dll.) | Bertentangan dengan tujuan praktikum ADO.NET murni |
| Membuat DTO atau ViewModel class | Tidak diperlukan, tambah kompleksitas tanpa manfaat |
| Dependency Injection container | Overengineering total untuk skala ini |

### Query dan Data

| Jangan lakukan | Alasan |
|---|---|
| String concatenation untuk query dengan input user | Rentan SQL injection — wajib pakai parameterized query |
| Menyimpan password plain text | Selalu hash dengan SHA-256 sebelum disimpan atau dibandingkan |
| Menulis query langsung di dalam Form | Semua query harus ada di Service, bukan Form |
| Satu Service untuk semua entitas | Buat satu `_serv` per entitas utama |

### Kode

| Jangan lakukan | Alasan |
|---|---|
| Mixing PascalCase dan snake_case dalam satu file | Pilih satu gaya dan konsisten |
| Mengubah signature method yang sudah ada di `Koneksi.cs` | Hanya tambah method baru, jangan ubah yang lama |
| Menggunakan `public` untuk class yang seharusnya `internal` | Ikuti access modifier yang sudah ditetapkan |
| LINQ kompleks untuk filter yang bisa dilakukan di SQL | Taruh filter di query SQL, bukan di C# |
| Async/await di seluruh aplikasi | Menambah kompleksitas tanpa kebutuhan nyata |

### UI

| Jangan lakukan | Alasan |
|---|---|
| Library UI eksternal (MetroFramework, BunifuUI, dll.) | Tambah dependency tanpa manfaat untuk praktikum |
| Custom control kompleks | Gunakan kontrol WinForms standar |
| Warna atau font berbeda di setiap form | Konsistensi adalah prioritas |
| Form CRUD tanpa tombol Batal/Tutup | Pengguna harus selalu bisa keluar dari form |

---

## 12. Checklist Sebelum Selesai per Tahap

- [ ] Kompilasi berhasil tanpa error dan warning.
- [ ] Penamaan class, field, method, dan kontrol sesuai konvensi di bagian 4.
- [ ] Tidak ada query SQL dengan string concatenation dari input user.
- [ ] Setiap form CRUD punya method `bersihkan()` dan `tampilGrid()`.
- [ ] Semua DataGridView punya alternating row color via `warnaiBaris()`.
- [ ] Operasi hapus punya konfirmasi `MessageBox.YesNo`.
- [ ] `UserSession.role` dicek di `Form_Load` untuk semua form yang butuh role tertentu.
- [ ] Tidak ada folder atau file di luar struktur yang ditetapkan di bagian 3.
- [ ] Tidak ada library baru yang ditambahkan ke project references.

---

*Dokumen ini diperbarui seiring perkembangan project. Jika ada keputusan teknis baru yang disepakati, tambahkan ke sini sebelum diimplementasikan.*
