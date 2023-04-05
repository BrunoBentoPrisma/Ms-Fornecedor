using MsFornecedor.Dtos;
using MsFornecedor.Repositorys.Entidades;

namespace MsFornecedor.Repositorys.Interfaces
{
    public interface IRepositoryFornecedor
    {
        Task<bool> AddFornecedor(Fornecedor fornecedor);
        Task<bool> UpdateFornecedor(Fornecedor fornecedor);
        Task<string> DeleteFornecedor(Fornecedor fornecedor);
        Task<Fornecedor> GetById(int id);
        Task<List<Fornecedor>> GetAll();
        Task<PaginacaoDto> GetPaginacao(int pagina, string query);
        Task AdicionarBairro(Bairro bairro);
    }
}
