using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace SistemPenggajianKaryawan.Konfigurasi
{
    internal class Koneksi : Konfigurasi
    {
        MySqlConnection _connection;
        MySqlCommand _command;
        MySqlDataAdapter _adapter;
        string _link = "server=localhost;database=penggajian;uid=root;pwd=;";

        public Koneksi()
        {
            _connection = new MySqlConnection(_link);
            _command = new MySqlCommand();
            _command.Connection = _connection;
            _adapter = new MySqlDataAdapter(_command);
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

        // Parameterized — wajib dipakai untuk semua query dengan input user
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
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Database Error: " + ex.Message, "Error Database", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                _command.Parameters.Clear();
                tutupKoneksi();
            }
            return nilai;
        }
    }
}