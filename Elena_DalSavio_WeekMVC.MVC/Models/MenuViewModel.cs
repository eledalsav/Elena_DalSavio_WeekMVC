using Elena_DalSavio_WeekMVC.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elena_DalSavio_WeekMVC.MVC.Models
{
    public class MenuViewModel
    {
        [Required]
        public string MenuPiattiId { get; set; }
        [Required]
        public string Nome { get; set; }

        public List<PiattoViewModel> piatti { get; set; } = new List<PiattoViewModel>();
    }
}
