using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FS.DDDTop.Domain.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        //[StringLength(100)] -> nvarchar
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Nome { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Sobrenome { get; set; }
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public virtual ICollection<Reclamacao> Reclamacoes { get; set; }

        //regra de negócio qualquer
        //as entidades possuem propriedades e métodos (estados e comportamentos)
        public bool ClienteEspecial(Cliente cliente)
        {
            return cliente.Ativo && DateTime.Now.Year - cliente.DataCadastro.Year >= 5; 
        }
    }
}
