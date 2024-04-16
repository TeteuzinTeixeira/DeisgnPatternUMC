using MySql.Data.MySqlClient;
using System;
using System.Globalization;
using Aula_01.menu;

namespace Aula01 {
    class Biblioteca : MenuTemplate
    {
        private InserirLivro inserirLivro = new InserirLivro();

        private ListarLivros listarLivros = new ListarLivros();

        private AtualizarLivro atualizarLivro = new AtualizarLivro();

        private DeletarLivro deletarLivro = new DeletarLivro();
        protected override void executarAcao(int metodo)
        {
            switch (metodo)
            {
                case 1:
                    inserirLivro.Executar();
                    break;
                case 2:
                    listarLivros.Executar();
                    break;
                case 3:
                    atualizarLivro.Executar();
                    break;
                case 4:
                    deletarLivro.Executar();
                    break;
                default:
                    Console.WriteLine("Saindo...");
                    break;
            }
        }
    }
}