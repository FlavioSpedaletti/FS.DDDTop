using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FS.DDDTop.MVC.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int ProdutoId { get; set; }
        [Required(ErrorMessage = "Preencha o campo nome")]
        [MaxLength(250, ErrorMessage = "Máximo {0} caracteres")]
        public string Nome { get; set; }
        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "999999999999")]
        [Required(ErrorMessage = "Preencha o campo valor")]
        public decimal Valor { get; set; }
        [DisplayName("Disponível?")]
        public bool Disponivel { get; set; }
        public int ClienteId { get; set; }
        public virtual ClienteViewModel Cliente { get; set; }
    }
}
