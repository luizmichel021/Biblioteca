namespace Biblioteca.Models
{
    public class Inventario
    {
        // ATRIBUTOS
        private int id;
        private int id_catalogo;
        private bool disponivel;

        // PROPRIEDADES
        public int ID
        {
            get {return id;}
            set {id = value;}
        }

        public int ID_Catalogo
        {
            get {return id_catalogo;}
            set {id_catalogo = value;}
        }

        public bool Disponivel
        {
            get {return disponivel;}
            set {disponivel = value;}
        }

        public Inventario(){}
        public Inventario(int id_catalogo)
        {
            ID_Catalogo = id_catalogo;
        }
    }
}