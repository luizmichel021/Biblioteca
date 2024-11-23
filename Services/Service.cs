using Biblioteca.Repository;
using Biblioteca.Models;
using Microsoft.VisualBasic;
using Org.BouncyCastle.Asn1.Misc;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Biblioteca.Services{

    public class Service
    {
        private CatalogoRepository catalogoRepository;

        private InventarioRepository inventarioRepository;
        
        public Service()
        {
        catalogoRepository = new CatalogoRepository();
        inventarioRepository = new InventarioRepository();
        }

        public string adicionarCatalogo(string titulo, string autor, int ano, string genero, int pags)
        {
            var catalogo = new Catalogo(titulo,autor,ano,genero,pags);
            var rows = catalogoRepository.adicionar(catalogo);
            if (rows != 0)
            {
                return "Livro adicionado com sucesso!";
            }
            else
            {
                return "error, livro não pode ser adicionado!";
            }
            
        }
        public string excluirCatalogo(int id)
        {
            
            var linhasafetadas = catalogoRepository.excluir(id);

            if (linhasafetadas != 0)
            {
                return $"O livro do ID : {id} foi excluido com sucesso!";
            }
            else 
            {
                return $"O livro do ID : {id} não existe!";
            }
        }
        public Catalogo buscaCatalogoPorID(int id){

            var catalogo = new Catalogo();
            catalogo = catalogoRepository.buscaCatalogo(id);
            return catalogo;
        }
        public void atualizarCatalogo(int id, string? titulo = null, string? autor = null, string? genero = null, int? ano = null, int? pags = null)
        {
            // depois mexer nesse metodo pra retornar o antes e depois dos campos e quais campos foram atualizados!
            catalogoRepository.atualizar(id, titulo, autor, genero, ano, pags);
                
        }
        public List<Catalogo> ExibirCatalogo() 
        {
            var catalogo = new List<Catalogo>();
            
            var ids = catalogoRepository.buscaIds();
            foreach(var id in ids)
            {
                var response = buscaCatalogoPorID(id);
                
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