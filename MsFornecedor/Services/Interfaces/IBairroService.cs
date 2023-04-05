using MsFornecedor.Repositorys.Entidades;

namespace MsFornecedor.Services.Interfaces
{
    public interface IBairroService
    {
        Task AdicionarBairro(Bairro bairro);
    }
}
