
using Biblioteca.Database;
using MySql.Data.MySqlClient;

namespace Biblioteca.Repository{

    public class EmprestimoRespository : IEmprestimoRepository
    {
        private readonly Connection db = new Connection();

        public bool devolucao(int id, int id_inventario)
        {
            using (var connection = db.GetConnection())
            {
                connection.Open();
                var cmd = new MySqlCommand("UPDATE Emprestimos SET ID_Inventario = @ID_Inventario , Ativo = @Ativo  WHERE ID = @ID",connection);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@ID_Inventario", id_inventario);
                cmd.Parameters.AddWithValue("@Ativo", false);
                var result = cmd.ExecuteNonQuery();

                if (result != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public bool createEmprestimo(int id_inventario, int id_usuario, DateTime data_emprestimo, DateTime data_devolucao)
        {
            using (var connection = db.GetConnection())
            {
                connection.Open();
                var cmd = new MySqlCommand("INSERT INTO Emprestimos (ID_Inventario , ID_Usuario, Data_Emprestimo, Data_Devolucao) VALUES (@ID_Inventario , @ID_Usuario, @Data_Emprestimo, @Data_Devolucao)", connection);
                cmd.Parameters.AddWithValue("@ID_Inventario", id_inventario);
                cmd.Parameters.AddWithValue("@ID_Usuario", id_usuario);
                cmd.Parameters.AddWithValue("@Data_Emprestimo", data_emprestimo);
                cmd.Parameters.AddWithValue("@Data_Devolucao", data_devolucao);
                var result = cmd.ExecuteNonQuery();

                if (result != 0)
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