using Elena_DalSavio_WeekMVC.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elena_DalSavio_WeekMVC.EF.EFRpositories
{
    public class RepositoryUtentiEF// : IUtentiRepository
    {


        public Utente Add(Utente item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Utente item)
        {
            throw new NotImplementedException();
        }

        public List<Utente> GetAll()
        {
            throw new NotImplementedException();
        }

        public Utente GetByUsername(string username)
        {
            using (var ctx = new MasterContext())
            {
                if (string.IsNullOrEmpty(username))
                {
                    return null;
                }
                return ctx.Utenti.FirstOrDefault(u => u.Username == username);
            }
        }

        public Utente Update(Utente item)
        {
            throw new NotImplementedException();
        }
    }
}
