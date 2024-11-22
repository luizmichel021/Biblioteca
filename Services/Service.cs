using Biblioteca.Repository;
using Biblioteca.Models;
using Microsoft.VisualBasic;
using Org.BouncyCastle.Asn1.Misc;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Biblioteca.Services{

    public class Service
    {
        private LivroRepository livroRepository;

        private InventarioRepository inventarioRepository;
        
        public Service()
        {
        livroRepository = new LivroRepository();
        inventarioRepository = new InventarioRepository();
        }

        public string adicionarLivro(Livro livro)
        {
            string sql = $"INSERT INTO Livro (Titulo, Autor, Ano, Genero, Pags) VALUES ('{livro.Titulo}', '{livro.Autor}', {livro.Ano}, '{livro.Genero}', {livro.Pags})";
            var linhasafetadas = livroRepository.adicionar(sql);

            if (linhasafetadas != 0){
                return "Livro Adicionado com sucesso!";
            }
            else{
                return "Livro não pode ser adicionado, cheque o objeto livro e tente novamente";
            } 
        }
        public string excluirLivro(int id)
        {
            string sql = $"DELETE FROM Livro WHERE ID = '{id}'";
            var linhasafetadas = livroRepository.excluir(sql);

            if (linhasafetadas != 0)
            {
                return $"O livro do ID : {id} foi excluido com sucesso!";
            }
            else 
            {
                return $"O livro do ID : {id} não existe!";
            }
        }
       
        public Livro buscaLivroPorID(int id){
            string sql = $"SELECT * FROM Livro WHERE ID = '{id}'";
            var livro = livroRepository.buscaLivro(sql);
            return livro;
        }
        public void atualizarLivro(int id, string? titulo = null, string? autor = null, string? genero = null, int? ano = null)
        {
                string sql = $"UPDATE Livro SET ";


                if (titulo != null)
                {
                    sql += $"Titulo = '{titulo}', ";
                    
                }

                if (autor != null)
                {
                    sql += $"Autor = '{autor}', ";
                    
                }

                if (genero != null)
                {
                    sql += $"Genero = '{genero}', ";
                    
                }

                if (ano.HasValue)
                {
                    sql += $"Ano = '{ano}', ";
                }

                // tira virgula e espaço
                sql = sql.TrimEnd(',', ' ');

                // Adiciona o WHERE
                sql += $" WHERE ID = {id}";
                
                livroRepository.atualizar(sql);
        }

        public List<Livro> ExibirCatalogo() 
        {
            var catalogo = new List<Livro>();
            
            var ids = livroRepository.BuscaIds();
            foreach(var id in ids)
            {
                var response = buscaLivroPorID(id);
                
                if (response != null)
                {
                    catalogo.Add(response);
                }
                else
                {
                   break;
                }
            
            }

            // foreach (var item in catalogo)
            // {
            //         Console.WriteLine("ID: " + item.ID);
            //         Console.WriteLine("Titulo: " + item.Titulo);
            //         Console.WriteLine("Autor: " + item.Autor);
            //         Console.WriteLine("Ano: " + item.Ano);
            //         Console.WriteLine("Genero: " + item.Genero);
            //         Console.WriteLine("Pags: " + item.Pags);
            //         Console.WriteLine(new string('-', 20)); // Separador entre os itens
            // }
            return catalogo;
        }
    }
    
    
}