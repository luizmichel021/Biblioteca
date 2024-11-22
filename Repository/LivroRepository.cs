using MySql.Data.MySqlClient;
using Biblioteca.Models;
using Biblioteca.Database;
using Microsoft.VisualBasic;

namespace Biblioteca.Repository
{
    public class LivroRepository
    {
        private readonly Connection db = new Connection();   
        

            // A Função adicionar retornara um inteiro, o conteudo desse inteiro é a quantidade de linhas afetadas.
        public int adicionar(string sql) 
        {

            using (var connection = db.GetConnection())
            {
                connection.Open();
                var cmd = new MySqlCommand(sql, connection);
               
                var resultado = cmd.ExecuteNonQuery();
                return resultado;
            }
        }


        public Livro buscaLivro(string sql)
        {
            using (var connection = db.GetConnection())
            {
                connection.Open();
                var cmd = new MySqlCommand(sql, connection);
                var ler = cmd.ExecuteReader();

                if (ler.Read())
                {
                    return new Livro
                    {
                        ID = ler.GetInt32("ID"),
                        Titulo = ler.GetString("Titulo"),
                        Autor = ler.GetString("Autor"),
                        Ano = ler.GetInt32("Ano"),
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

        public int excluir(string sql)
        {
            using (var connection = db.GetConnection())
            {
                connection.Open();
                var cmd = new MySqlCommand(sql, connection);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;

            }
        }


        public void atualizar(string sql)
        {
            using (var connection = db.GetConnection())
            {
                connection.Open();            
                

                var cmd = new MySqlCommand($"{sql}", connection);
                

                cmd.ExecuteNonQuery();
            }
        }
        
        public List<int> BuscaIds()
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