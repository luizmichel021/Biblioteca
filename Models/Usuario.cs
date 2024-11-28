namespace Biblioteca.Models
{
    public class Usuario
    {
        private int id;
        private string nome;
        private string endereco;
        private string email;
        private long telefone;
        private DateTime dataNascimento;

        public int ID
        {   
            set {id = value;}
            get {return id;}
        }
        public string Nome
        {
            get{return nome;}
            set{nome = value;} 
        }
        public string Endereco
        {
            set{endereco = value;}
            get {return endereco;}
        }
        public string Email
        {
            get{return email;}
            set{email = value;}
        }
        public long Telefone
        {
            set{telefone = value;}
            get{return telefone;}
        }
        public DateTime DataNascimento
        {
            get{return dataNascimento;}
            set{dataNascimento = value;}
        }

        public Usuario(){}
        public Usuario(string nome, string endereco, string email, long telefone, DateTime dataNascimento)
        {  
            Nome = nome;
            Endereco = endereco;
            Email = email;
            Telefone = telefone;
            DataNascimento = dataNascimento;
        }

        public override string ToString()
        {
            return $"ID: {ID} Nome: {Nome}, Endereço: {Endereco}, Email: {Email}, Telefone : {Telefone}, Data Nascimento: {DataNascimento}";
        }
    }
}