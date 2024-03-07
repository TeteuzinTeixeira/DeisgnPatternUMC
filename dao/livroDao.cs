using MySql.Data.MySqlClient;
using System;

namespace Aula01 {

    class LivroDAO
    {

        public void InserirLivroDAO(long ibsm, string titulo, string autor, int ano, string genero, string editora, int quantidade)
        {

            Conexao conexao = new Conexao();
        
            string consulta = $"INSERT INTO Livro(Titulo, Autor, Ano, Genero, Editora, Quantidade) " +
                                $"VALUES('{titulo}', '{autor}', {ano}, '{genero}', '{editora}', {quantidade})";
            conexao.ExecutarConsulta(consulta);

        }

    }

}
