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
                    case 3:
                        AtualizarLivro();
                        break;
                    case 4:
                        DeletarLivros();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                        break;
                }
            }
        }

        static void InserirLivro()
        {
            try
            {
                using var crud = new MySqlConnection(cs);
                crud.Open();

                string Titulo;
                do
                {
                    Console.Clear();
                    Console.WriteLine("*Inserir livro \n\n ");

                    Console.WriteLine("*Digite o nome do Livro: ");
                    Titulo = Console.ReadLine();

                    if (string.IsNullOrEmpty(Titulo))
                    {
                        Console.WriteLine("O campo Livro não pode estar vazio.");
                    }
                    else if (Titulo.Length > 50)
                    {
                        Console.WriteLine("O campo Livro deve ter no máximo 50 caracteres.");
                    }
                } while (string.IsNullOrEmpty(Titulo) || Titulo.Length > 50);


                string Autor;
                do
                {
                    Console.WriteLine("*Digite o nome do Autor: ");
                    Autor = Console.ReadLine();

                    if (string.IsNullOrEmpty(Titulo))
                    {
                        Console.WriteLine("O campo Autor não pode estar vazio.");
                    }
                    else if (Autor.Length > 50)
                    {
                        Console.WriteLine("O campo Autor deve ter no máximo 50 caracteres.");
                    }
                } while (string.IsNullOrEmpty(Autor) || Autor.Length > 50);

                int? Ano = null;
                do
                {
                    Console.WriteLine("*Digite o ano do livro (somente numeros): ");
                    string input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("O campo do ano não pode estar vazio.");
                    }
                    else if (input.Length != 4)
                    {
                        Console.WriteLine("O ano deve ter 4 caracteres");
                    }
                    else if (!int.TryParse(input, out int value))
                    {
                        Console.WriteLine("Valor de rg inválido.");
                    }
                    else
                    {
                        Ano = value;
                    }
                } while (!Ano.HasValue);

                string Genero;
                do
                {
                    Console.WriteLine("*Digite o Genero do livro: ");
                    Genero = Console.ReadLine();

                    if (string.IsNullOrEmpty(Genero))
                    {
                        Console.WriteLine("O campo Genero não pode estar vazio.");
                    }
                    else if (Genero.Length > 100)
                    {
                        Console.WriteLine("O campo Genero deve ter no máximo 100 caracteres.");
                    }
                } while (string.IsNullOrEmpty(Genero) || Genero.Length > 100);

                string Editora;
                do
                {
                    Console.WriteLine("*Digite o Editora do livro: ");
                    Editora = Console.ReadLine();

                    if (string.IsNullOrEmpty(Editora))
                    {
                        Console.WriteLine("O campo Editora não pode estar vazio.");
                    }
                    else if (Editora.Length > 100)
                    {
                        Console.WriteLine("O campo Editora deve ter no máximo 100 caracteres.");
                    }
                } while (string.IsNullOrEmpty(Editora) || Editora.Length > 100);

                int? Quantidade = null;
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
                        Console.WriteLine("A Quantidade deve ter no máximo 1000 caracteres");
                    }
                    else
                    {
                        Quantidade = inputNumber;
                    }
                } while (!Quantidade.HasValue);

                var cmd = new MySqlCommand();
                cmd.Connection = crud;

                cmd.CommandText = "INSERT INTO Livro(Titulo, Autor, Ano, Genero, Editora, Quantidade) " +

                                $"VALUES('{Titulo}', '{Autor}', {Ano}, '{Genero}', '{Editora}', {Quantidade})";

                cmd.ExecuteNonQuery();

                Console.WriteLine("Inserção concluída com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        static Boolean ListarLivros()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("*Listar livros \n\n ");

                using var crud = new MySqlConnection(cs);
                crud.Open();

                var cmd = new MySqlCommand("SELECT * FROM Livro", crud);
                using var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine("Lista de Livros:");
                    while (reader.Read())
                    {
                        int ID = reader.GetInt32("ID");
                        string Titulo = reader.GetString("Titulo");
                        string Autor = reader.GetString("Autor");

                        int Ano = reader.GetInt32("Ano");
                        string Genero = reader.GetString("Genero");
                        string Editora = reader.GetString("Editora");
                        int Quantidade = reader.GetInt32("Quantidade");

                        Console.WriteLine($"ID: {ID}, Nome: {Titulo}, Autor: {Autor}, Ano: {Ano}, Genero: {Genero}, Editora: {Editora}, Quantidade: {Quantidade}");
                    }
                    return true;
                }
                else
                {
                    Console.WriteLine("Nenhum Livro cadastrado.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                return false;
            }
        }


        static void AtualizarLivro()
        {
            try
            {
                Console.Clear();
                bool retorno = ListarLivros();

                if(retorno)
                {
                    long? ID = null;
                    do
                    {
                        Console.WriteLine("\n\n*Atualizar livros \n\n ");

                        Console.WriteLine("*Digite o RGM do aluno que deseja atualizar: ");
                        string input = Console.ReadLine();

                        if (string.IsNullOrEmpty(input))
                        {
                            Console.WriteLine("O campo ID não pode estar vazio.");
                        }
                        else if (!long.TryParse(input, out long value))
                        {
                            Console.WriteLine("Valor de ID inválido.");
                        }
                        else
                        {
                            ID = value;
                        }
                    } while (!ID.HasValue);

                    using var crud = new MySqlConnection(cs);
                    crud.Open();

                    var cmd = new MySqlCommand();
                    cmd.Connection = crud;

                    string Titulo;
                    do
                    {
                        Console.WriteLine("*Digite o nome do Livro: ");
                        Titulo = Console.ReadLine();

                        if (string.IsNullOrEmpty(Titulo))
                        {
                            Console.WriteLine("O campo Livro não pode estar vazio.");
                        }
                        else if (Titulo.Length > 50)
                        {
                            Console.WriteLine("O campo Livro deve ter no máximo 50 caracteres.");
                        }
                    } while (string.IsNullOrEmpty(Titulo) || Titulo.Length > 50);


                    string Autor;
                    do
                    {
                        Console.WriteLine("*Digite o nome do Autor: ");
                        Autor = Console.ReadLine();

                        if (string.IsNullOrEmpty(Titulo))
                        {
                            Console.WriteLine("O campo Autor não pode estar vazio.");
                        }
                        else if (Autor.Length > 50)
                        {
                            Console.WriteLine("O campo Autor deve ter no máximo 50 caracteres.");
                        }
                    } while (string.IsNullOrEmpty(Autor) || Autor.Length > 50);

                    int? Ano = null;
                    do
                    {
                        Console.WriteLine("*Digite o ano do livro (somente numeros): ");
                        string input = Console.ReadLine();

                        if (string.IsNullOrEmpty(input))
                        {
                            Console.WriteLine("O campo do ano não pode estar vazio.");
                        }
                        else if (input.Length != 4)
                        {
                            Console.WriteLine("O ano deve ter 4 caracteres");
                        }
                        else if (!int.TryParse(input, out int value))
                        {
                            Console.WriteLine("Valor de rg inválido.");
                        }
                        else
                        {
                            Ano = value;
                        }
                    } while (!Ano.HasValue);

                    string Genero;
                    do
                    {
                        Console.WriteLine("*Digite o Genero do livro: ");
                        Genero = Console.ReadLine();

                        if (string.IsNullOrEmpty(Genero))
                        {
                            Console.WriteLine("O campo Genero não pode estar vazio.");
                        }
                        else if (Genero.Length > 100)
                        {
                            Console.WriteLine("O campo Genero deve ter no máximo 100 caracteres.");
                        }
                    } while (string.IsNullOrEmpty(Genero) || Genero.Length > 100);

                    string Editora;
                    do
                    {
                        Console.WriteLine("*Digite o Editora do livro: ");
                        Editora = Console.ReadLine();

                        if (string.IsNullOrEmpty(Editora))
                        {
                            Console.WriteLine("O campo Editora não pode estar vazio.");
                        }
                        else if (Editora.Length > 100)
                        {
                            Console.WriteLine("O campo Editora deve ter no máximo 100 caracteres.");
                        }
                    } while (string.IsNullOrEmpty(Editora) || Editora.Length > 100);

                    int? Quantidade = null;
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
                            Console.WriteLine("A Quantidade deve ter no máximo 1000 caracteres");
                        }
                        else
                        {
                            Quantidade = inputNumber;
                        }
                    } while (!Quantidade.HasValue);

                    cmd.CommandText = $"UPDATE Livro SET Titulo = '{Titulo}', Autor = '{Autor}', Ano = {Ano}, Genero = '{Genero}', Editora = '{Editora}', Quantidade = {Quantidade} WHERE ID = {ID}";

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Livro atualizado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Livro não encontrado.");
                    }
                }
                else
                {
                    Console.WriteLine("\nNão há livros para atualizar !\n\nAperte ENTER para voltar");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }


        static void DeletarLivros()
        {
            try
            {
                Console.Clear();
                Boolean retorno = ListarLivros();
                if (retorno)
                {

                    Console.WriteLine("\n\nDeletar Livro \n\n");
                    Console.WriteLine("Digite o ID do aluno que deseja deletar: ");
                    long ID = long.Parse(Console.ReadLine());

                    using var crud = new MySqlConnection(cs);
                    crud.Open();

                    var cmd = new MySqlCommand();
                    cmd.Connection = crud;

                    cmd.CommandText = $"DELETE FROM Livro WHERE ID = {ID}";

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Livro deletado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("livro não encontrado.");
                    }
                }
                else
                {
                    Console.WriteLine("\nNão há livros para deletar !\n\nAperte ENTER para voltar");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}