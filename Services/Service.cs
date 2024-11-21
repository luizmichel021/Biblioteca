using Biblioteca.Repository;
using Biblioteca.Models;
using Microsoft.VisualBasic;
using Org.BouncyCastle.Asn1.Misc;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Biblioteca.Services{

    public class Service
    {
        private CatalogoRepository catalogoRepository;

        private InventarioRepository inventarioRepository;
        
        public Service()
        {
        catalogoRepository = new CatalogoRepository();
        inventarioRepository = new InventarioRepository();
        }
   
        public List<Catalogo> listarCatalogo() 
        {
            
            var i= 1;
            var listaCatalogo = new List<Catalogo>();
            

            while(true)
            {
                var response = catalogoRepository.obterPorID(i);
                
                if (response != null)
                {
                    listaCatalogo.Add(response);
                    i++;
                }
                else
                {
                   break;
                }
            
            }

            foreach (var item in listaCatalogo)
            {
                    Console.WriteLine("ID: " + item.ID);
                    Console.WriteLine("Titulo: " + item.Titulo);
                    Console.WriteLine("Autor: " + item.Autor);
                    Console.WriteLine("Ano: " + item.Ano);
                    Console.WriteLine("Genero: " + item.Genero);
                    Console.WriteLine("Pags: " + item.Pags);
                    Console.WriteLine(new string('-', 20)); // Separador entre os itens
            }
            return listaCatalogo;
        }


        public void atualizarCatalogo(int id, string? titulo = null, string? autor = null, string? genero = null, int? ano = null)
        {
                string sql = $"UPDATE Catalogo SET ";


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
                
                catalogoRepository.atualizar(sql);
                // catalogoRepository.atualizar(sql);
            
        }

        

    }
    
    
}