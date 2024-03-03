using System;
using Aula01;

class Program
{
    static void Main(string[] args)
    {
        int opcao = 0;
        Aluno aluno = new Aluno();
        Livro livro = new Livro();
        do
        {
            Console.Clear();

            Console.WriteLine("------------ Sistema de Gerenciamento ------------\n");
            Console.WriteLine("Escolha a opcao desejada\n");
            Console.WriteLine("1. Aluno\n");
            Console.WriteLine("2. Livro\n");
            Console.WriteLine("0. Sair\n");

            Console.Write("Opcao: ");
            opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    aluno.AlunoMenu(); 
                    break;
                case 2:
                    livro.LivroMenu();
                    break;
                case 0:
                    Console.WriteLine("Feito por: \nMATEUS TEIXEIRA GOMES e IAGO DA SILVA LIMA");
                    return;
                
            }



        } while (opcao != 0);
            

    }
}
