using MySql.Data.MySqlClient;

namespace Biblioteca.Repository
{
    public class Database
    {
        private string connectionString = "Server=localhost;Database=Biblioteca;Uid=root;Pwd=123456;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
