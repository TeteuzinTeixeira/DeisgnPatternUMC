using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int DispalyMenu()
        {
            {
                Console.Clear();
                Console.WriteLine("\nSelecione uma operação:");
                Console.WriteLine("\n---------- Aluno ----------\n");
                Console.WriteLine("1. Inserir aluno");
                Console.WriteLine("2. Listar alunos");
                Console.WriteLine("3. Atualizar aluno");
                Console.WriteLine("4. Deletar aluno");
                Console.WriteLine("\n---------- Livro ----------\n");
                Console.WriteLine("5. Inserir Livro");
                Console.WriteLine("6. Listar livros");
                Console.WriteLine("7. Atualizar livro ");
                Console.WriteLine("8. Deletar livro");
                Console.WriteLine("0. Voltar ao menu\n");
                Console.Write("Opcao: ");
                return Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}
