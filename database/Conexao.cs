using MySql.Data.MySqlClient;
using System;

namespace Aula01 {

    class Conexao{

        private static MySqlConnection CreateDataBaseConnection()
        {
            string connectionString = "server=sql.freedb.tech;userid=freedb_Mateus;password=Nt8pd!Qz#UktKES;database=freedb_Design-Pattern";
            MySqlConnection dataBaseConnection = new MySqlConnection(connectionString);
            return dataBaseConnection;
        }

        public void ExecutarConsulta(string consulta)
        {
            using (MySqlConnection conexao = CreateDataBaseConnection())
            {
                try
                {
                    conexao.Open();
                    MySqlCommand comando = new MySqlCommand(consulta, conexao);
                    comando.ExecuteNonQuery();
                    Console.WriteLine("Consulta executada com sucesso!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao executar a consulta: " + ex.Message);
                }
            }
        }
    }
}
