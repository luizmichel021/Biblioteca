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
            var catalogo = new CatalogoRepository();
            var inventario = new InventarioRepository();
            var emprestimo = new EmprestimoRespository();

            // Console.WriteLine(service.CriarUsuario("Michel", "Vila Glauco 126", "michelwork18@hotmail.com", 975598507 , new DateTime(2000, 8 ,23)));
            

            // Catalogo livro = new Catalogo("Peter Pan", "Disney", 2007,"Comedia" , 120);

            // Inventario invent = new Inventario(1);


            // Console.WriteLine(service.adicionarCatalogo("Shrek 3", "Disney", 2007,"Comedia" , 120));
            // Console.WriteLine(service.excluirLivro(9));
            // Console.WriteLine(service.buscaLivroPorID(2));
            // service.atualizarLivro(8, "SHREK 2", "DISNEY", "COMEDIA", 2007, 500 );
            // Console.WriteLine(catalogo.create(livro));
            // Console.WriteLine(usuario.create(usu));
            // Console.WriteLine(inventario.create(invent));
            Console.WriteLine(service.emprestimo(2,2,new DateTime(2024, 11, 29), new DateTime (2024, 12 , 25)));
            // Console.WriteLine(emprestimo.devolucao(1 , 1));
            // Console.WriteLine(usu);

            

        

        }
    }
}