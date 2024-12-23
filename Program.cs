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

            service.adicionarExemplarAoCatalogo("Codigo Da Vince", "DAN BROWN", 2007 , "Terror", 357);
 
            service.exibirCatalogo();

            

        

        }
    }
}