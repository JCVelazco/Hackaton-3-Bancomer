using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CSPredictionSample
{
    static class CsPredictor
    {
        static void Main(string[] args)
        {
            String connString = "Server=localhost;Port=3306;Database=mapadecalor;Uid=root;Password=;";
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "insert into mapa(latitud, longitud, lugar) values(0.12342,0.1235123,'Tlaxcala')";
            conn.Open();
            int n = command.ExecuteNonQuery();
            Console.Write(n);
            Console.ReadKey();
            conn.Close();

        }
    }
}