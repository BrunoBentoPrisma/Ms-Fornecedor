using MsFornecedor.Repositorys.Entidades;

namespace MsFornecedor.Dtos
{
    public class PaginacaoDto
    {
        public int Count { get; set; }
        public List<Fornecedor> Lista { get; set; } = new List<Fornecedor>();
    }
}
