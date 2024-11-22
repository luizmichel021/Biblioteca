using Biblioteca.Repository;
using Biblioteca.Models;
using Biblioteca.Services;
using ZstdSharp.Unsafe;


namespace Biblioteca
{
    class Programa
    {
    
        static void Main(string[] args)
        {
            
            var service = new Service();

            // Console.WriteLine(service.adicionarLivro("Shrek 3", "Disney", 2007,"Comedia" , 120));

            // Console.WriteLine(service.adicionarLivro(livro));
            // Console.WriteLine(service.excluirLivro(9));
            // Console.WriteLine(service.buscaLivroPorID(2));
            // service.atualizarLivro(8, "SHREK 2", "DISNEY", "COMEDIA", 2007, 500 );

            

            service.ExibirCatalogo();

            

        

        }
    }
}