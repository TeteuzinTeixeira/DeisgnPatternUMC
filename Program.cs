using System;
using System.Security.Cryptography.X509Certificates;
using Aula_01;
using Aula01;

class Program
{
    static void Main(string[] args)
    {
        Singleton singleton = Singleton.GetInstance();

        Secretaria secretaria = new Secretaria();
        Biblioteca biblioteca = new Biblioteca();
        
        int chave = 0;
        int opcao;
        int metodo;
        

        do
        {
            opcao = singleton.DisplayMenu(chave);

            switch (opcao)
            {
                case 1:
                    chave = 1;
                    metodo = singleton.DisplayMenu(chave);
                    if (metodo != 0)
                    {
                        secretaria.showMenu(metodo);
                    }
                    chave = 0;
                    break;
                case 2:
                    chave = 2;
                    metodo = singleton.DisplayMenu(chave);
                    if (metodo != 0)
                    {
                        biblioteca.showMenu(metodo);
                    }
                    chave = 0;
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
