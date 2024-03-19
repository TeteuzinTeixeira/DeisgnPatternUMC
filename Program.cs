using System;
using System.Security.Cryptography.X509Certificates;
using Aula_01;
using Aula01;

class Program
{
    static void Main(string[] args)
    {
        Singleton singleton = Singleton.GetInstance();

        AlunoMenu aluno = new AlunoMenu();
        LivroMenu livro = new LivroMenu();
        int opcao = 0;

        do
        {
            opcao = singleton.DispalyMenu();

            switch (opcao)
            {
                case 1:
                    aluno.InserirAluno();   
                    break;
                case 2:
                    aluno.ListarAlunos();
                    break;
                case 3:
                    aluno.AtualizarAluno();
                    break;
                case 4:
                    aluno.DeletarAluno();
                    break;
                case 5:
                    livro.InserirLivro();
                    break;
                case 6:
                    livro.ListarLivros();
                    break;
                case 7:
                    livro.AtualizarLivro();
                    break;
                case 8:
                    livro.DeletarLivro();
                    break;
            } 

         } while (opcao != 0);
    }
}
