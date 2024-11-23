using MySql.Data.MySqlClient;
using Biblioteca.Models;
using Biblioteca.Database;
using Biblioteca.Utils;
using Microsoft.VisualBasic;
using Biblioteca.Utils;

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
                var cmd = new MySqlCommand ("INSERT INTO Catalogo (Titulo, Autor, Ano, Genero, Pags) VALUES (@Titulo, @Autor, @Ano, @Genero, @Pags)",connection);;
                cmd.Parameters.AddWithValue("@Titulo", catalogo.Titulo);
                cmd.Parameters.AddWithValue("@Autor", catalogo.Autor);
                cmd.Parameters.AddWithValue("@Ano", catalogo.Ano);
                cmd.Parameters.AddWithValue("@Genero", catalogo.Genero);
                cmd.Parameters.AddWithValue("Pags", catalogo.Pags);
                var rows = cmd.ExecuteNonQuery();
                return rows;
                
            }
        }

        public Catalogo buscaCatalogo(int id)
        {
            using (var connection = db.GetConnection())
            {
                connection.Open();
                var cmd = new MySqlCommand("SELECT * FROM Catalogo WHERE ID = @ID", connection);
                cmd.Parameters.AddWithValue("@ID", id);
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    var mapper = new Mapper();
                    return mapper.mapear(reader);
                }
                else
                {
                    return null;
                }
                                
            }
        }

        public int excluir(int id)
        {
            using (var connection = db.GetConnection())
            {
                connection.Open();
                var cmd = new MySqlCommand("DELETE FROM Catalogo WHERE ID = @ID", connection);
                cmd.Parameters.AddWithValue("ID", id);
                var rows = cmd.ExecuteNonQuery();
                return rows;

            }
        }

        public void atualizar(int id, string? titulo = null, string? autor = null, string? genero = null, int? ano = null, int? pags = null)
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

                if (pags.HasValue)
                {
                    sql += "Pags = @Pags, ";
                    parameters.Add(new MySqlParameter("@Pags", pags.Value));
                }

                // Remove a última vírgula e espaço
                sql = sql.TrimEnd(',', ' ');

                // Adiciona a cláusula WHERE
                sql += " WHERE ID = @ID";
                parameters.Add(new MySqlParameter("@ID", id));

                var cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddRange(parameters.ToArray());

                cmd.ExecuteNonQuery();
                

            }
        }
        public List<int> buscaIds()
        {
            var ids = new List<int>();

            using (var connection = db.GetConnection())
            {
                connection.Open();
                var cmd = new MySqlCommand("SELECT ID FROM Livro", connection);
                using (var reader = cmd.ExecuteReader())
                {   
                    while (reader.Read())
                    {
                        ids.Add(reader.GetInt32("ID"));
                    }
                }
            }

           return ids; 
    
        }
    
    }
}