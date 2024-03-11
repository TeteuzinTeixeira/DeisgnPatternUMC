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
                string consulta = "SELECT * FROM Livro";
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
                } 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao executar a consulta: " + ex.Message);
            }
            return livros;
        }
        
        public void UpdateLivro(long isbn, string titulo, string autor, int ano, string genero, int edicao, int quantidade){

            try
            {
                Conexao conexao = new Conexao();
                string consulta = "UPDATE Livro SET Titulo = @Titulo, Autor = @Autor, Ano = @Ano, Genero = @Genero, Edicao = @Edicao, quantidade = @Quantidade WHERE ISBN = @isbn";
                using (MySqlConnection conexaoMySQL = Conexao.CreateDataBaseConnection())
                {
                    conexaoMySQL.Open();
                    MySqlCommand comando = new MySqlCommand(consulta, conexaoMySQL);

                    Livro livro = new Livro();
                    comando.Parameters.AddWithValue("@Titulo", titulo);
                    comando.Parameters.AddWithValue("@Autor", autor);
                    comando.Parameters.AddWithValue("@Ano", ano);
                    comando.Parameters.AddWithValue("@Genero", genero);
                    comando.Parameters.AddWithValue("@Edicao", edicao);
                    comando.Parameters.AddWithValue("@Quantidade", quantidade);
                    comando.Parameters.AddWithValue("@isbn", isbn);

                    int linhasAfetadas = comando.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                    {
                        Console.WriteLine("Livro atualizado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Livro nao encontrado!");
                    }
                }
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}