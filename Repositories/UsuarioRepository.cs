using System.Data;
using Biblioteca.Database;
using Biblioteca.Models;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;

namespace Biblioteca.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Connection bd = new Connection(); 
        public int create(Usuario usuario)
        {
            using(var connection = bd.GetConnection())
            {
             connection.Open();
             var cmd =  new MySqlCommand("INSERT INTO Usuarios(Nome, Endereco, Telefone, Email, DataNascimento) VALUES (@Nome, @Endereco, @Telefone, @Email, @DataNascimento);",connection);
             cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
             cmd.Parameters.AddWithValue("@Endereco", usuario.Endereco);
             cmd.Parameters.AddWithValue("@Telefone", usuario.Telefone);
             cmd.Parameters.AddWithValue("@Email", usuario.Email);
             cmd.Parameters.AddWithValue("@DataNascimento", usuario.DataNascimento);

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

        public bool delete(int id)
        {
             using (var connection = bd.GetConnection())
             {
                connection.Open();
                var cmd = new MySqlCommand("DELETE FROM Usuarios WHERE ID = @ID",connection);
                cmd.Parameters.AddWithValue("@ID", id);
                var result = cmd.ExecuteNonQuery();
                if(result != 0){
                    return true;
                }
                else
                {
                    return false;
                }

             }
        }

        public Usuario GetUsuario(int id)
        {
            using(var connection = bd.GetConnection())
            {   
                connection.Open();
                var cmd = new MySqlCommand("SELECT * FROM Usuarios WHERE ID = @ID", connection);
                cmd.Parameters.AddWithValue("@ID", id);
                var reader = cmd.ExecuteReader();
                 if(reader.Read())
                {
                    return new Usuario() 
                        {
                            ID = reader.GetInt32("ID"),
                            Nome = reader.GetString("Nome"),
                            Endereco = reader.GetString("Endereco"),
                            Email = reader.GetString("Email"),
                            Telefone = reader.GetInt64("Telefone"),
                            DataNascimento = reader.GetDateTime("DataNascimento")
                        };
                }
                else
                {
                    return null;
                }
                         


            }
        }

        public bool update(int id ,string? nome = null, string? endereco = null, string? email = null, long? telefone = null, DateTime? datanascimento = null)
        {
            using (var connection = bd.GetConnection())
            {   
                connection.Open();
                var sql = "UPDATE Usuarios SET ";
                var parametros = new List<MySqlParameter>();
                if (nome != null)
                {
                    sql += "Nome = @Nome, ";
                    parametros.Add(new MySqlParameter("@Nome", nome));
                }
                if (endereco != null)
                {
                    sql += "Endereco = @Endereco, ";
                    parametros.Add(new MySqlParameter("@Endereco", endereco));
                }
                if (email != null)
                {
                    sql += "Email = @Email, ";
                    parametros.Add(new MySqlParameter("@Email", email));
                }
                if (telefone != null)
                {
                    sql += "Telefone = @Telefone, ";
                    parametros.Add(new MySqlParameter("@Telefone", telefone.Value));
                }
                if (datanascimento != null)
                {
                    sql += "DataNascimento = @DataNascimento, ";
                    parametros.Add(new MySqlParameter("@DataNascimento", datanascimento));
                }
                sql = sql.TrimEnd(',', ' ');
                sql += " WHERE @ID = ID";

                parametros.Add(new MySqlParameter("@ID", id));

                var cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddRange(parametros.ToArray());

                var result = cmd.ExecuteNonQuery();
                
                if(result != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

            
    }

}