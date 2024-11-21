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

        

    }
    
    
}