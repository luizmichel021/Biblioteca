using Biblioteca.Models;

namespace Biblioteca.Repository{
    public interface IUsuarioRepository
    {
        int create(Usuario usuario);
        
        bool delete(int id);

        Usuario GetUsuario(int id);

        bool update(int id, string? nome = null, string? endereco = null, string? email = null, long? telefone = null, DateTime? datanascimento = null);

    }
}