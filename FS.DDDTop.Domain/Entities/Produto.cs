using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FS.DDDTop.Domain.Entities
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        [Required]
        [Column(TypeName = "varchar(250)")]
        public string Nome { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }
        public bool Disponivel { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
