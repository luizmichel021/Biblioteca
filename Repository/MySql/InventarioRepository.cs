using MySql.Data.MySqlClient;
using Biblioteca.Models;
using Biblioteca.Database;
using Biblioteca.Repository;
using System.ComponentModel.Design.Serialization;

namespace Biblioteca.Repository
{

    public class InventarioRepository : IInventarioRepository{

        private readonly Connection db = new Connection(); 

        public bool setInventario(Inventario inventario)
        {
              using(var connection = db.GetConnection()){
                connection.Open();
                var cmd = new MySqlCommand("INSERT INTO Inventario (ID_Catalogo) VALUES (@ID_Catalogo)", connection);
                cmd.Parameters.AddWithValue("@ID_Catalogo" , inventario.ID_Catalogo);
                var resultado = cmd.ExecuteNonQuery();
                if(resultado != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }               
            }
        }

        public Inventario getInventario(int id)
        {
            using (var connection = db.GetConnection())
            {
                connection.Open();
                var cmd = new MySqlCommand("SELECT * FROM Inventario WHERE ID = @ID ", connection);
                cmd.Parameters.AddWithValue("@ID", id);
                var reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    return new Inventario
                    {
                        ID = reader.GetInt32("ID"),
                        ID_Catalogo = reader.GetInt32("ID_Catalogo"),
                        Disponivel = reader.GetBoolean("Disponivel")
                    };
                }
                else
                {
                    Inventario vent = new Inventario();
                    return vent;
                }  
            }
        }

        public int getQuantidadeLivroInInventario(int ID_Catalogo)
        {
            using(var connection = db.GetConnection())
            {
                connection.Open();
                var cmd = new MySqlCommand("SELECT COUNT(*) FROM Inventario WHERE ID_Catalogo = @ID_Catalogo", connection);
                cmd.Parameters.AddWithValue("ID_Catalogo", ID_Catalogo);
                var resultado = cmd.ExecuteScalar();
                return Convert.ToInt32(resultado);
            }
        }

        public bool delete(int id)
        {
            using(var connection = db.GetConnection())
            {
                connection.Open();
                var cmd = new MySqlCommand("DELETE FROM Inventario WHERE ID = @ID", connection);
                cmd.Parameters.AddWithValue("@ID" , id);
                

                var linhasafetadas = cmd.ExecuteNonQuery();

                if (linhasafetadas > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool update(int id, int Id_Catalogo)
        {
            using(var connection = db.GetConnection())
            {
                connection.Open();
                var cmd = new MySqlCommand("UPDATE Inventario SET ID_Catalogo = @ID_Catalogo WHERE ID = @ID", connection);
                
                cmd.Parameters.AddWithValue("@ID_Catalogo", Id_Catalogo);
                cmd.Parameters.AddWithValue("@ID", id);

                var linhasAfetadas = cmd.ExecuteNonQuery();

                if (linhasAfetadas > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool updateDisponibilidade(int id, bool disponivel)
        {
             using(var connection = db.GetConnection())
            {
                connection.Open();
                var cmd = new MySqlCommand("UPDATE Inventario SET Disponivel = @Disponivel WHERE @ID", connection);
                cmd.Parameters.AddWithValue("@Disponivel", disponivel);
                cmd.Parameters.AddWithValue("@ID", id);

                var result = cmd.ExecuteNonQuery();

                if (result > 0)
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