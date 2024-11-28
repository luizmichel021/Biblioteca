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
        
        public Service()
        {
        catalogoRepository = new CatalogoRepository();
        inventarioRepository = new InventarioRepository();
        }
  
    }
    
    
}