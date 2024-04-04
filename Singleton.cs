using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aula_01.menu;
using Google.Protobuf.Reflection;

namespace Aula_01
{
    public sealed class Singleton 
    {
        private Singleton() { }
        private static Singleton? _instance;
        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }

        public int DisplayMenu(int metodo, MenuTemplate menuTemplate)
        {
            metodo = 0;
            int opcao = 0;
            switch (metodo)
            {
                case 0:
                    Console.Clear();
                    Console.WriteLine("\nSelecione uma operação:");
                    Console.WriteLine("1 - SECRETARIA");
                    Console.WriteLine("2 - BIBLIOTECA\n");
                    Console.WriteLine("3 - Sair");
                    Console.Write("Opcao: ");
                    return opcao = Convert.ToInt32(Console.ReadLine());
                    break;

                case 1:
                    Console.WriteLine("\n---------- Aluno ----------\n");
                    Console.WriteLine("1. Inserir aluno");
                    Console.WriteLine("2. Listar alunos");
                    Console.WriteLine("3. Atualizar aluno");
                    Console.WriteLine("4. Deletar aluno");
                    Console.WriteLine("0. Voltar ao menu\n");
                    Console.Write("Opcao: ");
                    return metodo = Convert.ToInt32(Console.ReadLine());
                    break;

                case 2:
                    Console.WriteLine("\n---------- Livro ----------\n");
                    Console.WriteLine("1. Inserir Livro");
                    Console.WriteLine("2. Listar livros");
                    Console.WriteLine("3. Atualizar livro ");
                    Console.WriteLine("4. Deletar livro");
                    Console.WriteLine("0. Voltar ao menu\n");
                    Console.Write("Opcao: ");
                    return metodo = Convert.ToInt32(Console.ReadLine());
                    break;

                default:
                    opcao = 0;
                    Console.WriteLine("Saindo...");
                    break;
            }

            if (menuTemplate != null)
            {
                menuTemplate.run(metodo);
            }
            
            return opcao;
        }
    }
}
