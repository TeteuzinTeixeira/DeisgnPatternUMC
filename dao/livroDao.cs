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
            conexao.ExecutarConsulta(consulta);
        }

        public List<Livro> ListarLivroDAO(){
                
            Conexao conexao = new Conexao();
        
            string consulta = "SELECT * FROM Livro";

            List<Livro> livros = conexao.RetornarLivro(consulta);

            return livros;
        }
    }

}
