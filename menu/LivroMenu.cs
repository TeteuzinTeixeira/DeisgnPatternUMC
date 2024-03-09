using MySql.Data.MySqlClient;
using System;
using System.Globalization;

namespace Aula01 {
    class LivroMenu
    {
        public void Menu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("\nSelecione uma operação:");

                Console.WriteLine("\n---------- Livro ----------\n");

                Console.WriteLine("1. Inserir Livro");
                Console.WriteLine("2. Listar livros");
                Console.WriteLine("3. Atualizar livro ");
                Console.WriteLine("4. Deletar livro");
                Console.WriteLine("0. Voltar ao menu\n");

                Console.Write("Opcao: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        InserirLivro();
                        break;
                    case 2:
                        ListarLivros();
                        break;
                    // case 3:
                    //     AtualizarLivro();
                    //     break;
                    case 4:
                        DeletarLivro();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                        break;
                }
            }
        }

        Livro livro = new Livro();
        LivroDAO DAO = new LivroDAO();

        public void InserirLivro()
        {
            try
            {
                string Titulo;
                do
                {
                    Console.Clear();
                    Console.WriteLine("*Inserir livro \n\n ");

                    Console.WriteLine("*Digite o nome do Livro: ");
                    livro.setTitulo(Console.ReadLine());

                    if (string.IsNullOrEmpty(livro.getTitulo()))
                    {
                        Console.WriteLine("O campo Livro não pode estar vazio.");
                    }
                    else if (livro.getTitulo().Length > 50)
                    {
                        Console.WriteLine("O campo Livro deve ter no máximo 50 caracteres.");
                    }
                } while (string.IsNullOrEmpty(livro.getTitulo()) || livro.getTitulo().Length > 50);


                string Autor;
                do
                {
                    Console.WriteLine("*Digite o nome do Autor: ");
                    livro.setAutor(Console.ReadLine());

                    if (string.IsNullOrEmpty(livro.getAutor()))
                    {
                        Console.WriteLine("O campo Autor não pode estar vazio.");
                    }
                    else if (livro.getAutor().Length > 50)
                    {
                        Console.WriteLine("O campo Autor deve ter no máximo 50 caracteres.");
                    }
                } while (string.IsNullOrEmpty(livro.getAutor()) || livro.getAutor().Length > 50);

                int Ano = 0;
                do
                {
                    Console.WriteLine("*Digite o ano do livro (somente números): ");
                    string input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("O campo do ano não pode estar vazio.");
                    }
                    else if (input.Length != 4)
                    {
                        Console.WriteLine("O ano deve ter 4 caracteres.");
                    }
                    else if (!int.TryParse(input, out int value))
                    {
                        Console.WriteLine("Valor de ano inválido.");
                    }
                    else
                    {
                        livro.setAno(value);
                        Ano = value;
                    }
                } while (Ano == 0);

                do
                {
                    Console.WriteLine("*Digite o Genero do livro: ");
                    livro.setGenero(Console.ReadLine());

                    if (string.IsNullOrEmpty(livro.getGenero()))
                    {
                        Console.WriteLine("O campo Genero não pode estar vazio.");
                    }
                    else if (livro.getGenero().Length > 100)
                    {
                        Console.WriteLine("O campo Genero deve ter no máximo 100 caracteres.");
                    }
                } while (string.IsNullOrEmpty(livro.getGenero()) || livro.getGenero().Length > 100);

                do
                {
                    Console.WriteLine("*Digite o Editora do livro: ");
                    livro.setEditora(Console.ReadLine());

                    if (string.IsNullOrEmpty(livro.getEditora()))
                    {
                        Console.WriteLine("O campo Editora não pode estar vazio.");
                    }
                    else if (livro.getEditora().Length > 100)
                    {
                        Console.WriteLine("O campo Editora deve ter no máximo 100 caracteres.");
                    }
                } while (string.IsNullOrEmpty(livro.getEditora()) || livro.getEditora().Length > 100);

                int Quantidade = 0;
                do
                {
                    Console.WriteLine("*Digite a quantidade do livro (somente números): ");
                    string input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("O campo de Quantidade não pode estar vazio.");
                    }
                    else if (!int.TryParse(input, out int inputNumber) || inputNumber <= 0)
                    {
                        Console.WriteLine("A Quantidade deve ser um número inteiro maior que zero.");
                    }
                    else if (inputNumber > 1000)
                    {
                        Console.WriteLine("A Quantidade deve ser no máximo 1000.");
                    }
                    else
                    {
                        livro.setQuantidade(inputNumber);
                        Quantidade = inputNumber;
                    }
                } while (Quantidade == 0);

                DAO.InserirLivroDAO(livro.getTitulo(), livro.getAutor(), livro.getAno(), livro.getGenero(), livro.getEditora(), livro.getQuantidade());

                Console.WriteLine("Inserção concluída com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        public void ListarLivros()
        {
            try
            {
                Console.Clear();

                List<Livro> livros = DAO.ListarLivroDAO();

                if (livros.Count > 0)
                {
                    Console.WriteLine("Lista de livros:");
                    foreach (Livro livro in livros)
                    {
                        // Exibir as informações de cada aluno
                        Console.WriteLine($"Titulo: {livro.getTitulo()}, Autor: {livro.getAutor()}, Ano: {livro.getAno()}, Genero: {livro.getGenero()}, Editora: {livro.getGenero()}, Editora: {livro.getEditora()}, Quantidade: {livro.getQuantidade()}");
                    }
                }
                else
                {
                    Console.WriteLine("Nenhum livro cadastrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}"); 
            }
        }


        // static void AtualizarLivro()
        // {
        //     try
        //     {
        //         Console.Clear();
        //         bool retorno = ListarLivros();

        //         if(retorno)
        //         {
        //             long? ID = null;
        //             do
        //             {
        //                 Console.WriteLine("\n\n*Atualizar livros \n\n ");

        //                 Console.WriteLine("*Digite o RGM do aluno que deseja atualizar: ");
        //                 string input = Console.ReadLine();

        //                 if (string.IsNullOrEmpty(input))
        //                 {
        //                     Console.WriteLine("O campo ID não pode estar vazio.");
        //                 }
        //                 else if (!long.TryParse(input, out long value))
        //                 {
        //                     Console.WriteLine("Valor de ID inválido.");
        //                 }
        //                 else
        //                 {
        //                     ID = value;
        //                 }
        //             } while (!ID.HasValue);

        //             using var crud = new MySqlConnection(cs);
        //             crud.Open();

        //             var cmd = new MySqlCommand();
        //             cmd.Connection = crud;

        //             string Titulo;
        //             do
        //             {
        //                 Console.WriteLine("*Digite o nome do Livro: ");
        //                 Titulo = Console.ReadLine();

        //                 if (string.IsNullOrEmpty(Titulo))
        //                 {
        //                     Console.WriteLine("O campo Livro não pode estar vazio.");
        //                 }
        //                 else if (Titulo.Length > 50)
        //                 {
        //                     Console.WriteLine("O campo Livro deve ter no máximo 50 caracteres.");
        //                 }
        //             } while (string.IsNullOrEmpty(Titulo) || Titulo.Length > 50);


        //             string Autor;
        //             do
        //             {
        //                 Console.WriteLine("*Digite o nome do Autor: ");
        //                 Autor = Console.ReadLine();

        //                 if (string.IsNullOrEmpty(Titulo))
        //                 {
        //                     Console.WriteLine("O campo Autor não pode estar vazio.");
        //                 }
        //                 else if (Autor.Length > 50)
        //                 {
        //                     Console.WriteLine("O campo Autor deve ter no máximo 50 caracteres.");
        //                 }
        //             } while (string.IsNullOrEmpty(Autor) || Autor.Length > 50);

        //             int? Ano = null;
        //             do
        //             {
        //                 Console.WriteLine("*Digite o ano do livro (somente numeros): ");
        //                 string input = Console.ReadLine();

        //                 if (string.IsNullOrEmpty(input))
        //                 {
        //                     Console.WriteLine("O campo do ano não pode estar vazio.");
        //                 }
        //                 else if (input.Length != 4)
        //                 {
        //                     Console.WriteLine("O ano deve ter 4 caracteres");
        //                 }
        //                 else if (!int.TryParse(input, out int value))
        //                 {
        //                     Console.WriteLine("Valor de rg inválido.");
        //                 }
        //                 else
        //                 {
        //                     Ano = value;
        //                 }
        //             } while (!Ano.HasValue);

        //             string Genero;
        //             do
        //             {
        //                 Console.WriteLine("*Digite o Genero do livro: ");
        //                 Genero = Console.ReadLine();

        //                 if (string.IsNullOrEmpty(Genero))
        //                 {
        //                     Console.WriteLine("O campo Genero não pode estar vazio.");
        //                 }
        //                 else if (Genero.Length > 100)
        //                 {
        //                     Console.WriteLine("O campo Genero deve ter no máximo 100 caracteres.");
        //                 }
        //             } while (string.IsNullOrEmpty(Genero) || Genero.Length > 100);

        //             string Editora;
        //             do
        //             {
        //                 Console.WriteLine("*Digite o Editora do livro: ");
        //                 Editora = Console.ReadLine();

        //                 if (string.IsNullOrEmpty(Editora))
        //                 {
        //                     Console.WriteLine("O campo Editora não pode estar vazio.");
        //                 }
        //                 else if (Editora.Length > 100)
        //                 {
        //                     Console.WriteLine("O campo Editora deve ter no máximo 100 caracteres.");
        //                 }
        //             } while (string.IsNullOrEmpty(Editora) || Editora.Length > 100);

        //             int? Quantidade = null;
        //             do
        //             {
        //                 Console.WriteLine("*Digite a quantidade do livro (somente números): ");
        //                 string input = Console.ReadLine();

        //                 if (string.IsNullOrEmpty(input))
        //                 {
        //                     Console.WriteLine("O campo de Quantidade não pode estar vazio.");
        //                 }
        //                 else if (!int.TryParse(input, out int inputNumber) || inputNumber <= 0)
        //                 {
        //                     Console.WriteLine("A Quantidade deve ser um número inteiro maior que zero.");
        //                 }
        //                 else if (inputNumber > 1000)
        //                 {
        //                     Console.WriteLine("A Quantidade deve ter no máximo 1000 caracteres");
        //                 }
        //                 else
        //                 {
        //                     Quantidade = inputNumber;
        //                 }
        //             } while (!Quantidade.HasValue);

        //             cmd.CommandText = $"UPDATE Livro SET Titulo = '{Titulo}', Autor = '{Autor}', Ano = {Ano}, Genero = '{Genero}', Editora = '{Editora}', Quantidade = {Quantidade} WHERE ID = {ID}";

        //             int rowsAffected = cmd.ExecuteNonQuery();

        //             if (rowsAffected > 0)
        //             {
        //                 Console.WriteLine("Livro atualizado com sucesso!");
        //             }
        //             else
        //             {
        //                 Console.WriteLine("Livro não encontrado.");
        //             }
        //         }
        //         else
        //         {
        //             Console.WriteLine("\nNão há livros para atualizar !\n\nAperte ENTER para voltar");
        //             Console.ReadLine();
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine($"Erro: {ex.Message}");
        //     }
        // }

        public void DeletarLivro()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\n\nDeletar Livro \n\n ");
                Console.WriteLine("Digite o ID do livro que deseja deletar: ");
                long ID = long.Parse(Console.ReadLine());
                livro.setID(ID);
                DAO.DeletarLivro(livro.getID());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}