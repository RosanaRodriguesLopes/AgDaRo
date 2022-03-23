using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgDeViagem.Models
{
    public class Passagem
    {
        [Key]
        public int Id_Passagem { get; set; }
        public string Destino { get; set; }
        public DateTime Data_Ida { get; set; }
        public DateTime Data_Volta { get; set; }
        public string Valor { get; set; }
        [ForeignKey("Contato")]
        public int Id_Contato { get; set; }
        public virtual Contato contato { get; set; }
        [ForeignKey ("Promoção")]
        public int Id_Promoção { get; set; }
        public virtual Promoção promoção { get; set; }


    }
}
