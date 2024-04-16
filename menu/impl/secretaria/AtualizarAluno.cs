using System.Globalization;

namespace Aula01;

public class AtualizarAluno
{
    
    Aluno aluno = new Aluno();
    AlunoDao DAO = new AlunoDao();
    
    public void Executar()
        {
            try
            {

                long rgm = 0;
                do
                {

                    Console.WriteLine("*Atualizar dados do aluno:\n");
                    Console.WriteLine("*Digite o RGM do aluno  (11 digitos): ");
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

                do
                {
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
                    else
                    {
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
                    }
                    else if (aluno.getCurso().Length > 100)
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
                aluno.setGenero(Console.ReadLine());

                DAO.UpdateAluno(aluno.getRGM(), aluno.getNome(), aluno.getDataNas(), aluno.getCurso(), aluno.getBolsista(), aluno.getRG(), aluno.getGenero());

                    
            }
            catch (Exception ex)
            {
                Console.WriteLine($"erro: {ex}");
            }
        }
}