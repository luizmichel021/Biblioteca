using System.Dynamic;

namespace Biblioteca.Models
{
    public class Catalogo
    {
        // ATRIBUTOS
        private int idLivro;
        private string titulo;
        private string autor;
        private int ano;
        private string genero;
        private int pags;

        // PROPRIEDADES
        public int IDLivro
        {
            get {return idLivro;}
            set {idLivro = value;}
        }   
        
        public string Titulo
        {
            get {return titulo;}
            set {titulo = value;}
        }   
        
        public string Autor
        {
            get {return autor;}
            set {autor = value;}
        } 
        
        public int Ano
        {
            get {return ano;}
            set {ano = value;}
        }

        public string Genero
        {
            get {return genero;}
            set {genero = value;}
        }   
        
        public int Pags
        {
            get {return pags;}
            set {pags = value;}
        } 

        public Catalogo() { }
        public Catalogo(string titulo, string autor,  int ano, string genero, int pags )
        {
            Titulo = titulo;
            Autor = autor;
            Ano = ano;
            Genero = genero;
            Pags = pags;
        }

          public override string ToString()
        {
            return $"IDLivro: {IDLivro} Título: {Titulo}, Autor: {Autor}, Ano: {Ano}, Gênero: {Genero}, Páginas: {Pags}";
        
        }
    }

}        