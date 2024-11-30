using Biblioteca.Models;

namespace Biblioteca.Repository{

    public interface IInventarioRepository
    {
        // Metodos
        bool create(Inventario inventario);

        Inventario getInventario(int id);

        int getQuantidadeLivroInInventario(int ID_Catalogo);

        bool delete(int id);

        bool update(int id, int Id_Catalgo);

        bool updateDisponibilidade(int id, bool Disponivel);



    }

}