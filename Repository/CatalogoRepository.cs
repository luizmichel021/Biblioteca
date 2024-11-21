using MySql.Data.MySqlClient;
using Biblioteca.Models;
using Biblioteca.Database;
using Microsoft.VisualBasic;

namespace Biblioteca.Repository
{
    public class CatalogoRepository
    {
        private readonly Connection db = new Connection();   
        

            // A Função adicionar retornara um inteiro, o conteudo desse inteiro é a quantidade de linhas afetadas.
        public int adicionar(Catalogo catalogo) 
        {

            using (var connection = db.GetConnection())
            {
                connection.Open();
                var cmd = new MySqlCommand("INSERT INTO Catalogo (Titulo, Autor, Ano, Genero, Pags) VALUES (@Titulo, @Autor, @Ano, @Genero, @Pags)", connection);
                cmd.Parameters.AddWithValue("@Titulo", catalogo.Titulo);
                cmd.Parameters.AddWithValue("@Autor", catalogo.Autor);
                cmd.Parameters.AddWithValue("@Ano", catalogo.Ano);
                cmd.Parameters.AddWithValue("@Genero", catalogo.Genero);
                cmd.Parameters.AddWithValue("@Pags", catalogo.Pags);
                var resultado = cmd.ExecuteNonQuery();
                return resultado;
            }
        }


        public Catalogo obterPorID(int id)
        {
            using (var connection = db.GetConnection())
            {
                connection.Open();
                var cmd = new MySqlCommand("SELECT * FROM Catalogo WHERE ID = @ID", connection);
                cmd.Parameters.AddWithValue("@ID", id);
                var ler = cmd.ExecuteReader();

                if (ler.Read())
                {
                    return new Catalogo
                    {
                        ID = ler.GetInt32("ID"),
                        Titulo = ler.GetString("Titulo"),
                        Autor = ler.GetString("Autor"),
                        Genero = ler.GetString("Genero"),
                        Pags = ler.GetInt32("Pags")
                    };
                }
                else
                {
                    return null;
                }
            }
        }

        public int excluirPorID(int id)
        {
            using (var connection = db.GetConnection())
            {
                connection.Open();
                var cmd = new MySqlCommand("DELETE FROM Catalogo WHERE ID = @ID", connection);
                cmd.Parameters.AddWithValue("@ID", id);

                int rowsAffected = cmd.ExecuteNonQuery();

               return rowsAffected;

            }
        }

        // public List<Catalogo> listar()
        // {
        //     var catalogoList = new List<Catalogo>();

        //     using (var connection = db.GetConnection())
        //     {
        //         connection.Open();
        //         var cmd = new MySqlCommand("SELECT * FROM Catalogo", connection);
        //         var ler = cmd.ExecuteReader();

        //         while (ler.Read())
        //         {
        //             var catalogo = new Catalogo
        //             {
        //                 ID = ler.GetInt32("ID"),
        //                 Titulo = ler.GetString("Titulo"),
        //                 Autor = ler.GetString("Autor"),
        //                 Ano = ler.GetInt32("Ano"),
        //                 Genero = ler.GetString("Genero"),
        //                 Pags = ler.GetInt32("Pags")
        //             };
        //             catalogoList.Add(catalogo);
        //         }
        //         foreach (var item in catalogoList)
        //         {
        //             Console.WriteLine("ID: " + item.ID);
        //             Console.WriteLine("Titulo: " + item.Titulo);
        //             Console.WriteLine("Autor: " + item.Autor);
        //             Console.WriteLine("Ano: " + item.Ano);
        //             Console.WriteLine("Genero: " + item.Genero);
        //             Console.WriteLine("Pags: " + item.Pags);
        //             Console.WriteLine(new string('-', 20)); // Separador entre os itens
        //         }
        //     }
        //     return catalogoList;
        // }
        
    
        

        public void atualizar(int id, string? titulo = null, string? autor = null, string? genero = null, int? ano = null)
        {
            using (var connection = db.GetConnection())
            {
                connection.Open();
                var sql = "UPDATE Catalogo SET ";
                var parameters = new List<MySqlParameter>();

                if (titulo != null)
                {
                    sql += "Titulo = @Titulo, ";
                    parameters.Add(new MySqlParameter("@Titulo", titulo));
                }

                if (autor != null)
                {
                    sql += "Autor = @Autor, ";
                    parameters.Add(new MySqlParameter("@Autor", autor));
                }

                if (genero != null)
                {
                    sql += "Genero = @Genero, ";
                    parameters.Add(new MySqlParameter("@Genero", genero));
                }

                if (ano.HasValue)
                {
                    sql += "Ano = @Ano, ";
                    parameters.Add(new MySqlParameter("@Ano", ano.Value));
                }

                // tira virgula e espaço
                sql = sql.TrimEnd(',', ' ');

                // Adiciona o WHERE
                sql += " WHERE ID = @ID";
                parameters.Add(new MySqlParameter("@ID", id));

                var cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddRange(parameters.ToArray());

                cmd.ExecuteNonQuery();
            }
        }
    }
}