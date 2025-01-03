using Biblioteca.Models;

namespace Biblioteca.Repository{

    public interface IEmprestimoRepository
    {
        int createEmprestimo(int id_inventario, int id_usuario , DateTime data_emprestimo, DateTime data_devolucao);

        bool devolucao(int id, int id_inventario);
    }

}