using Aula_01.menu;

namespace Aula01;

public class ListarAlunos : Command
{
    Aluno aluno = new Aluno();
    AlunoDao DAO = new AlunoDao();
    
    public void Executar()
    {
        try
        {
            Console.Clear();
            List<Aluno> alunos = DAO.ListarAlunoDAO();
            if (alunos.Count > 0)
            {
                Console.WriteLine("Consulta executada com sucesso!\n");
                Console.WriteLine("Lista de alunos:");
                foreach (Aluno aluno in alunos)
                {
                    Console.WriteLine($"Nome: {aluno.getNome()}, RGM: {aluno.getRGM()}, Data de Nascimento: {aluno.getDataNas()}, Curso: {aluno.getCurso()}, Bolsista: {aluno.getBolsista()}, RG: {aluno.getRG()}, Gênero: {aluno.getGenero()}");      
                }
                Console.WriteLine("\nPresione Enter para continuar");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Nenhum aluno cadastrado.");
                Console.WriteLine("\nPresione Enter para continuar");
                Console.ReadLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}