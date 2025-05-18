using System;
using System.Data;
using System.Data.SqlClient;

namespace GiyimOtomasyonuFinalProject.Models
{
    /// <summary>
    /// Veritabanı bağlantısı için gerekli işlemleri içeren sınıf
    /// </summary>
    public static class Database
    {
        // Veritabanı bağlantı dizesi
        public static readonly string ConnectionString = "Server=LAPTOP-IM6U7KIP;Database=GiyimOtomasyonu; Integrated Security = True";

        /// <summary>
        /// Veritabanı bağlantısını açar ve döndürür
        /// </summary>
        /// <returns>Açık bir SqlConnection nesnesi</returns>
        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            return connection;
        }

        /// <summary>
        /// SqlCommand nesnesini oluşturur ve parametreleri ekler
        /// </summary>
        /// <param name="cmdText">SQL sorgusu</param>
        /// <param name="parameters">Sorgu parametreleri</param>
        /// <returns>Hazırlanmış SqlCommand nesnesi</returns>
        public static SqlCommand CreateCommand(string cmdText, params SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(cmdText, GetConnection());
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }
            return command;
        }

        /// <summary>
        /// Verilen SQL sorgusunu çalıştırır ve etkilenen satır sayısını döndürür
        /// </summary>
        /// <param name="cmdText">SQL sorgusu</param>
        /// <param name="parameters">Sorgu parametreleri</param>
        /// <returns>Etkilenen satır sayısı</returns>
        public static int ExecuteNonQuery(string cmdText, params SqlParameter[] parameters)
        {
            using (SqlCommand command = CreateCommand(cmdText, parameters))
            {
                int result = command.ExecuteNonQuery();
                command.Connection.Close();
                return result;
            }
        }

        /// <summary>
        /// Verilen SQL sorgusunu çalıştırır ve sonucu DataTable olarak döndürür
        /// </summary>
        /// <param name="cmdText">SQL sorgusu</param>
        /// <param name="parameters">Sorgu parametreleri</param>
        /// <returns>Sorgu sonuçlarını içeren DataTable</returns>
        public static DataTable ExecuteQuery(string cmdText, params SqlParameter[] parameters)
        {
            using (SqlCommand command = CreateCommand(cmdText, parameters))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                command.Connection.Close();
                return table;
            }
        }

        /// <summary>
        /// Verilen SQL sorgusunu çalıştırır ve ilk sütunun ilk satırını döndürür
        /// </summary>
        /// <param name="cmdText">SQL sorgusu</param>
        /// <param name="parameters">Sorgu parametreleri</param>
        /// <returns>İlk sütunun ilk satırı</returns>
        public static object ExecuteScalar(string cmdText, params SqlParameter[] parameters)
        {
            using (SqlCommand command = CreateCommand(cmdText, parameters))
            {
                object result = command.ExecuteScalar();
                command.Connection.Close();
                return result;
            }
        }

        /// <summary>
        /// Müşteri puanları tablosunu oluşturur
        /// </summary>
        public static void CreateMusteriPuanlariTable()
        {
            string createTableQuery = @"
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'MusteriPuanlari')
                BEGIN
                    CREATE TABLE MusteriPuanlari (
                        MusteriID INT PRIMARY KEY,
                        Puan INT DEFAULT 0,
                        SonGuncellemeTarihi DATETIME DEFAULT GETDATE(),
                        FOREIGN KEY (MusteriID) REFERENCES Musteri(MusteriId)
                    )
                END";

            ExecuteNonQuery(createTableQuery);
        }

        /// <summary>
        /// Müşterinin puanını günceller
        /// </summary>
        /// <param name="musteriId">Müşteri ID</param>
        /// <param name="eklenecekPuan">Eklenecek puan miktarı</param>
        public static void MusteriPuanGuncelle(int musteriId, int eklenecekPuan)
        {
            string updateQuery = @"
                IF EXISTS (SELECT * FROM MusteriPuanlari WHERE MusteriID = @MusteriID)
                BEGIN
                    UPDATE MusteriPuanlari 
                    SET Puan = Puan + @EklenecekPuan,
                        SonGuncellemeTarihi = GETDATE()
                    WHERE MusteriID = @MusteriID
                END
                ELSE
                BEGIN
                    INSERT INTO MusteriPuanlari (MusteriID, Puan)
                    VALUES (@MusteriID, @EklenecekPuan)
                END";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MusteriID", musteriId),
                new SqlParameter("@EklenecekPuan", eklenecekPuan)
            };

            ExecuteNonQuery(updateQuery, parameters);
        }

        /// <summary>
        /// Müşterinin mevcut puanını getirir
        /// </summary>
        /// <param name="musteriId">Müşteri ID</param>
        /// <returns>Müşterinin puanı</returns>
        public static int GetMusteriPuan(int musteriId)
        {
            string query = "SELECT ISNULL(Puan, 0) FROM MusteriPuanlari WHERE MusteriID = @MusteriID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MusteriID", musteriId)
            };

            object result = ExecuteScalar(query, parameters);
            return result != null ? Convert.ToInt32(result) : 0;
        }

        /// <summary>
        /// Satis tablosuna PuanEklendi sütununu ekler
        /// </summary>
        public static void AddPuanEklendiColumnToSatis()
        {
            string alterTableQuery = @"
                IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Satis') AND name = 'PuanEklendi')
                BEGIN
                    ALTER TABLE Satis ADD PuanEklendi BIT DEFAULT 0
                END";

            ExecuteNonQuery(alterTableQuery);
        }
    }
} 