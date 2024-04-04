using System;
using System.Security.Cryptography.X509Certificates;
using Aula_01;
using Aula_01.menu;
using Aula01;

class Program
{
    static void Main(string[] args)
    {
        Singleton singleton = Singleton.GetInstance();

        Secretaria secretaria = new Secretaria();
        Biblioteca biblioteca = new Biblioteca();
        int opcao;
        int metodo = 0;
        

        do
        {
            opcao = singleton.DisplayMenu(metodo);

            switch (opcao)
            {
                case 1:
                    metodo = 1;
                    metodo = singleton.DisplayMenu(metodo);
                    if (metodo != 0)
                    {
                        secretaria.showMenu(metodo);
                    }
                    metodo = 0;
                    break;
                case 2:
                    metodo = 2;
                    metodo = singleton.DisplayMenu(metodo);
                    if (metodo != 0)
                    {
                        biblioteca.showMenu(metodo);
                    }
                    metodo = 0;
                    break;
                case 3:
                    Console.WriteLine("saindo...");
                    break;
                default:
                    Console.WriteLine("Numero invalido");
                    Console.ReadLine();
                    chave = 0;
                    break;
            }
        } while (opcao != 3);
    }
}
