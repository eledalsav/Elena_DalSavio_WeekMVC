using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elena_DalSavio_WeekMVC.Core
{
   public  interface IBusinessLayer
    {
        #region Funzionalità piatti
        public List<Piatto> GetAllPiatti();
        public string AggiungiPiatti(Piatto piatto);
        public string ModificaPiatto(string id, string nome, string descrizione, EnumTipologia tipologia, decimal prezzo, string menuPiattiId);
        public string DeletePiattoById(string id);
        #endregion


        #region Funzionalità menu
        public List<MenuPiatti> GetAllMenu();
        public string AggiungiMenu(MenuPiatti menuPiatti);
        public string ModificaMenu(string id, string nome);
        public string DeleteMenuById(string id);
        public List<Piatto> VisualizzaPiattiMenu(string codice);
        #endregion

        //public Utente GetAccount(string username);
    }
}
