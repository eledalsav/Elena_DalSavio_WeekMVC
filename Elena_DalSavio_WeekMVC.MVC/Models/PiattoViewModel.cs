using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elena_DalSavio_WeekMVC.MVC.Models
{
    public class PiattoViewModel
    {
        [Required]
        public string PiattoId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descrizione { get; set; }
        [Required]
        public EnumTipologia Tipologia { get; set; }
        [Required]
        public decimal Prezzo { get; set; }

        public string MenuPiattiId { get; set; }
        public MenuViewModel menuPiatti { get; set; }
    }
    public enum EnumTipologia
    {
        Primo = 1,
        Secondo = 2,
        Contorno = 3,
        Dolce = 4
    }
}
