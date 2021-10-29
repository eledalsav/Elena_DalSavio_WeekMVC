using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elena_DalSavio_WeekMVC.Core
{
    public interface IMenuPiattiRepository:IRepository<MenuPiatti>
    {
        public MenuPiatti GetByCode(string code);
    }
}
