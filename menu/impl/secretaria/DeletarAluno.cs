using Aula_01.menu;

namespace Aula01;

public class DeletarAluno : Command
{
    
    Aluno aluno = new Aluno();
    AlunoDao DAO = new AlunoDao();
    
    public void Executar()
    {
        Console.Clear();
        try
        {
            Console.WriteLine("Deletar Aluno\n");
            Console.WriteLine("Digite o RGM do aluno que deseja deletar: ");
            long rgm = long.Parse(Console.ReadLine());
            aluno.setRGM(rgm);
            DAO.DeletarAluno(aluno.getRGM());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}