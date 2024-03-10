using System;
using Aula01;

class Program
{
    static void Main(string[] args)
    {
        int opcao = 0;
        AlunoMenu aluno = new AlunoMenu();
        LivroMenu livro = new LivroMenu();
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
                    aluno.Menu(); 
                    break;
                case 2:
                    livro.Menu();
                    break;
                case 0:
                    Console.WriteLine("\nFeito por: Mateus Teixeira e Iago Da Silva Lima");
                    return;
                
            }



        } while (opcao != 0);
            

    }
}
