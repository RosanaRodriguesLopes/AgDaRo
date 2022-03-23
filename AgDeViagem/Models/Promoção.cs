using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgDeViagem.Models
{
    public class Promoção
    {
        [Key]
        public int Id_Promoção { get; set; }
        public string Desconto { get; set; }
        public string Valor_Final { get; set; }
        public virtual List<Contato> contato { get; set; }

    }
}
