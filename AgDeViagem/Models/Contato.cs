using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgDeViagem.Models
{
    public class Contato
    {
        [Key]
        public int Id_Contato { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public String Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public int Senha { get; set; }
        public virtual List<Contato> contato { get; set; }
    }
}