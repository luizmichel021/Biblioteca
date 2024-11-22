using Biblioteca.Repository;
using Biblioteca.Models;
using Biblioteca.Services;


namespace Biblioteca
{
    class Programa
    {
    
        static void Main(string[] args)
        {
            
            var service = new Service();

            // var livro = new Livro ("Shek 2", "Disney", 207 , "Comedia" , 120);

            // Console.WriteLine(service.adicionarLivro(livro));
            Console.WriteLine(service.excluirLivro(6));
            // Console.WriteLine(service.buscaLivroPorID(2));

            

            service.ExibirCatalogo();

            

        

        }
    }
}