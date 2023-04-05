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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(GetStringConectionConfig());
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // builder.ForNpgsqlUseIdentityColumns();
            base.OnModelCreating(builder);
        }

        private static string GetStringConectionConfig()

        {
            string strCon = "User ID=postgres; Password=prixpto; Host=zeus.prismafive.com.br; Port=49282; Database=Ms-Teste; Pooling=true;";
            //string strCon = "User ID=postgres; Password=prixpto; Host=10.3.25.11; Port=49282; Database=farmafacil-web2; Pooling=true;";
            //string strCon = "User ID=postgres; Password=prixpto; Host=zeus.prismafive.com.br; Port=49282; Database=farmafacil-web-teste; Pooling=true;";
            return strCon;
        }
    }
}
