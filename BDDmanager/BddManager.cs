using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Media_tek86.BDDmanager
{
    internal class BddManager
    {
        private static BddManager? instance = null;
        private readonly MySqlConnection connection;

        private BddManager(string cs)
        {
            connection = new MySqlConnection(cs);
            connection.Open();
        }

        public static BddManager GetInstance(string cs)
            => instance ??= new BddManager(cs);

        public void ReqUpdate(string sql, Dictionary<string, object>? p = null)
        {
            using var cmd = new MySqlCommand(sql, connection);
            if (p != null) foreach (var kv in p) cmd.Parameters.AddWithValue(kv.Key, kv.Value);
            cmd.Prepare(); cmd.ExecuteNonQuery();
        }

        public List<object[]> ReqSelect(string sql, Dictionary<string, object>? p = null)
        {
            using var cmd = new MySqlCommand(sql, connection);
            if (p != null) foreach (var kv in p) cmd.Parameters.AddWithValue(kv.Key, kv.Value);
            cmd.Prepare();
            using var reader = cmd.ExecuteReader();
            var outp = new List<object[]>();
            while (reader.Read())
            {
                var row = new object[reader.FieldCount];
                reader.GetValues(row);
                outp.Add(row);
            }
            return outp;
        }
    }
}