using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FS.DDDTop.Web.Models
{
    public class ClienteViewModel
    {
        [Key]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "Preencha o campo nome")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Preencha o campo sobrenome")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "Preencha o campo e-mail")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um e-mail válido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }
        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public virtual ICollection<ReclamacaoViewModel> Reclamacoes { get; set; }
    }
}
