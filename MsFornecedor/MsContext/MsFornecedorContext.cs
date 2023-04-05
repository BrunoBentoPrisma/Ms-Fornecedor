using Microsoft.EntityFrameworkCore;
using MsFornecedor.Repositorys.Entidades;

namespace MsFornecedor.MsContext
{
    public class MsFornecedorContext : DbContext
    {
        public MsFornecedorContext(DbContextOptions<MsFornecedorContext> options)
            : base(options)
        {
        }

        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Bairro> Bairro { get; set; }
    }
}
