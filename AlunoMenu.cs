using MySql.Data.MySqlClient;
using System;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace Aula01 {
class AlunoMenu
{
    public void Menu()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("\nSelecione uma operação:");

            Console.WriteLine("\n---------- Aluno ----------\n");

            Console.WriteLine("1. Inserir aluno");
            Console.WriteLine("2. Listar alunos");
            Console.WriteLine("3. Atualizar aluno");
            Console.WriteLine("4. Deletar aluno");
            Console.WriteLine("0. Voltar ao menu\n");

                Console.Write("Opcao: ");
                int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    InserirAluno();
                    break;
                 case 2:
                     ListarAlunos();
                     break;
                // case 3:
                //     AtualizarAluno();
                //     break;
                // case 4:
                //     DeletarAluno();
                //     break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                    break;
            }
        }
    }

    Aluno aluno = new Aluno();
    AlunoDao DAO = new AlunoDao();

    public void InserirAluno()
    {
        try
        {
           
            do
            {
                Console.Clear();
                Console.WriteLine("Inserir Aluno \n\n");
                Console.WriteLine("*Digite o nome do aluno: ");
                aluno.setNome(Console.ReadLine());
                

                if (string.IsNullOrEmpty(aluno.getNome()))
                {
                    Console.WriteLine("O campo Nome não pode estar vazio.");
                }
                else if (aluno.getNome().Length > 50)
                {
                    Console.WriteLine("O campo nome deve ter no máximo 50 caracteres.");
                }

                
            } while (string.IsNullOrEmpty(aluno.getNome()) || aluno.getNome().Length > 50);


            long rgm = 0;
            do
            {
                Console.WriteLine("*Digite o RGM do aluno (somente números): ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("O campo RGM não pode estar vazio.");
                }
                else if (input.Length != 11)
                {
                    Console.WriteLine("O RGM deve ter exatamente 11 caracteres.");
                }
                else if (!long.TryParse(input, out rgm))
                {
                    Console.WriteLine("Valor de RGM inválido.");
                }
                else
                {
                    aluno.setRGM(rgm);
                }
            } while (rgm == 0);


            string dataNasc;
            DateTime dataNascimento;
            do
            {
                Console.WriteLine("*Digite a data de nascimento do aluno (YYYY-MM-DD): ");
                dataNasc = Console.ReadLine();

                if (!DateTime.TryParseExact(dataNasc, "yyyy-MM-dd", null, DateTimeStyles.None, out dataNascimento))
                {
                    Console.WriteLine("Formato de data inválido.");
                } else{
                    aluno.setDataNas(dataNascimento);                  
                }
            } while (dataNascimento == DateTime.MinValue);

            do
            {
                Console.WriteLine("*Digite o curso do aluno: ");
                aluno.setCurso(Console.ReadLine());

                if (string.IsNullOrEmpty(aluno.getCurso()))
                {
                    Console.WriteLine("O campo curso não pode estar vazio.");
                }else if(aluno.getCurso().Length > 100 )
                {
                    Console.WriteLine("O campo curso deve ter no máximo 100 caracteres.");
                }
            } while (string.IsNullOrEmpty(aluno.getCurso()) || aluno.getCurso().Length > 100);

            do
            {
                Console.WriteLine("*O aluno é bolsista? (1 para sim, 0 para não): ");
                string input = Console.ReadLine();

                if (input != "1" && input != "0")
                {
                    Console.WriteLine("O campo bolsista deve ter o valor '0' ou '1'.");
                }
                else
                {
                    aluno.setBolsista(input);
                }
            } while (aluno.getBolsista() != "1" && aluno.getBolsista() != "0");

            long? rg = null;
            do
            {
                Console.WriteLine("*Digite o rg do aluno (somente numeros): ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("O campo rg não pode estar vazio.");
                }
                else if (input.Length > 11)
                {
                    Console.WriteLine("O rg deve ter 11 caracteres ou menos.");
                }
                else if (!long.TryParse(input, out long value))
                {
                    Console.WriteLine("Valor de rg inválido.");
                }
                else
                {
                    rg = value;
                    aluno.setRG(value);
                }
            } while (!rg.HasValue);
            
            Console.WriteLine("*Digite o gênero do aluno: ");
            string genero = Console.ReadLine();

            DAO.InserirAlunoDAO(aluno.getNome(), aluno.getRGM(), aluno.getDataNas(), aluno.getCurso(), aluno.getBolsista(), aluno.getRG(), aluno.getGenero());

            Console.WriteLine("Inserção concluída com sucesso.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    public void ListarAlunos()
    {
        try
        {
            Console.Clear();

            List<Aluno> alunos = DAO.ListarAlunoDAO();

            if (alunos.Count > 0)
            {
                Console.WriteLine("Lista de alunos:");
                foreach (Aluno aluno in alunos)
                {
                    // Exibir as informações de cada aluno
                    Console.WriteLine($"Nome: {aluno.getNome()}, RGM: {aluno.getRGM()}, Data de Nascimento: {aluno.getDataNas()}, Curso: {aluno.getCurso()}, Bolsista: {aluno.getBolsista()}, RG: {aluno.getRG()}, Gênero: {aluno.getGenero()}");
                    
                }
                
            }
            else
            {
                Console.WriteLine("Nenhum aluno cadastrado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}"); 
        }
    }

    // static void AtualizarAluno()
    // {
    //     try
    //     {
    //         Console.Clear();
    //         Boolean retorno = ListarAlunos();

    //             if (retorno)
    //             {
    //                 long? rgm = null;
    //                 do
    //                 {

    //                     Console.WriteLine("\n\nAtualizar Aluno \n\n");
    //                     Console.WriteLine("*Digite o RGM do aluno que deseja atualizar: ");
    //                     string input = Console.ReadLine();

    //                     if (string.IsNullOrEmpty(input))
    //                     {
    //                         Console.WriteLine("O campo RGM não pode estar vazio.");
    //                     }
    //                     else if (input.Length != 11)
    //                     {
    //                         Console.WriteLine("O RGM deve ter exatamente 11 caracteres.");
    //                     }
    //                     else if (!long.TryParse(input, out long value))
    //                     {
    //                         Console.WriteLine("Valor de RGM inválido.");
    //                     }
    //                     else
    //                     {
    //                         rgm = value;
    //                     }
    //                 } while (!rgm.HasValue);

                    

                   

    //                 string novoNome;
    //                 do
    //                 {
    //                     Console.WriteLine("*Digite o nome do aluno: ");
    //                     novoNome = Console.ReadLine();

    //                     if (string.IsNullOrEmpty(novoNome))
    //                     {
    //                         Console.WriteLine("O campo Nome não pode estar vazio.");
    //                     }
    //                     else if (novoNome.Length > 50)
    //                     {
    //                         Console.WriteLine("O campo nome deve ter no máximo 50 caracteres.");
    //                     }
    //                 } while (string.IsNullOrEmpty(novoNome) || novoNome.Length > 50);

    //                 string novoDataNasc;
    //                 do
    //                 {
    //                     Console.WriteLine("*Digite a nova data de nascimento do aluno (YYYY-MM-DD): ");
    //                     novoDataNasc = Console.ReadLine();

    //                     if (!DateTime.TryParseExact(novoDataNasc, "yyyy-MM-dd", null, DateTimeStyles.None, out _))
    //                     {
    //                         Console.WriteLine("Formato de data inválido. Por favor, insira a data no formato YYYY-MM-DD.");
    //                     }
    //                 } while (!DateTime.TryParseExact(novoDataNasc, "yyyy-MM-dd", null, DateTimeStyles.None, out _));

    //                 string novoCurso;
    //                 do
    //                 {
    //                     Console.WriteLine("*Digite o curso do aluno: ");
    //                     novoCurso = Console.ReadLine();

    //                     if (string.IsNullOrEmpty(novoCurso))
    //                     {
    //                         Console.WriteLine("O campo curso não pode estar vazio.");
    //                     }
    //                     else if (novoCurso.Length > 100)
    //                     {
    //                         Console.WriteLine("O campo curso deve ter no máximo 100 caracteres.");
    //                     }
    //                 } while (string.IsNullOrEmpty(novoCurso) || novoCurso.Length > 100);

    //                 string novoBolsista;
    //                 do
    //                 {
    //                     Console.WriteLine("*O aluno é bolsista? (1 para sim, 0 para não): ");
    //                     novoBolsista = Console.ReadLine();

    //                     if (novoBolsista.Length > 1)
    //                     {
    //                         Console.WriteLine("O campo bolsista deve ter no máximo 1 caracteres.");
    //                     }
    //                 } while (novoBolsista.Length > 1);

    //                 long? novoRG = null;
    //                 do
    //                 {
    //                     Console.WriteLine("*Digite o rg do aluno (somente numeros): ");
    //                     string input = Console.ReadLine();

    //                     if (string.IsNullOrEmpty(input))
    //                     {
    //                         Console.WriteLine("O campo rg não pode estar vazio.");
    //                     }
    //                     else if (input.Length > 11)
    //                     {
    //                         Console.WriteLine("O rg deve ter 11 caracteres ou menos.");
    //                     }
    //                     else if (!long.TryParse(input, out long value))
    //                     {
    //                         Console.WriteLine("Valor de rg inválido.");
    //                     }
    //                     else
    //                     {
    //                         novoRG = value;
    //                     }
    //                 } while (!novoRG.HasValue);

    //                 Console.WriteLine("*Digite o gênero do aluno: ");
    //                 string novoGenero = Console.ReadLine();

    //                 cmd.CommandText = $"UPDATE Aluno SET Nome = '{novoNome}', DataNasc = '{novoDataNasc}', Curso = '{novoCurso}', Bolsista = {novoBolsista}, RG = {novoRG}, Genero = '{novoGenero}' WHERE Rgm = {rgm}";

    //                 int rowsAffected = cmd.ExecuteNonQuery();

    //                 if (rowsAffected > 0)
    //                 {
    //                     Console.WriteLine("Aluno atualizado com sucesso!");
    //                 }
    //                 else
    //                 {
    //                     Console.WriteLine("Aluno não encontrado.");
    //                 }
    //             }
    //             else
    //             {
    //                 Console.WriteLine("\nNão há alunos para atualizar !\n\nAperte ENTER para voltar");
    //                 Console.ReadLine();

    //             }


    //         }
    //     catch (Exception ex)
    //     {
    //         Console.WriteLine($"Erro: {ex.Message}");
    //     }
    // }

    // static void DeletarAluno()
    // {
    //     try
    //     {
    //         Console.Clear();
    //         Boolean retorno = ListarAlunos();
    //             if (retorno)
    //             {
    //                 Console.WriteLine("\n\nDeletar Aluno \n\n ");
    //                 Console.WriteLine("Digite o RGM do aluno que deseja deletar: ");
    //                 long rgm = long.Parse(Console.ReadLine());

    //                 using var crud = new MySqlConnection(cs);
    //                 crud.Open();

    //                 var cmd = new MySqlCommand();
    //                 cmd.Connection = crud;

    //                 cmd.CommandText = $"DELETE FROM Aluno WHERE Rgm = {rgm}";

    //                 int rowsAffected = cmd.ExecuteNonQuery();

    //                 if (rowsAffected > 0)
    //                 {
    //                     Console.WriteLine("Aluno deletado com sucesso!");
    //                 }
    //                 else
    //                 {
    //                     Console.WriteLine("Aluno não encontrado.");
    //                 }

    //             }
    //             else
    //             {
    //                 Console.WriteLine("\nNão há alunos para deletar !\n\nAperte ENTER para voltar");
    //                 Console.ReadLine();

    //             }


    //         }
    //     catch (Exception ex)
    //     {
    //         Console.WriteLine($"Erro: {ex.Message}");
    //     }
    // }
}
}