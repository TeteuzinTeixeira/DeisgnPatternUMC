using Aula_01.menu;

namespace Aula01;

public class DeletarLivro : Command
{
    
    Livro livro = new Livro();
    LivroDAO DAO = new LivroDAO();

    private ListarLivros listarLivros;

    public void Executar()
    {
        Console.Clear();

        try
        {
                
            Console.WriteLine("Deletar Livro\n");
            Console.WriteLine("Digite o ISBN do livro que deseja deletar: ");
            long ISBN = long.Parse(Console.ReadLine());
            livro.setISBN(ISBN);
            DAO.DeletarLivro(livro.getISBN());
                
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}