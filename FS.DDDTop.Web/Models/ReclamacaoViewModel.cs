using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FS.DDDTop.Web.Models
{
    public class ReclamacaoViewModel
    {
        [Key]
        public int ReclamacaoId { get; set; }
        [Required(ErrorMessage = "Preencha o campo descrição")]
        [MaxLength(250, ErrorMessage = "Máximo {0} caracteres")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Preencha o campo resolvida")]
        [DisplayName("Resolvida?")]
        public bool Resolvida { get; set; }
        public int ClienteId { get; set; }
        public virtual ClienteViewModel Cliente { get; set; }
    }
}
