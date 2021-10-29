using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elena_DalSavio_WeekMVC.Core
{
    public class MainBusinessLayer : IBusinessLayer
    {
        private readonly IPiattoRepository piattiRepo;
        private readonly IMenuPiattiRepository menuRepo;
        //private readonly IUtentiRepository utentiRepo;

        //public MainBusinessLayer(IPiattoRepository piatti, IMenuPiattiRepository menu, IUtentiRepository utnti)
        //{
        //    piattiRepo = piatti;
        //    menuRepo = menu;
        //    utentiRepo = utenti;
        //}

        public MainBusinessLayer(IPiattoRepository piatti, IMenuPiattiRepository menu)
        {
            piattiRepo = piatti;
            menuRepo = menu;
        }
        public string AggiungiMenu(MenuPiatti menuPiatti)
        {
            var menuEsistente = menuRepo.GetByCode(menuPiatti.MenuPiattiId);
            if (menuEsistente != null)
            {
                return "Errore : codice menu già presente";
            }
            menuRepo.Add(menuPiatti);
            return "Il menu è stato aggiunto correttamente";
        }

        public string AggiungiPiatti(Piatto piatto)
        {
            var piattoEsistente = piattiRepo.GetByCode(piatto.PiattoId);
            if (piattoEsistente != null)
            {
                return "Errore : piatto corso già presente";
            }
            piattiRepo.Add(piatto);
            return "Il piatto è stato aggiunto correttamente"; throw new NotImplementedException();
        }

        public string DeleteMenuById(string id)
        {
            var menuEsistente = menuRepo.GetByCode(id);
            if (menuEsistente == null)
            {
                return "Errore : il menu inserito non esiste";
            }

            menuRepo.Delete(menuEsistente);
            return "menu eliminato correttamente";
        }

        public string DeletePiattoById(string id)
        {
            var piattoEsistente = piattiRepo.GetByCode(id);
            if (piattoEsistente == null)
            {
                return "Errore : il piatto inserito non esiste";
            }

            piattiRepo.Delete(piattoEsistente);
            return "Piatto eliminato correttamente";
        }

        public List<MenuPiatti> GetAllMenu()
        {
            return menuRepo.Fetch();
        }

        public List<Piatto> GetAllPiatti()
        {
            return piattiRepo.Fetch();
        }

        public string ModificaMenu(string id, string nome)
        {
            var menuEsistente = menuRepo.GetByCode(id);
            if (menuEsistente == null)
            {
                return "Errore : il menu inserito non esiste";
            }

            menuEsistente.Nome = nome;

            menuRepo.Update(menuEsistente);
            return "Menu aggiornato con successo";
        }

        public string ModificaPiatto(string id, string nome, string descrizione, EnumTipologia tipologia, decimal prezzo, string menuPiattiId)
        {
            var piattoEsistente = piattiRepo.GetByCode(id);
            if (piattoEsistente == null)
            {
                return "Errore : il piatto inserito non esiste";
            }

            piattoEsistente.Nome = nome;
            piattoEsistente.Descrizione = descrizione;
            piattoEsistente.Tipologia = tipologia;
            piattoEsistente.Prezzo = prezzo;
            piattoEsistente.MenuPiattiId = menuPiattiId;
        
            piattiRepo.Update(piattoEsistente);
            return "Piatto aggiornato con successo";
        }

        public List<Piatto> VisualizzaPiattiMenu(string codice)
        {
            var menuEsistente = menuRepo.GetByCode(codice);
            if (menuEsistente == null)
            {
                return null;
            }

            var piattiMenu =piattiRepo.FetchByMenu(menuEsistente);

            return piattiMenu;
        }

        //public Utente GetAccount(string username)
        //{
        //    if (string.IsNullOrEmpty(username))
        //    {
        //        return null;
        //    }
        //    return utentiRepo.GetByUsername(username);
        //}
    }
}
