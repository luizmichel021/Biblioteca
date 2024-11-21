using MySql.Data.MySqlClient;

namespace Biblioteca.Database
{
    public class Connection
    {
        private string connectionString = "Server=localhost;Database=Biblioteca;Uid=root;Pwd=123456;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
