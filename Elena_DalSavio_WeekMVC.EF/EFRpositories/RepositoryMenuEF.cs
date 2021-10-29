using Elena_DalSavio_WeekMVC.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elena_DalSavio_WeekMVC.EF
{
    public class RepositoryMenuEF : IMenuPiattiRepository
    {
        public MenuPiatti Add(MenuPiatti item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.MenuPiatti.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(MenuPiatti item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.MenuPiatti.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<MenuPiatti> Fetch()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.MenuPiatti.Include(m => m.piatti).ToList();
            }
        }

        public MenuPiatti GetByCode(string code)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.MenuPiatti.Include(m => m.piatti).FirstOrDefault(m => m.MenuPiattiId == code);
            }
        }

        public MenuPiatti Update(MenuPiatti item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.MenuPiatti.Update(item);
                ctx.SaveChanges();
            }
            return item;
        }
    }
}
