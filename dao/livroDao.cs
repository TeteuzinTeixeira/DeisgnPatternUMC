using MySql.Data.MySqlClient;
using System;

namespace Aula01 {

    class LivroDAO
    {
        public void InserirLivroDAO(string titulo, string autor, int ano, string genero, string editora, int quantidade)
        {
            Conexao conexao = new Conexao();
            string consulta = $"INSERT INTO Livro(Titulo, Autor, Ano, Genero, Editora, Quantidade) " +
                                $"VALUES('{titulo}', '{autor}', {ano}, '{genero}', '{editora}', {quantidade})";
            MySqlCommand comando = new MySqlCommand(consulta);
            conexao.ExecutarConsulta(comando);
        }

        public List<Livro> ListarLivroDAO()
        {
            List<Livro> livros = new List<Livro>();
            try
            {
                string consulta = "SELECT Titulo, Autor, Ano, Genero, Editora, Quantidade FROM Livro";
                using (MySqlConnection conexaoMySQL = Conexao.CreateDataBaseConnection())
                {
                    conexaoMySQL.Open(); 
                    MySqlCommand comando = new MySqlCommand(consulta, conexaoMySQL); 
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao executar a consulta: " + ex.Message);
            }
            return livros;
        }

        public void DeletarLivro(long ID)
        {
            try
            {
                Conexao conexao = new Conexao();
                string consulta = "DELETE FROM Livro WHERE ID = @ID";
                MySqlCommand comando = new MySqlCommand(consulta);
                comando.Parameters.AddWithValue("@ID", ID);
                conexao.ExecutarConsulta(comando);
                Console.WriteLine("Livro deletado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}