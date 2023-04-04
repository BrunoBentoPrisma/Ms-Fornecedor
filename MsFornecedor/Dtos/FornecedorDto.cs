namespace MsFornecedor.Dtos
{
    public class FornecedorDto
    {
        public string NomeFornecedor { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string Cpf { get; set; }
        public string InscricaoEstadual { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string NumeroEndereco { get; set; }
        public string Complemento { get; set; }
        public int? BairroId { get; set; }
        public int? CidadeId { get; set; }
        public int EstadoId { get; set; } = 0;
        public string Ddd { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string HomePage { get; set; }
        public string Contato { get; set; }
        public string TelefoneContato { get; set; }
        public int? BancoId { get; set; }
        public string Agencia { get; set; }
        public string ContaCorrenteFornecedor { get; set; }
        public string ResponsavelTecnico { get; set; }
        public string AlvaraSanitario { get; set; }
        public string AutorizacaoFuncionamento { get; set; }
        public string AutorizacaoEspecial { get; set; }
        public string LicencaMapa { get; set; }
        public string CadastroFarmacia { get; set; }
        public int? PlanoDeContaId { get; set; }
        public decimal? ValorMinimoPedido { get; set; }
        public string FormaPagamento { get; set; }
        public int? PrevisaoEntrega { get; set; }
        public string Frete { get; set; }
        public string Observacoes { get; set; }
        public string UsuarioFornecedor { get; set; }
        public string SenhaFornecedor { get; set; }
        public string HostFornecedor { get; set; }
        public string DddCelular { get; set; }
        public int? Contribuinte { get; set; }
    }
}
