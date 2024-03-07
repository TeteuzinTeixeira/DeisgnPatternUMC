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

        public List<Aluno> RetornarAlunos(string consulta)
        {
            List<Aluno> alunos = new List<Aluno>();

            using (MySqlConnection conexao = CreateDataBaseConnection())
            {
                try
                {
                    conexao.Open();
                    MySqlCommand comando = new MySqlCommand(consulta, conexao);
                    MySqlDataReader reader = comando.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        Aluno aluno = new Aluno();
                        aluno.setNome(reader.GetString("Nome"));
                        aluno.setRGM(reader.GetInt64("Rgm"));
                        aluno.setDataNas(reader.GetDateTime("DataNasc"));
                        aluno.setCurso(reader.GetString("Curso"));
                        aluno.setBolsista(reader.GetBoolean("Bolsista") ? "Sim" : "Não");
                        aluno.setRG(reader.GetInt64("RG"));
                        aluno.setGenero(reader.GetString("Genero"));
                        
                        alunos.Add(aluno);
                    }

                    reader.Close();
                    Console.WriteLine("Consulta executada com sucesso!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao executar a consulta: " + ex.Message);
                }
            }

            return alunos;
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
                        livro.setTitulo(reader.GetString("Titulo"));
                        livro.setAutor(reader.GetString("Autor"));
                        livro.setAno(reader.GetInt32("Ano"));
                        livro.setGenero(reader.GetString("Genero"));
                        livro.setEditora(reader.GetString("Editora"));
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
