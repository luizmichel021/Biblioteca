using MySql.Data.MySqlClient;
using Biblioteca.Models;
using Biblioteca.Repository;
using Org.BouncyCastle.Asn1.Misc;
using Mysqlx.Expr;

namespace Biblioteca.Repository{

    public class InventarioRepository{

        private readonly Database db; 

        public InventarioRepository(){
            db = new Database();
        }

        public void adicionar(Inventario inventario){

            using(var connection = db.GetConnection()){
                connection.Open();
                var cmd = new MySqlCommand("INSERT INTO Inventario (ID_Catalogo) VALUES (@ID_Catalogo)", connection);
                cmd.Parameters.AddWithValue("@ID_Catalogo" , inventario.ID_Catalogo);
                cmd.ExecuteNonQuery();
                
            }
        }

        public void alterarDisponibilidade(int id, bool disponivel)
        {
            
            using(var connection = db.GetConnection())
            {
                connection.Open();
                var cmd = new MySqlCommand("UPDATE Inventario SET Disponivel = @Disponivel WHERE @ID", connection);
                cmd.Parameters.AddWithValue("@Disponivel", disponivel);
                cmd.Parameters.AddWithValue("@ID", id);

                cmd.ExecuteNonQuery();
            }
        }

        public void excluirPorID(int id)
        {
            using(var connection = db.GetConnection())
            {
                connection.Open();
                var cmd = new MySqlCommand("DELETE FROM Inventario WHERE ID = @ID", connection);
                cmd.Parameters.AddWithValue("@ID" , id);
                

                var linhasafetadas = cmd.ExecuteNonQuery();

                if (linhasafetadas > 0)
                {
                    Console.WriteLine("Item de inventario excluido com sucesso!");
                }
                else
                {
                    Console.WriteLine("Nenhum registro encontrado com esse id!")
                }
            }
        }

    }
}