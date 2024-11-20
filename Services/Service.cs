using Biblioteca.Repository;
using Biblioteca.Models;
using Microsoft.VisualBasic;

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
   
        public void exibeLivroandQuantidade(int id){
            var livro = catalogoRepository.obterPorID(id);
            var quantidade = inventarioRepository.quantidadeExemplares(id);
            Console.WriteLine(livro);
            Console.WriteLine(quantidade);

        }

    }
    
    
}