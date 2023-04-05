using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MsFornecedor.Repositorys.Entidades
{
    [Table("Bairro")]
    public class Bairro
    {
        [Column("Id")]
        public Guid Id { get; set; }
        [Column("Nome")]
        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }
        [Column("EmpresaId")]
        public Guid EmpresaId { get; set; }
    }
}
