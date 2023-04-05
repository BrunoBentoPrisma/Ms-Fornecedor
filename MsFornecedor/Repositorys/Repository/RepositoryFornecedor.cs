using Microsoft.EntityFrameworkCore;
using MsFornecedor.Dtos;
using MsFornecedor.MsContext;
using MsFornecedor.Repositorys.Entidades;
using MsFornecedor.Repositorys.Interfaces;

namespace MsFornecedor.Repositorys.Repository
{
    public class RepositoryFornecedor : IRepositoryFornecedor
    {
        public readonly DbContextOptions<MsFornecedorContext> _dbContext;
        public RepositoryFornecedor()
        {
            _dbContext = new DbContextOptions<MsFornecedorContext>();
        }
        public async Task<bool> AddFornecedor(Fornecedor fornecedor)
        {
            using (var context = new MsFornecedorContext(_dbContext))
            {
                try
                {
                    context.Set<Fornecedor>().Add(fornecedor);
                    await context.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public async Task<string> DeleteFornecedor(Fornecedor fornecedor)
        {
            using (var context = new MsFornecedorContext(_dbContext))
            {
                var message = string.Empty;
                try
                {
                    context.Set<Fornecedor>().Remove(fornecedor);
                    await context.SaveChangesAsync();
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
        }

        public async Task<List<Fornecedor>> GetAll()
        {
            using (var context = new MsFornecedorContext(_dbContext))
            {
                return await context.Set<Fornecedor>().ToListAsync();
            }
            
        }

        public async Task<Fornecedor> GetById(int id)
        {
            var fornecedor = new Fornecedor();

            using (var context = new MsFornecedorContext(_dbContext))
            {
                try
                {
                    fornecedor = await context.Set<Fornecedor>().FindAsync(id);
                }
                catch (Exception)
                {
                    fornecedor = null;
                }
            }

            return fornecedor;
        }

        public async Task<PaginacaoDto> GetPaginacao(int pagina, string query)
        {
            var paginacao = new PaginacaoDto();

            try
            {

                using (var context = new MsFornecedorContext(_dbContext))
                {
                    IQueryable<Fornecedor> queryable = context.Fornecedor;

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
                using (var context = new MsFornecedorContext(_dbContext))
                {
                    context.Fornecedor.Update(fornecedor);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task AdicionarBairro(Bairro bairro)
        {
            using (var context = new MsFornecedorContext(_dbContext))
            {
                try
                {
                    context.Set<Bairro>().Add(bairro);
                    await context.SaveChangesAsync();
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
