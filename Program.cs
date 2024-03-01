using MySql.Data.MySqlClient;
using System.Reflection.PortableExecutable;

string cs = @"server=sql.freedb.tech;userid=freedb_Mateus;password=Nt8pd!Qz#UktKES;database=freedb_Design-Pattern";

try
{
    using var con = new MySqlConnection(cs);
    con.Open();

    Console.WriteLine($"MySQL version: {con.ServerVersion}");

    var cmd = new MySqlCommand();
    cmd.Connection = con;

    cmd.CommandText = "INSERT INTO Aluno(Nome, Rgm, DataNasc, Curso, Bolsista, RG, Genero) VALUES('mateus teixeira',123456789, '2004-05-29', 'engenharia de software', 0, 1234567, 'masculino')";
    cmd.ExecuteNonQuery();

    Console.WriteLine("Inserção concluída com sucesso.");
}
catch (Exception ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
}