using MsFornecedor.Dtos;
using MsFornecedor.Repositorys.Entidades;

namespace MsFornecedor.Services.Interfaces
{
    public interface IFornecedorService
    {
        Task<bool> AddFornecedor(FornecedorDto fornecedorDto);
        Task<bool> UpdateFornecedor(Fornecedor fornecedor);
        Task<string> DeleteFornecedor(int id);
        Task<Fornecedor> GetById(int id);
        Task<List<Fornecedor>> ListaFornecedor();
        Task<PaginacaoDto> GetPaginacao(int pagina, string query);
    }
}
