using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using Aula_01.menu;

namespace Aula01 {
    class Secretaria : MenuTemplate
    {
        Aluno aluno = new Aluno();
        AlunoDao DAO = new AlunoDao();

        private InserirAluno inserirAluno = new InserirAluno();

        private ListarAlunos listarAlunos = new ListarAlunos();

        private AtualizarAluno atualizarAluno = new AtualizarAluno();

        private DeletarAluno deletarAluno = new DeletarAluno();
        
        protected override void executarAcao(int metodo)
        {
            switch(metodo)
            {
                case 1:
                    inserirAluno.Executar();
                    break;
                case 2:
                    listarAlunos.Executar();
                    break;
                case 3:
                    atualizarAluno.Executar();
                    break;
                case 4:
                    deletarAluno.Executar();
                    break;
                default:
                    Console.WriteLine("Saindo...");
                    break;
            }
        }
    }
}