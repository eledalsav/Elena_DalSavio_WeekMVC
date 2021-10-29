using Elena_DalSavio_WeekMVC.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elena_DalSavio_WeekMVC.Core.Repositories
{
    public interface IRepositoryUtenti : IRepository<Utente>
    {
        Utente GetByUsername(string username);
    }
}
