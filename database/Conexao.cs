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


        public List<Livro> RetornarLivro(string consulta)
        {
            List<Livro> livros = new List<Livro>();

            using (MySqlConnection conexao = CreateDataBaseConnection())
            {
                try
                {
                    conexao.Open();
                    MySqlCommand comando = new MySqlCommand(consulta, conexao);
                    MySqlDataReader reader = comando.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        Livro livro = new Livro();
                        livro.setISBN(reader.GetInt64("ISBN"));
                        livro.setTitulo(reader.GetString("Titulo"));
                        livro.setAutor(reader.GetString("Autor"));
                        livro.setAno(reader.GetInt32("Ano"));
                        livro.setGenero(reader.GetString("Genero"));
                        livro.setEdicao(reader.GetInt32("Edicao"));
                        livro.setQuantidade(reader.GetInt32("Quantidade"));
                        
                        livros.Add(livro);
                    }

                    reader.Close();
                    Console.WriteLine("Consulta executada com sucesso!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao executar a consulta: " + ex.Message);
                }
            }

            return livros;
        }
    }
}
