using Biblioteca.Repository;
using Biblioteca.Models;
using Biblioteca.Services;


namespace Biblioteca
{
    class Programa
    {
    
        static void Main(string[] args)
        {
            
        var catalogoRepository = new CatalogoRepository();

        // var inventarioRepository = new InventarioRepository();

        // var invent = new Inventario(1);
        // var invent2 = new Inventario(2);

        

        // var catalogo = new Catalogo("Gato", "DAN BROWN", 2000, "Drama" ,500);
        
        // var catalogo = catalogoRepository.excluirPorID(5);
        // Console.WriteLine(catalogo);
    
        // catalogoRepository.adicionar(catalogo);
      
        // inventarioRepository.adicionar(invent);
        // inventarioRepository.adicionar(invent2);

        // catalogoRepository.listar();

        // inventarioRepository.excluirPorID(1);

        // catalogoRepository.listar();

        // inventarioRepository.editarId_Catalogo(2,2);

        // Console.WriteLine(inventarioRepository.idDosExemplares(2));

        var service = new Service();

        service.atualizarCatalogo(1,"duro de matar", "jhonny", "drama", 1999);
        }
    }
}