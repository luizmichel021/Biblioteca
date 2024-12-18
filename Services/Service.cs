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


        
  
    }
    
    
}