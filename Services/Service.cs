using Biblioteca.Repository;
using Biblioteca.Models;
using Microsoft.VisualBasic;
using Org.BouncyCastle.Asn1.Misc;
using Org.BouncyCastle.Asn1.Ocsp;
using System.ComponentModel.Design.Serialization;
using System.ComponentModel;

namespace Biblioteca.Services{

    public class Service
    {
        private CatalogoRepository catalogoRepository;

        private InventarioRepository inventarioRepository;

        private UsuarioRepository usuarioRepository;

        private EmprestimoRespository emprestimoRespository;


        
        public Service()
        {
        catalogoRepository = new CatalogoRepository();  
        inventarioRepository = new InventarioRepository();
        usuarioRepository = new UsuarioRepository();
        emprestimoRespository = new EmprestimoRespository();
        }

        public void CriarUsuario()
        {   
            Console.WriteLine("Digite o Nome do Usuario: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o Endereço do Usuario: ");
            string endereco = Console.ReadLine();

            Console.WriteLine("Digite o Email do Usuario: ");
            string email = Console.ReadLine();

            Console.WriteLine("Digite o Telefone do Usuario: ");
            long telefone;
            if (!long.TryParse(Console.ReadLine(), out telefone))
            {
                Console.WriteLine("Telefone inválido. Digite novamente:");
            }

            Console.WriteLine("Digite a Data de Nascimento do Usuario (formato: dd/MM/yyyy): ");
            DateTime dataNascimento;
            if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataNascimento))
            {
                Console.WriteLine("Data de nascimento inválida. Digite novamente no formato dd/MM/yyyy:");
            }

            
            var usuario = new Usuario(nome, endereco, email, telefone, dataNascimento);
            var idUsuario = usuarioRepository.create(usuario);

            
            Console.WriteLine("Usuário criado com sucesso! ID: " + idUsuario);
        }

        public void emprestimo()
        {   
            Console.WriteLine("Digite o ID Inventario do Livro que Deseja Pegar Emprestado");
            int idInventario = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o ID do Usuario que Vai Pegar o livro Emprestado");
            int idUsuario = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a Data de Emprestimo(formato: dd/MM/yyyy): ");
            DateTime dataEmprestimo;
            if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataEmprestimo))
            {
                Console.WriteLine("Data de Emprestimo inválida. Digite novamente no formato dd/MM/yyyy:");
            }
            Console.WriteLine("Digite a Data de Devolução(formato: dd/MM/yyyy): ");
            DateTime dataDevolucao;
            if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataDevolucao))
            {
                Console.WriteLine("Data de Devolução inválida. Digite novamente no formato dd/MM/yyyy:");
            }
            var disponibilidade = inventarioRepository.checaDisponibilidade(idInventario);

            if (disponibilidade == true){
                var id = emprestimoRespository.createEmprestimo(idInventario, idUsuario, dataEmprestimo, dataDevolucao);
                if (id != 0 )
                {
                    inventarioRepository.updateDisponibilidade(idInventario, false);
                    Console.WriteLine("Você acabou de fazer o emprestimo do Livro de ID " + idInventario + " a devolução deverá ser feita no dia " + dataDevolucao);
                    Console.WriteLine("Seu Emprestimo e o Emprestimo de numero "+ id + " adicione esse numero a ficha para o momento da devolução!");
                }
                else
                {
                    Console.WriteLine("erro ao efetuar emprestimo, revise os dados fornecidos!");
                }
            }               
            else
            {
                Console.WriteLine("Livro não disponivel");
            }

        }

        public void devolucao()
        {
            Console.WriteLine("Digite o Numero do Emprestimo");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o id Inventario do Livro que foi Emprestado!");
            int id_inventario = int.Parse(Console.ReadLine());



            bool disponivel = inventarioRepository.checaDisponibilidade(id_inventario);
            if (disponivel != true)
            {  
                bool devolucao = emprestimoRespository.devolucao(id, id_inventario);
                if (devolucao == true)
                {
                    inventarioRepository.updateDisponibilidade(id_inventario, true);
                    Console.WriteLine("Você devolveu o livro de ID Inventario "+ id_inventario + " ! ");
                }
                else
                {
                    Console.WriteLine("Não foi possivel devolver o livro, cheque os dados fornecidos!");
                }
            }
            else
            {
                Console.WriteLine("error");
            }
            

        }

        public void adicionarExemplarAoCatalogo()
        {   
            Console.WriteLine("Digite o titulo do livro : ");
            string titulo = Console.ReadLine();
            Console.WriteLine("Digite o Autor do livro : ");
            string autor = Console.ReadLine();
            Console.WriteLine("Digite o Ano de lançamento do livro : ");
            int ano = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Genero do livro : ");
            string genero = Console.ReadLine();
            Console.WriteLine("Digite quantas paginas o livro tem : "); 
            int pags = int.Parse(Console.ReadLine());

            var catalogo = new Catalogo(titulo,autor,ano,genero,pags);
            var i = catalogoRepository.create(catalogo);
            if (i == 0)
            {
                Console.WriteLine("erro ao criar um tipo de livro no catalogo");
            }
            else
            {
                Console.WriteLine("O NUMERO EXEMPLAR CRIADO NO CATALOGO É ID(" + i +")");
                Console.WriteLine(catalogoRepository.getCatalogo(i));
            }

        }

        public void exibirCatalogo()
        {
            List<int> id_list = new List<int>();
            id_list = catalogoRepository.getAllIdsCatalogo();

            foreach (int id in id_list)
            {
                Console.WriteLine(catalogoRepository.getCatalogo(id));
            }

        }

        public void mostrarLivrosDisponiveisPorIDExemplar()
        {
            Console.WriteLine("Escolha o ID do Exemplar que deseja ver disponibilidade de Livros em nosso inventario: ");
            var entrada = Console.ReadLine();
            
            if(int.TryParse(entrada, out int id)){
                Console.WriteLine(catalogoRepository.getCatalogo(id));
                Console.WriteLine("Há " + inventarioRepository.getQuantidadeLivroInInventario(id) + " Livros em nosso Inventario");
                List<int> idsDisponiveis = inventarioRepository.getIdsInventarioPorID_Catalogo(id);
                foreach (int ids in idsDisponiveis)
                {
                    bool disponivel = inventarioRepository.checaDisponibilidade(ids);
                    if (disponivel == true)
                    {
                        Console.WriteLine("DISPONIVEL ID_INVENTARIO("+ids+")");
                    }
                    else
                    {
                        Console.WriteLine("INDISPONIVEL ID_INVENTARIO("+ids+")");
                    }
                }

            }
            else
            {
                Console.WriteLine("Não corresponde a um numero.");
            } 

            
        }

        public void adicionarLivroAoInventario()
        {
            Console.WriteLine("Digite o ID do Exemplar que Você deseja adicionar um livro ao Inventario:");
            int idCatalogo = int.Parse(Console.ReadLine());
            var checagem = catalogoRepository.getCatalogo(idCatalogo);
            Console.WriteLine("O Livro que você quer adicionar é Correspondente à : " + checagem);
            Console.WriteLine(" 1 = SIM");
            Console.WriteLine(" 2 = Não");
            int resposta = int.Parse(Console.ReadLine());
            if (resposta == 1)
            {
                var inventario = new Inventario (idCatalogo);
                bool result = inventarioRepository.create(inventario); 
                if (result == true)
                {
                    Console.WriteLine("Livro Adicionado ao Inventario com Sucesso");
                }
                else
                {
                    Console.WriteLine("Erro ao Adicionar livro ao inventario tente novamente mais tarde!");
                }
            }
            else
            {
                Console.WriteLine("OK, Então cheque novamente qual o id de Exemplar Correto Exibindo nosso Catalogo!");
            }
           
        }
    }
    
    
}