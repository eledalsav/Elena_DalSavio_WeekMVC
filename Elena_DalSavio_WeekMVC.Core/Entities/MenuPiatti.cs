using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elena_DalSavio_WeekMVC.Core
{
    public class MenuPiatti
    {
        public string MenuPiattiId { get; set; }
        public string Nome { get; set; }

        public List<Piatto> piatti { get; set; } = new List<Piatto>();
    }
}
