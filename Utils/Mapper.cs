
using Biblioteca.Models;
using MySql.Data.MySqlClient;

namespace Biblioteca.Utils{

    public class Mapper{

        public Catalogo mapear(MySqlDataReader reader){
            return new Catalogo
            {
                ID = reader.GetInt32("ID"),
                Titulo = reader.GetString("Titulo"),
                Autor = reader.GetString("Autor"),
                Ano = reader.GetInt32("Ano"),
                Genero = reader.GetString("Genero"),
                Pags = reader.GetInt32("Pags")
            };
        }

    }


}