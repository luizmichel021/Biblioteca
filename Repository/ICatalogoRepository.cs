using Biblioteca.Models;

namespace Biblioteca.Repository{   
    public interface ICatalogoRepository
    {
    int create(Catalogo catalogo);
    Catalogo getCatalogo(int id);
    int delete(int id);
    void update(int id, string? titulo = null, string? autor = null, string? genero = null, int? ano = null, int? pags = null);
    List<int> getAllIdsCatalogo();

    }
}