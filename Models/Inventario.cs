namespace Biblioteca.Models
{
    public class Inventario
    {
        // ATRIBUTOS
        private int id;
        private int idlivro_catalogo;
        private bool disponivel;

        // PROPRIEDADES
        public int ID
        {
            get {return id;}
            set {id = value;}
        }

        public int IDLivro_Catalogo
        {
            get {return idlivro_catalogo;}
            set {idlivro_catalogo = value;}
        }

        public bool Disponivel
        {
            get {return disponivel;}
            set {disponivel = value;}
        }

        public Inventario(){}
        public Inventario(int id_catalogo)
        {           
            IDLivro_Catalogo = id_catalogo;           
        }

        public override string ToString()
        {
            return "ID:" + id + "  Catalogo:" + idlivro_catalogo + "   Disponivel:" + disponivel;
        }
    }
}    