namespace Biblioteca.Models
{
    public class Emprestimo{
        private int id;
        private int id_inventario;
        private int id_usuario; 
        private DateTime data_emprestimo; 
        private DateTime data_devolucao;

        private bool ativo;

        public int ID
        { 
            get{return id;}
        }

        public int ID_Inventario 
        {
            get{return id_inventario;} 
            set{id_inventario = value;}
        }

        public int ID_Usuario
        {
            get{return id_usuario;}
            set{id_usuario = value;}
        }

        public DateTime Data_Emprestimo
        {
            get{return data_emprestimo;}
            set{data_emprestimo = value;}
        }

        public DateTime Data_Devolucao
        {
            get{return data_devolucao;}
            set{data_devolucao = value;}
        }

        public bool Ativo
        {
            get{return ativo;}
            set{ativo = value;}
        }

        public Emprestimo(){}
        public Emprestimo(int id_inventario, int id_usuario, DateTime data_emprestimo, DateTime data_devolucao)
        {
            ID_Inventario = id_inventario;
            ID_Usuario = id_usuario;
            Data_Emprestimo = data_emprestimo;
            Data_Devolucao = data_devolucao;
        }
        

    }
} 
