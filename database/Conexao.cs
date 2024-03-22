using MySql.Data.MySqlClient;
using System;

namespace Aula01 {

    class Conexao{

        public static MySqlConnection CreateDataBaseConnection()
        {
            string connectionString = "server=sql.freedb.tech;userid=freedb_Mateus;password=Nt8pd!Qz#UktKES;database=freedb_Design-Pattern";
            MySqlConnection dataBaseConnection = new MySqlConnection(connectionString);
            return dataBaseConnection;
        }

        public void ExecutarConsulta(MySqlCommand comando)
        {
            using (MySqlConnection conexao = CreateDataBaseConnection())
            {
                try
                {
                    conexao.Open();
                    comando.Connection = conexao;
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao executar a consulta: " + ex.Message);
                }
            }
        }
    }
}
