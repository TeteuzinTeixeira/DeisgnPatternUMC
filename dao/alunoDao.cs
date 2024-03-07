using MySql.Data.MySqlClient;
using System;

namespace Aula01 {

    class AlunoDao
    {

        public void InserirAlunoDAO(string nome, long rgm, DateTime dataNasc, string curso, string bolsista, long rg, string genero)
        {

            Conexao conexao = new Conexao();
        
            string consulta = $"INSERT INTO Aluno(Nome, Rgm, DataNasc, Curso, Bolsista, RG, Genero) " +
                              $"VALUES('{nome}', {rgm}, '{dataNasc:yyyy-MM-dd}', '{curso}', {bolsista}, {rg}, '{genero}')";

            conexao.ExecutarConsulta(consulta);

        }

    }

}
