using Aula_01.menu;

namespace Aula01;

public class ListarLivros : Command
{
    
    Livro livro = new Livro();
    LivroDAO DAO = new LivroDAO();
    
    public void Executar()
    {
        try
        {
            Console.Clear();

            List<Livro> livros = DAO.ListarLivroDAO();

            if (livros.Count > 0)
            {
                Console.WriteLine("Consulta executada com sucesso!\n");
                Console.WriteLine("Lista de livros:");
                    
                foreach (Livro livro in livros)
                {
                    Console.WriteLine($"ISBN: {livro.getISBN()}, Titulo: {livro.getTitulo()}, Autor: {livro.getAutor()}, Ano: {livro.getAno()}, Genero: {livro.getGenero()}, Genero: {livro.getGenero()}, Editocao: {livro.getEdicao()}, Quantidade: {livro.getQuantidade()}");
                }
                Console.WriteLine("\nPresione Enter para continuar");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Nenhum livro cadastrado.");
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