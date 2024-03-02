using MySql.Data.MySqlClient;
using System;
using System.Globalization;

class Aluno
{
    static string cs = @"server=sql.freedb.tech;userid=freedb_Mateus;password=Nt8pd!Qz#UktKES;database=freedb_Design-Pattern";

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nSelecione uma operação:");
            Console.WriteLine("1. Inserir aluno");
            Console.WriteLine("2. Listar alunos");
            Console.WriteLine("3. Atualizar aluno");
            Console.WriteLine("4. Deletar aluno");
            Console.WriteLine("5. Sair");

            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    InserirAluno();
                    break;
                case 2:
                    ListarAlunos();
                    break;
                case 3:
                    AtualizarAluno();
                    break;
                case 4:
                    DeletarAluno();
                    break;
                case 5:
                    Console.WriteLine("Saindo...");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                    break;
            }
        }
    }

    static void InserirAluno()
    {
        try
        {
            using var crud = new MySqlConnection(cs);
            crud.Open();

            string nome;
            do
            {
                Console.WriteLine("*Digite o nome do aluno: ");
                nome = Console.ReadLine();

                if (string.IsNullOrEmpty(nome))
                {
                    Console.WriteLine("O campo Nome não pode estar vazio.");
                }
                else if (nome.Length > 50)
                {
                    Console.WriteLine("O campo nome deve ter no máximo 50 caracteres.");
                }
            } while (string.IsNullOrEmpty(nome) || nome.Length > 50);


            long? rgm = null;
            do
            {
                Console.WriteLine("*Digite o RGM do aluno (somente numeros): ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("O campo RGM não pode estar vazio.");
                }
                else if (input.Length != 11)
                {
                    Console.WriteLine("O RGM deve ter exatamente 11 caracteres.");
                }
                else if (!long.TryParse(input, out long value))
                {
                    Console.WriteLine("Valor de RGM inválido.");
                }
                else
                {
                    rgm = value;
                }
            } while (!rgm.HasValue);

            string dataNasc;
            DateTime dataNascimento;

            do
            {
                Console.WriteLine("*Digite a data de nascimento do aluno (YYYY-MM-DD): ");
                dataNasc = Console.ReadLine();

                if (!DateTime.TryParseExact(dataNasc, "yyyy-MM-dd", null, DateTimeStyles.None, out dataNascimento))
                {
                    Console.WriteLine("Formato de data inválido.");
                }
            } while (dataNascimento == DateTime.MinValue);

            string curso;
            do
            {
                Console.WriteLine("*Digite o curso do aluno: ");
                curso = Console.ReadLine();

                if (string.IsNullOrEmpty(curso))
                {
                    Console.WriteLine("O campo curso não pode estar vazio.");
                }else if(curso.Length < 100 )
                {
                    Console.WriteLine("O campo deve ter no máximo 100 caracteres.");
                }
            } while (string.IsNullOrEmpty(curso) || curso.Length > 100);

            Console.WriteLine("O aluno é bolsista? (1 para sim, 0 para não): ");
            int bolsista = int.Parse(Console.ReadLine());

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
                }
            } while (!rg.HasValue);
            
            Console.WriteLine("*Digite o gênero do aluno: ");
            string genero = Console.ReadLine();

            var cmd = new MySqlCommand();
            cmd.Connection = crud;

            cmd.CommandText = "INSERT INTO Aluno(Nome, Rgm, DataNasc, Curso, Bolsista, RG, Genero) " +
                            $"VALUES('{nome}', {rgm}, '{dataNasc}', '{curso}', {bolsista}, {rg}, '{genero}')";

            cmd.ExecuteNonQuery();

            Console.WriteLine("Inserção concluída com sucesso.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static void ListarAlunos()
    {
        try
        {
            using var crud = new MySqlConnection(cs);
            crud.Open();

            var cmd = new MySqlCommand("SELECT * FROM Aluno", crud);
            using var reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                Console.WriteLine("Lista de alunos:");
                while (reader.Read())
                {
                    string nome = reader.GetString("Nome");
                    long rgm = reader.GetInt64("Rgm");
                    DateTime dataNasc = reader.GetDateTime("DataNasc");
                    string curso = reader.GetString("Curso");
                    bool bolsista = reader.GetBoolean("Bolsista");
                    long rg = reader.GetInt64("RG");
                    string genero = reader.GetString("Genero");

                    Console.WriteLine($"Nome: {nome}, RGM: {rgm}, Data de Nascimento: {dataNasc}, Curso: {curso}, Bolsista: {bolsista}, RG: {rg}, Gênero: {genero}");
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


    static void AtualizarAluno()
    {
        try
        {
            ListarAlunos();

            Console.WriteLine("Digite o RGM do aluno que deseja atualizar: ");
            long rgm = long.Parse(Console.ReadLine());

            using var crud = new MySqlConnection(cs);
            crud.Open();

            var cmd = new MySqlCommand();
            cmd.Connection = crud;

            Console.WriteLine("Digite o novo nome do aluno: ");
            string novoNome = Console.ReadLine();
            Console.WriteLine("Digite a nova data de nascimento do aluno (YYYY-MM-DD): ");
            string novaDataNasc = Console.ReadLine();
            Console.WriteLine("Digite o novo curso do aluno: ");
            string novoCurso = Console.ReadLine();
            Console.WriteLine("O aluno é bolsista? (1 para sim, 0 para não): ");
            int novoBolsista = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o novo RG do aluno: ");
            long novoRG = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o novo gênero do aluno: ");
            string novoGenero = Console.ReadLine();

            cmd.CommandText = $"UPDATE Aluno SET Nome = '{novoNome}', DataNasc = '{novaDataNasc}', Curso = '{novoCurso}', Bolsista = {novoBolsista}, RG = {novoRG}, Genero = '{novoGenero}' WHERE Rgm = {rgm}";

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Console.WriteLine("Aluno atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Aluno não encontrado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static void DeletarAluno()
    {
        try
        {
            ListarAlunos();

            Console.WriteLine("Digite o RGM do aluno que deseja deletar: ");
            long rgm = int.Parse(Console.ReadLine());

            using var crud = new MySqlConnection(cs);
            crud.Open();

            var cmd = new MySqlCommand();
            cmd.Connection = crud;

            cmd.CommandText = $"DELETE FROM Aluno WHERE Rgm = {rgm}";

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Console.WriteLine("Aluno deletado com sucesso!");
            }
            else
            {
                Console.WriteLine("Aluno não encontrado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}