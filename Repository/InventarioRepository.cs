using MySql.Data.MySqlClient;
using Biblioteca.Models;
using Biblioteca.Database;

namespace Biblioteca.Repository{

    public class InventarioRepository{

        private readonly Connection db = new Connection(); 


        public object adicionar(Inventario inventario){

            using(var connection = db.GetConnection()){
                connection.Open();
                var cmd = new MySqlCommand("INSERT INTO Inventario (ID_Catalogo) VALUES (@ID_Catalogo)", connection);
                cmd.Parameters.AddWithValue("@ID_Catalogo" , inventario.ID_Catalogo);
                var resultado = cmd.ExecuteNonQuery();
                return resultado;                
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
                    Console.WriteLine("Nenhum registro encontrado com esse id!");
                }
            }
        }

        public void editarId_Catalogo(int id , int ID_Catalogo)
        {
            using(var connection = db.GetConnection())
            {
                connection.Open();
                var cmd = new MySqlCommand("UPDATE Inventario SET ID_Catalogo = @ID_Catalogo WHERE ID = @ID", connection);
                
                cmd.Parameters.AddWithValue("@ID_Catalogo", ID_Catalogo);
                cmd.Parameters.AddWithValue("@ID", id);

                var linhasAfetadas = cmd.ExecuteNonQuery();

                if (linhasAfetadas > 0)
                {
                    Console.WriteLine("Id Alterado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Id_Catalgo Não encontrado!");
                }
            }
        }

        
        public int quantidadeExemplares(int ID_Catalogo)
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

        public List<Inventario> buscaIDsporIDCatalogo(int ID_Catalogo)
        {

            var inventList = new List<Inventario>();

            using(var connection = db.GetConnection())
            {
                connection.Open();
                var cmd = new MySqlCommand("SELECT * FROM Inventario WHERE ID_Catalogo = @ID_Catalogo",  connection);
                cmd.Parameters.AddWithValue("@ID_Catalogo", ID_Catalogo);
                var ler = cmd.ExecuteReader();

                while (ler.Read())
                {
                    var inventario = new Inventario
                    {
                        ID = ler.GetInt32("ID"),
                        ID_Catalogo = ler.GetInt32("ID_Catalogo"),
                        Disponivel = ler.GetBoolean("Disponivel")

                    };
                    inventList.Add(inventario);
                }
                foreach (var item in inventList)
                {
                    Console.WriteLine("ID :" + item.ID);
                    Console.WriteLine("Disponivel :" + item.Disponivel);
                    Console.WriteLine("ID_Catalogo :" + item.ID_Catalogo);
                    Console.WriteLine(new string('-', 20));
                }
                                
            }
            return inventList;
        }
    }
}