using Microsoft.EntityFrameworkCore;
using MsFornecedor.Dtos;
using MsFornecedor.MsContext;
using MsFornecedor.Repositorys.Entidades;
using MsFornecedor.Repositorys.Interfaces;

namespace MsFornecedor.Repositorys.Repository
{
    public class RepositoryFornecedor : IRepositoryFornecedor
    {
        protected MsFornecedorContext _dbContext;
        public RepositoryFornecedor(MsFornecedorContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddFornecedor(Fornecedor fornecedor)
        {
            try
            {
                _dbContext.Set<Fornecedor>().Add(fornecedor);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<string> DeleteFornecedor(Fornecedor fornecedor)
        {
            var message = string.Empty;
            try
            {
                _dbContext.Set<Fornecedor>().Remove(fornecedor);
                await _dbContext.SaveChangesAsync();
                message = "Registro excluído com sucesso !";

            }
            catch (DbUpdateException exDb)
            {
                var innerException = exDb.InnerException;
                while (innerException != null)
                {

                    if (innerException is Npgsql.PostgresException pgEx && pgEx.SqlState == "23503")
                    {
                        throw new Exception($"Não é possível excluir o registro porque há registros relacionados na tabela : {pgEx.TableName}", pgEx);
                    }
                    else
                    {
                        throw new Exception($"Ocorreu um erro interno : {innerException.Message}", innerException);
                    }

                }

            }

            return message;
        }

        public async Task<List<Fornecedor>> GetAll()
        {
            return await _dbContext.Set<Fornecedor>().ToListAsync();
        }

        public async Task<Fornecedor> GetById(int id)
        {
            var fornecedor = new Fornecedor();

            try
            {
                fornecedor = await _dbContext.Set<Fornecedor>().FindAsync(id);
            }
            catch (Exception)
            {
                fornecedor = null;
            }

            return fornecedor;
        }

        public async Task<PaginacaoDto> GetPaginacao(int pagina, string query)
        {
            var paginacao = new PaginacaoDto();

            try
            {

                IQueryable<Fornecedor> queryable = _dbContext.Fornecedor;

                if (!string.IsNullOrEmpty(query.Trim()))
                {
                    queryable = queryable.Where(x => EF.Functions.ILike(
                        EF.Functions.Unaccent(x.NomeFornecedor),
                        $"%{query}%"))
                        .OrderBy(x => EF.Functions.ILike(
                        EF.Functions.Unaccent(x.NomeFornecedor),
                        $"{query}%") ? 0 : 1)
                        .ThenBy(x => x.NomeFornecedor);
                }
                else
                {
                    queryable = queryable.OrderByDescending(x => x.Id);
                }

                var total = await queryable.CountAsync();
                var totalPages = (int)Math.Ceiling(total / 10.0);
                pagina = Math.Min(Math.Max(1, pagina), totalPages);

                paginacao.Lista = await queryable.Skip((pagina - 1) * 10)
                                                 .Take(10)
                                                 .ToListAsync();

                paginacao.Count = totalPages;

            }
            catch (Exception)
            {
                paginacao = null;
            }

            return paginacao;
        }

        public async Task<bool> UpdateFornecedor(Fornecedor fornecedor)
        {
            try
            {
                _dbContext.Fornecedor.Update(fornecedor);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
