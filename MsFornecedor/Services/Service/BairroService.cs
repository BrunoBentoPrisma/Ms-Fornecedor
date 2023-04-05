using MsFornecedor.Repositorys.Entidades;
using MsFornecedor.Repositorys.Interfaces;
using MsFornecedor.Services.Interfaces;

namespace MsFornecedor.Services.Service
{
    public class BairroService : IBairroService
    {
        private static IRepositoryBairro _repositoryBairro;

        public BairroService(IRepositoryBairro repositoryBairro)
        {
            _repositoryBairro = repositoryBairro;
        }
        public async Task AdicionarBairro(Bairro bairro)
        {
            await _repositoryBairro.AdicionarBairro(bairro);
        }
    }
}
