using MsFornecedor.Dtos;
using MsFornecedor.Repositorys.Entidades;

namespace MsFornecedor.Validations.Interfaces
{
    public interface IFornecedorValidations
    {
        List<string> ValidationsCreate(FornecedorDto fornecedorDto);
        List<string> ValidationsEdite(Fornecedor fornecedor);
    }
}
