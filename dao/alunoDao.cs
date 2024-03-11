using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Aula01
{
    class AlunoDao
    {
        public void InserirAlunoDAO(string nome, long rgm, DateTime dataNasc, string curso, string bolsista, long rg, string genero)
        {
            Conexao conexao = new Conexao();

            string consulta = $"INSERT INTO Aluno(Nome, Rgm, DataNasc, Curso, Bolsista, RG, Genero) " +
                              $"VALUES('{nome}', {rgm}, '{dataNasc:yyyy-MM-dd}', '{curso}', {bolsista}, {rg}, '{genero}')";
             MySqlCommand comando = new MySqlCommand(consulta);
             conexao.ExecutarConsulta(comando);
        }

        public List<Aluno> ListarAlunoDAO()
        {
            List<Aluno> alunos = new List<Aluno>();
            try
            {
                Conexao conexao = new Conexao();
                string consulta = "SELECT * FROM Aluno";
                using (MySqlConnection conexaoMySQL = Conexao.CreateDataBaseConnection())
                {
                    conexaoMySQL.Open(); 
                    MySqlCommand comando = new MySqlCommand(consulta, conexaoMySQL); 
                    MySqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        Aluno aluno = new Aluno();
                        aluno.setNome(reader.GetString("Nome"));
                        aluno.setRGM(reader.GetInt64("Rgm"));
                        aluno.setDataNas(reader.GetDateTime("DataNasc"));
                        aluno.setCurso(reader.GetString("Curso"));
                        aluno.setBolsista(reader.GetBoolean("Bolsista") ? "Sim" : "Não");
                        aluno.setRG(reader.GetInt64("RG"));
                        aluno.setGenero(reader.GetString("Genero"));
                        alunos.Add(aluno);
                    }
                    reader.Close();
                } 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao executar a consulta: " + ex.Message);
            }
            return alunos;
        }

        public void UpdateAluno(long rgm, string nome, DateTime dataNasc, string curso, string bolsista, long rg, string genero){

            try
            {
                Conexao conexao = new Conexao();
                string consulta = "UPDATE Aluno SET Nome = @Nome, DataNasc = @DataNasc, Curso = @Curso, Bolsista = @Bolsista, RG = @RG, Genero = @Genero WHERE Rgm = @Rgm";
                using (MySqlConnection conexaoMySQL = Conexao.CreateDataBaseConnection())
                {
                    conexaoMySQL.Open();
                    MySqlCommand comando = new MySqlCommand(consulta, conexaoMySQL);

                    Aluno aluno = new Aluno();
                    comando.Parameters.AddWithValue("@Nome", nome);
                    comando.Parameters.AddWithValue("@DataNasc", dataNasc);
                    comando.Parameters.AddWithValue("@Curso", curso);
                    comando.Parameters.AddWithValue("@Bolsista", bolsista);
                    comando.Parameters.AddWithValue("@RG", rg);
                    comando.Parameters.AddWithValue("@Genero", genero);
                    comando.Parameters.AddWithValue("@Rgm", rgm);

                    int linhasAfetadas = comando.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                    {
                        Console.WriteLine("Usuario atualizado com sucesso!\n");
                        Console.WriteLine("Pressione Enter para continuar");
                    }
                    else
                    {
                        Console.WriteLine("Usuario nao encontrado!");
                        Console.WriteLine("Pressione Enter para continuar");
                    }
                }


                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        public void DeletarAluno(long rgm)
        {
            try
            {
                Conexao conexao = new Conexao();
                string consulta = "DELETE FROM Aluno WHERE RGM = @Rgm";
                MySqlCommand comando = new MySqlCommand(consulta);
                comando.Parameters.AddWithValue("@Rgm", rgm);
                conexao.ExecutarConsulta(comando);
                Console.WriteLine("Aluno deletado com sucesso!");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}