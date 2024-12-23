using Biblioteca.Repository;
using Biblioteca.Models;
using Microsoft.VisualBasic;
using Org.BouncyCastle.Asn1.Misc;
using Org.BouncyCastle.Asn1.Ocsp;
using System.ComponentModel.Design.Serialization;

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

        public int CriarUsuario(string nome, string endereco, string email, long telefone, DateTime dataNascimento)
        {   
            var usuario = new Usuario(nome,endereco,email,telefone,dataNascimento);            
            var idUsuario = usuarioRepository.create(usuario);
            return  idUsuario;
        }

        public string emprestimo(int idLivro, int idUsuario,DateTime dataEmprestimo,DateTime dataDevolucao)
        {   
            var disponibilidade = inventarioRepository.checaDisponibilidade(idLivro);

            if (disponibilidade =! true){
                var emprestimo = emprestimoRespository.createEmprestimo(idLivro, idUsuario, dataEmprestimo, dataDevolucao);
                if (emprestimo == true)
                {
                    inventarioRepository.updateDisponibilidade(idLivro, false);
                    return "Você acabou de fazer o emprestimo do Livro de ID " + idLivro + " a devolução deverá ser feita no dia " + dataDevolucao ;
                }
                else
                {
                    return "erro ao efetuar emprestimo, revise os dados fornecidos!";
                }
            }               
            else
            {
                return "Livro não disponivel";
            }

        }

        public string devolucao(int id, int id_inventario)
        {
            bool disponivel = inventarioRepository.checaDisponibilidade(id_inventario);
            if (disponivel == false )
            {  
                bool devolucao = emprestimoRespository.devolucao(id, id_inventario);
                if (devolucao == true)
                {
                    inventarioRepository.updateDisponibilidade(id_inventario, true);
                    return"Você devolveu o livro de ID Inventario "+id_inventario+ " ! ";
                }
                else
                {
                    return"Não foi possivel devolver o livro, cheque os dados fornecidos!";
                }
            }
            else
            {
                return"O id do inventario que foi fornecido não consta como emprestado, cheque novamente o numero de inventario do seu livro!";
            }
            

        }

        public string adicionarExemplarAoCatalogo(string titulo, string autor,int ano,string genero,int pags)
        {
            var catalogo = new Catalogo(titulo,autor,ano,genero,pags);
            var i = catalogoRepository.create(catalogo);
            if (i == 0)
            {
                return "erro ao criar um tipo de livro no catalogo";
            }
            else
            {
                return "tipo de livro criado no catalogo com sucesso";
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

        
  
    }
    
    
}