using MySql.Data.MySqlClient;
using System;

namespace Aula01 {

    class LivroDAO
    {
        internal void InserirLivroDAO(long isbn, string titulo, string autor, int ano, string genero, int edicao, int quantidade)
        {
            try
            {
                Conexao conexao = new Conexao();
                string consulta = $"INSERT INTO Livro(ISBN, Titulo, Autor, Ano, Genero, Edicao, Quantidade) " +
                                    $"VALUES({isbn}, '{titulo}', '{autor}', {ano}, '{genero}', {edicao}, {quantidade})";
                using (MySqlConnection conexaoMySQL = Conexao.CreateDataBaseConnection())
                {
                    conexaoMySQL.Open(); 
                    MySqlCommand comando = new MySqlCommand(consulta, conexaoMySQL); 
                    comando.ExecuteNonQuery();
                    Console.WriteLine("Inserção de livro realizada com sucesso!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir livro: " + ex.Message);
            }
        }

        public List<Livro> ListarLivroDAO()
        {
            List<Livro> livros = new List<Livro>();
            try
            {
                string consulta = "SELECT ISBN, Titulo, Autor, Ano, Genero, Edicao, Quantidade FROM Livro";
                using (MySqlConnection conexaoMySQL = Conexao.CreateDataBaseConnection())
                {
                    conexaoMySQL.Open(); 
                    MySqlCommand comando = new MySqlCommand(consulta, conexaoMySQL); 
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao executar a consulta: " + ex.Message);
            }
            return livros;
        }

        public void DeletarLivro(long isbn)
        {
            try
            {
                Conexao conexao = new Conexao();
                string consulta = "DELETE FROM Livro WHERE ISBN = @isbn";
                MySqlCommand comando = new MySqlCommand(consulta);
                comando.Parameters.AddWithValue("@isbn", isbn);
                conexao.ExecutarConsulta(comando);
                Console.WriteLine("Livro deletado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        internal void InserirLivroDAO(long v1, string v2, string v3, int v4, int v5, int v6, int v7)
        {
            throw new NotImplementedException();
        }
    }
}