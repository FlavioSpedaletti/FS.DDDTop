using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FS.DDDTop.Domain.Entities
{
    public class Reclamacao
    {
        public int ReclamacaoId { get; set; }
        [Required]
        [Column(TypeName = "varchar(250)")]
        public string Descricao { get; set; }
        [Required]
        public bool Resolvida { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
