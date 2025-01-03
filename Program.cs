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

            int escolha = -1; 
            while (escolha != 0)
            {
                Console.WriteLine("========= Biblioteca ============");
                Console.WriteLine(" 1 = ADICIONAR EXEMPLAR AO CATALOGO.");
                Console.WriteLine(" 2 = ADICIONAR LIVRO AO INVENTARIO.");
                Console.WriteLine(" 3 = EXIBIR CATALOGO.");
                Console.WriteLine(" 4 = EXIBIR LIVROS DISPONIVEIS NO INVENTARIO.");
                Console.WriteLine(" 5 = CADASTRAR USUARIO.");
                Console.WriteLine(" 6 = PEGAR LIVRO EMPRESTADO.");
                Console.WriteLine(" 7 = DEVOLVER LIVRO.");
                Console.WriteLine(" 0 = SAIR.");
    
                Console.Write("Escolha uma opção: ");
    
           
                if (!int.TryParse(Console.ReadLine(), out escolha))
                {
                    Console.WriteLine("Entrada inválida! Digite um número.");
                    continue;
                }

                switch (escolha)
                {
                    case 1:
                        service.adicionarExemplarAoCatalogo();
                        break;
                    case 2:
                        service.adicionarLivroAoInventario();
                        break;
                    case 3:
                        service.exibirCatalogo();
                        break;
                    case 4:
                        service.mostrarLivrosDisponiveisPorIDExemplar();
                        break;
                    case 5:
                        service.CriarUsuario();
                        break;
                    case 6:
                        service.emprestimo();
                        break;
                    case 7:
                        service.devolucao();
                        break;
                    case 0:
                        Console.WriteLine("Saindo da biblioteca...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Escolha entre 0 e 7.");
                        break;
                }
            }
        

        }
    }
}