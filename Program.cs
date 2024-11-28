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
 
            var usuario = new UsuarioRepository();

            var  usu = new Usuario("Michel", "Vila Glauco 126", "michelwork18@hotmail.com", 975598507 , new DateTime(2000, 8 ,23));

            // Catalogo livro = new Catalogo("Shrek 3", "Disney", 2007,"Comedia" , 120);

            // Console.WriteLine(service.adicionarCatalogo("Shrek 3", "Disney", 2007,"Comedia" , 120));
            // Console.WriteLine(service.excluirLivro(9));
            // Console.WriteLine(service.buscaLivroPorID(2));
            // service.atualizarLivro(8, "SHREK 2", "DISNEY", "COMEDIA", 2007, 500 );

            Console.WriteLine(usuario.create(usu));

            // Console.WriteLine(usu);

            

        

        }
    }
}