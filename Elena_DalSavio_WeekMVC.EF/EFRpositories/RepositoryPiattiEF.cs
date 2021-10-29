using Elena_DalSavio_WeekMVC.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elena_DalSavio_WeekMVC.EF
{
    public class RepositoryPiattiEF : IPiattoRepository
    {
        public Piatto Add(Piatto item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Piatti.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Piatto item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Piatti.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Piatto> Fetch()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Piatti.Include(p => p.menuPiatti).ToList();
            }
        }

        public List<Piatto> FetchByMenu(MenuPiatti menuPiattoEsistente)
        {
           using (var ctx = new MasterContext())
            {
                return ctx.Piatti.Include(p => p.menuPiatti).Where(p => p.MenuPiattiId == menuPiattoEsistente.MenuPiattiId).ToList();
            }
        }

        public Piatto GetByCode(string code)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Piatti.Include(p => p.menuPiatti).FirstOrDefault(p => p.PiattoId == code);
            }
        }

        public Piatto Update(Piatto item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Piatti.Update(item);
                ctx.SaveChanges();
            }
            return item;
        }
    }
}
