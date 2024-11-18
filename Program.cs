using Biblioteca.Repository;
using Biblioteca.Models;


namespace Biblioteca
{
    class Programa
    {
    
        static void Main(string[] args)
        {
            
        var catalogoRepository = new CatalogoRepository();

        var inventarioRepository = new InventarioRepository();

        // var invent = new Inventario(1);

        // var catalogo = new Catalogo("CODIGO DA VINCI", "DAN BROWN", 2000, "Drama" ,500);
        
        // catalogoRepository.listar();

        // catalogoRepository.adicionar(catalogo);
      
        // inventarioRepository.adicionar(invent);

        // catalogoRepository.listar();

        inventarioRepository.alterarDisponibilidade(1, true);
        
        }
    }
}