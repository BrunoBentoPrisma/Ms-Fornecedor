using MsFornecedor.Repositorys.Entidades;

namespace MsFornecedor.Repositorys.Interfaces
{
    public interface IRepositoryBairro
    {
        Task AdicionarBairro(Bairro bairro);
    }
}
