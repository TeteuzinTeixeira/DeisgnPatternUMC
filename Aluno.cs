using MySql.Data.MySqlClient;
using System;

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

            Console.WriteLine("Digite o nome do aluno: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o RGM do aluno: ");
            long rgm = long.Parse(Console.ReadLine());
            Console.WriteLine("Digite a data de nascimento do aluno (YYYY-MM-DD): ");
            string dataNasc = Console.ReadLine();
            Console.WriteLine("Digite o curso do aluno: ");
            string curso = Console.ReadLine();
            Console.WriteLine("O aluno é bolsista? (1 para sim, 0 para não): ");
            int bolsista = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o RG do aluno: ");
            long rg = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o gênero do aluno: ");
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