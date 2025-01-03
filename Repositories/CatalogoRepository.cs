using MySql.Data.MySqlClient;
using Biblioteca.Models;
using Biblioteca.Database;
using Microsoft.VisualBasic;


namespace Biblioteca.Repository
{
    public class CatalogoRepository : ICatalogoRepository
    {
        private readonly Connection db = new Connection();   

        public int create(Catalogo catalogo) 
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

                var result = cmd.ExecuteNonQuery();

                if (result != 0)
                {
                    var cmd2 = new MySqlCommand("SELECT LAST_INSERT_ID();", connection);
                    var resultId = cmd2.ExecuteScalar();
                    int id = Convert.ToInt32(resultId);
                    return id;
                }
                else
                {
                    return 0;
                } 

                
                
            }
        }
        
        public Catalogo getCatalogo(int id)
        {
            using (var connection = db.GetConnection())
            {
                connection.Open();
                var cmd = new MySqlCommand("SELECT * FROM Catalogo WHERE IDExemplar = @IDExemplar", connection);
                cmd.Parameters.AddWithValue("@IDExemplar", id);
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                     return new Catalogo
                        {
                            IDExemplar = reader.GetInt32("IDExemplar"),
                            Titulo = reader.GetString("Titulo"),
                            Autor = reader.GetString("Autor"),
                            Ano = reader.GetInt32("Ano"),
                            Genero = reader.GetString("Genero"),
                            Pags = reader.GetInt32("Pags")
                        };
                }
                else
                {
                    return null;
                }
                                
            }
        }
        
        public int delete(int id)
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
        
        public void update(int id, string? titulo = null, string? autor = null, string? genero = null, int? ano = null, int? pags = null)
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
                sql += " WHERE IDLivro = @IDLivro";
                parameters.Add(new MySqlParameter("@IDLivro", id));

                var cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddRange(parameters.ToArray());

                cmd.ExecuteNonQuery();
                

            }
        }
        
        public List<int> getAllIdsCatalogo()
        {
            var ids = new List<int>();

            using (var connection = db.GetConnection())
            {
                connection.Open();
                var cmd = new MySqlCommand("SELECT IDExemplar FROM Catalogo", connection);
                using (var reader = cmd.ExecuteReader())
                {   
                    while (reader.Read())
                    {
                        ids.Add(reader.GetInt32("IDExemplar"));
                    }
                }
            }

           return ids; 
    
        }
    
    }
}