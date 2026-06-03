using System;
using System.Collections.Generic;
using System.Data;
using SistemPenggajianKaryawan.Konfigurasi;

namespace SistemPenggajianKaryawan.Service
{
    internal class KomponenGaji_serv
    {
        internal int     komponen_id;
        internal string  nama_komponen;
        internal string  tipe;          // "Tambah" | "Potong"
        internal string  jenis_nilai;   // "Nominal" | "Persen"
        internal decimal nilai;
        internal string  berlaku_untuk; // "Semua" | "Tetap" | "Kontrak" | "Harian"

        Koneksi server;

        public KomponenGaji_serv()
        {
            server = new Koneksi();
        }

        public bool jikaAda(string nama)
        {
            string q = "SELECT * FROM komponen_gaji WHERE nama_komponen = @nama AND is_aktif = 1";
            var p = new Dictionary<string, object> { { "@nama", nama } };
            return server.eksekusiQueryParam(q, p).Rows.Count > 0;
        }

        public DataTable viewAll()
        {
            return server.eksekusiQuery(
                "SELECT komponen_id, nama_komponen, tipe, jenis_nilai, nilai, berlaku_untuk " +
                "FROM komponen_gaji WHERE is_aktif = 1 ORDER BY tipe, nama_komponen");
        }

        public DataTable search(string keyword)
        {
            string q = "SELECT komponen_id, nama_komponen, tipe, jenis_nilai, nilai, berlaku_untuk " +
                       "FROM komponen_gaji WHERE is_aktif = 1 " +
                       "AND (nama_komponen LIKE @keyword OR tipe LIKE @keyword OR berlaku_untuk LIKE @keyword) " +
                       "ORDER BY tipe, nama_komponen";
            var p = new Dictionary<string, object> { { "@keyword", "%" + keyword + "%" } };
            return server.eksekusiQueryParam(q, p);
        }

        public int Save()
        {
            int nilai_ret = -1;
            string q = "INSERT INTO komponen_gaji (nama_komponen, tipe, jenis_nilai, nilai, berlaku_untuk) " +
                       "VALUES (@nama, @tipe, @jenis, @nilai, @berlaku)";
            var p = new Dictionary<string, object>
            {
                { "@nama",   nama_komponen  },
                { "@tipe",   tipe           },
                { "@jenis",  jenis_nilai    },
                { "@nilai",  nilai          },
                { "@berlaku",berlaku_untuk  }
            };
            try { nilai_ret = server.eksekusiNonQueryParam(q, p); }
            catch (Exception) { }
            return nilai_ret;
        }

        public int update(int id)
        {
            int nilai_ret = -1;
            string q = "UPDATE komponen_gaji SET nama_komponen = @nama, tipe = @tipe, jenis_nilai = @jenis, " +
                       "nilai = @nilai, berlaku_untuk = @berlaku WHERE komponen_id = @id";
            var p = new Dictionary<string, object>
            {
                { "@nama",   nama_komponen  },
                { "@tipe",   tipe           },
                { "@jenis",  jenis_nilai    },
                { "@nilai",  nilai          },
                { "@berlaku",berlaku_untuk  },
                { "@id",     id             }
            };
            try { nilai_ret = server.eksekusiNonQueryParam(q, p); }
            catch (Exception) { }
            return nilai_ret;
        }

        public int delete(int id)
        {
            int nilai_ret = -1;
            // Soft delete
            string q = "UPDATE komponen_gaji SET is_aktif = 0 WHERE komponen_id = @id";
            var p = new Dictionary<string, object> { { "@id", id } };
            try { nilai_ret = server.eksekusiNonQueryParam(q, p); }
            catch (Exception) { }
            return nilai_ret;
        }
    }
}
