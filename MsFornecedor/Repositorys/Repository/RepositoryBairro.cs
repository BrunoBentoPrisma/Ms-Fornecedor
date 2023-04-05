using MsFornecedor.MsContext;
using MsFornecedor.Repositorys.Entidades;
using MsFornecedor.Repositorys.Interfaces;

namespace MsFornecedor.Repositorys.Repository
{
    public class RepositoryBairro : IRepositoryBairro
    {
        protected MsFornecedorContext _dbContext;
        public RepositoryBairro(MsFornecedorContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AdicionarBairro(Bairro bairro)
        {
            _dbContext.Set<Bairro>().Add(bairro);
            await _dbContext.SaveChangesAsync();
        }
    }
}
