using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroAPI.Domain.Entities
{
    public class Cliente
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O sobrenome é obrigatório")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "A idade é obrigatória")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "O país é obrigatório")]
        public string Pais { get; set; }
    }
}
