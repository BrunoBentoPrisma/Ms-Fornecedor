using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MsFornecedor.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeFornecedor = table.Column<string>(type: "text", nullable: false),
                    NomeFantasia = table.Column<string>(type: "text", nullable: false),
                    Cnpj = table.Column<string>(type: "text", nullable: false),
                    Cpf = table.Column<string>(type: "text", nullable: false),
                    InscricaoEstadual = table.Column<string>(type: "text", nullable: false),
                    Cep = table.Column<string>(type: "text", nullable: true),
                    Endereco = table.Column<string>(type: "text", nullable: true),
                    NumeroEndereco = table.Column<string>(type: "text", nullable: true),
                    Complemento = table.Column<string>(type: "text", nullable: true),
                    BairroId = table.Column<int>(type: "integer", nullable: true),
                    CidadeId = table.Column<int>(type: "integer", nullable: true),
                    EstadoId = table.Column<int>(type: "integer", nullable: false),
                    Ddd = table.Column<string>(type: "text", nullable: true),
                    Telefone = table.Column<string>(type: "text", nullable: true),
                    Celular = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    HomePage = table.Column<string>(type: "text", nullable: true),
                    Contato = table.Column<string>(type: "text", nullable: true),
                    TelefoneContato = table.Column<string>(type: "text", nullable: true),
                    BancoId = table.Column<int>(type: "integer", nullable: true),
                    Agencia = table.Column<string>(type: "text", nullable: true),
                    ContaCorrenteFornecedor = table.Column<string>(type: "text", nullable: true),
                    ResponsavelTecnico = table.Column<string>(type: "text", nullable: true),
                    AlvaraSanitario = table.Column<string>(type: "text", nullable: true),
                    AutorizacaoFuncionamento = table.Column<string>(type: "text", nullable: true),
                    AutorizacaoEspecial = table.Column<string>(type: "text", nullable: true),
                    LicencaMapa = table.Column<string>(type: "text", nullable: true),
                    CadastroFarmacia = table.Column<string>(type: "text", nullable: true),
                    PlanoDeContaId = table.Column<int>(type: "integer", nullable: true),
                    ValorMinimoPedido = table.Column<decimal>(type: "numeric", nullable: true),
                    FormaPagamento = table.Column<string>(type: "text", nullable: true),
                    PrevisaoEntrega = table.Column<int>(type: "integer", nullable: true),
                    Frete = table.Column<string>(type: "text", nullable: true),
                    Observacoes = table.Column<string>(type: "text", nullable: true),
                    UsuarioFornecedor = table.Column<string>(type: "text", nullable: true),
                    SenhaFornecedor = table.Column<string>(type: "text", nullable: true),
                    HostFornecedor = table.Column<string>(type: "text", nullable: true),
                    DddCelular = table.Column<string>(type: "text", nullable: true),
                    Contribuinte = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fornecedor");
        }
    }
}
