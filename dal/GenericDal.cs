using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_tek86.dal
{
    internal class GenericDal
    {
        private readonly string _connectionString = "server=localhost;database=media-tek86;uid=HADES;pwd='SAYHELLO';";
        private readonly string[] _allowedTables = { "responsable", "absence", "personnel", "motif", "service" };

        public DataTable GetAllFromTable(string tableName)
        {
            if (string.IsNullOrWhiteSpace(tableName))
                throw new ArgumentException("Le nom de la table ne peut pas être vide.");

            tableName = tableName.Trim().ToLower();

            // Vérifier que la table demandée fait bien partie de la liste blanche
            bool autorisee = false;
            foreach (var tbl in _allowedTables)
            {
                if (tbl.Equals(tableName, StringComparison.OrdinalIgnoreCase))
                {
                    autorisee = true;
                    break;
                }
            }
            if (!autorisee)
                throw new ArgumentException($"La table « {tableName} » n’est pas autorisée.");

            var dt = new DataTable();
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = $"SELECT * FROM `{tableName}`;";
                using (var adapter = new MySqlDataAdapter(sql, conn))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
    }
}

