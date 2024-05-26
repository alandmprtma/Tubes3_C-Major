using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GUI.Database
{
    public class Database
    {
        private static string connectionString = "server=localhost;user=root;password=;database=stima";
        private static MySqlConnection connection = new MySqlConnection(connectionString);

        public static void OpenConnection()
        {
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public static void CloseConnection()
        {
            connection.Close();
        }

        public static MySqlConnection GetConnection()
        {
            return connection;
        }
    }
  
    public class Biodata
    {
        public string NIK { get; set; }
        public string Nama { get; set; }

        public Biodata(string nik, string nama)
        {
            NIK = nik;
            Nama = nama;
        }
    }

    public class BiodataLoader
    {
        private List<Biodata> biodataList;

        public BiodataLoader()
        {
            biodataList = new List<Biodata>();
            LoadDataFromSql();
        }

        private void LoadDataFromSql()
        {
            // string connectionString = "server=localhost;user=root;password=root;database=stima";
            // string connectionString = "server=localhost;user=root;password=;database=stima";
            // MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlConnection connection = Database.GetConnection();

            try
            {
                connection.Open();
                string query = "SELECT * FROM biodata";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string nik = reader["NIK"].ToString();
                    string nama = reader["nama"].ToString();
                    biodataList.Add(new Biodata(nik, nama));
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Biodata> GetBiodataList()
        {
            return biodataList;
        }
    }


    public class SidikJari
    {
        public string BerkasCitra { get; set; }
        public string Nama { get; set; }

        public SidikJari(string berkasCitra, string nama)
        {
            BerkasCitra = berkasCitra;
            Nama = nama;
        }
    }

    public class SidikJariLoader
    {
        private List<SidikJari> sidikJariList;

        public SidikJariLoader()
        {
            sidikJariList = new List<SidikJari>();
            LoadDataFromSql();
        }

        private void LoadDataFromSql()
        {
            // string connectionString = "server=localhost;user=root;password=root;database=stima";
            // MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlConnection connection = Database.GetConnection();

            try
            {
                connection.Open();
                string query = "SELECT * FROM sidik_jari";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string berkasCitra = reader["berkas_citra"].ToString();
                    string nama = reader["nama"].ToString();
                    sidikJariList.Add(new SidikJari(berkasCitra, nama));
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public List<SidikJari> GetSidikJariList()
        {
            return sidikJariList;
        }
    

}
}

//CONTOH CARA PAKAI
// class Program
// {
//     static void Main()
//     {
//         SidikJariLoader loader = new SidikJariLoader();
//         List<SidikJari> sidikJariList = loader.GetSidikJariList();

//         Console.WriteLine("Masukkan nama file berkas citra:");
//         string inputFileName = Console.ReadLine();

//         inputFileName = @"Image\" + inputFileName;

//         bool found = false;
//         foreach (var sidikJari in sidikJariList)
//         {
//             if (sidikJari.BerkasCitra == inputFileName)
//             {
//                 Console.WriteLine("Berkas Citra: {0}, Nama: {1}", sidikJari.BerkasCitra, sidikJari.Nama);
//                 found = true;

//                 // Memuat dan menampilkan gambar
//                 try
//                 {
//                     string imagePath = Path.Combine(AppDomain.CurrentDomain., sidikJari.BerkasCitra);
//                     Console.WriteLine($"{imagePath}");
//                     if (File.Exists(imagePath))
//                     {
//                         Console.WriteLine($"{imagePath}");
//                         Console.WriteLine("FILE NYA ADA CUY");
//                     }
//                     else
//                     {
//                         Console.WriteLine("File gambar tidak ditemukan.");
//                     }
//                 }
//                 catch (Exception ex)
//                 {
//                     Console.WriteLine("Error: " + ex.Message);
//                 }

//                 break; // Menghentikan pencarian setelah ditemukan pertama kali
//             }
//         }
//     }
// }
