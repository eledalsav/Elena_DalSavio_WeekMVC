using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elena_DalSavio_WeekMVC.Core
{
    public interface IPiattoRepository: IRepository<Piatto>
    {
        public Piatto GetByCode(string code);
        public List<Piatto> FetchByMenu(MenuPiatti menuPiattoEsistente);
    }
}
