using Biblioteca.Repository;
using Biblioteca.Models;
using Microsoft.VisualBasic;
using Org.BouncyCastle.Asn1.Misc;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Biblioteca.Services{

    public class Service
    {
        private LivroRepository livroRepository;

        private InventarioRepository inventarioRepository;
        
        public Service()
        {
        livroRepository = new LivroRepository();
        inventarioRepository = new InventarioRepository();
        }

        public string adicionarLivro(string titulo, string autor, int ano, string genero, int pags)
        {
            var livro = new Livro(titulo,autor,ano,genero,pags);
            var rows = livroRepository.adicionar(livro);
            if (rows != 0)
            {
                return "Livro adicionado com sucesso!";
            }
            else
            {
                return "error, livro não pode ser adicionado!";
            }
            
        }
        public string excluirLivro(int id)
        {
            
            var linhasafetadas = livroRepository.excluir(id);

            if (linhasafetadas != 0)
            {
                return $"O livro do ID : {id} foi excluido com sucesso!";
            }
            else 
            {
                return $"O livro do ID : {id} não existe!";
            }
        }
        public Livro buscaLivroPorID(int id){

            var livro = new Livro();
            livro = livroRepository.buscaLivro(id);
            return livro;
        }
        public void atualizarLivro(int id, string? titulo = null, string? autor = null, string? genero = null, int? ano = null, int? pags = null)
        {
            // depois mexer nesse metodo pra retornar o antes e depois dos campos e quais campos foram atualizados!
            livroRepository.atualizar(id, titulo, autor, genero, ano, pags);
                
        }
        
        
        public List<Livro> ExibirCatalogo() 
        {
            var catalogo = new List<Livro>();
            
            var ids = livroRepository.buscaIds();
            foreach(var id in ids)
            {
                var response = buscaLivroPorID(id);
                
                if (response != null)
                {
                    catalogo.Add(response);
                }
                else
                {
                   break;
                }
            
            }

            foreach (var item in catalogo)
            {
                    Console.WriteLine("ID: " + item.ID);
                    Console.WriteLine("Titulo: " + item.Titulo);
                    Console.WriteLine("Autor: " + item.Autor);
                    Console.WriteLine("Ano: " + item.Ano);
                    Console.WriteLine("Genero: " + item.Genero);
                    Console.WriteLine("Pags: " + item.Pags);
                    Console.WriteLine(new string('-', 20)); // Separador entre os itens
            }
            return catalogo;
        }
    }
    
    
}