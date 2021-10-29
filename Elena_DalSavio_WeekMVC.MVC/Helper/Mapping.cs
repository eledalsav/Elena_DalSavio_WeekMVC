using Elena_DalSavio_WeekMVC.Core;
using Elena_DalSavio_WeekMVC.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elena_DalSavio_WeekMVC.MVC.Helper
{
    public static class Mapping
    {
        public static PiattoViewModel toPiattoViewModel(this Piatto piatto)
        {
            return new PiattoViewModel
            {
                PiattoId=piatto.PiattoId,
                Nome=piatto.Nome,
                Descrizione=piatto.Descrizione,
                Tipologia= (Models.EnumTipologia)piatto.Tipologia,
                Prezzo=piatto.Prezzo,
                MenuPiattiId=piatto.MenuPiattiId
            };
        }

        public static Piatto toPiatto(this PiattoViewModel piattoViewModel)
        {
            return new Piatto
            {
                PiattoId = piattoViewModel.PiattoId,
                Nome = piattoViewModel.Nome,
                Descrizione = piattoViewModel.Descrizione,
                Tipologia = (Core.EnumTipologia)piattoViewModel.Tipologia,
                Prezzo = piattoViewModel.Prezzo,
                MenuPiattiId = piattoViewModel.MenuPiattiId
                //Lezioni = null
            };
        }

        public static MenuViewModel toMenuViewModel(this MenuPiatti menuPiatti)
        {
            List<PiattoViewModel> piattiViewModel = new List<PiattoViewModel>();
            foreach (var item in menuPiatti.piatti)
            {
                piattiViewModel.Add(item.toPiattoViewModel());
            }
            return new MenuViewModel
            {
                MenuPiattiId =menuPiatti.MenuPiattiId,
                Nome=menuPiatti.Nome
                
            };
        }

        public static MenuPiatti toMenuPiatti(this MenuViewModel menuViewModel)
        {
            List<Piatto> piatti = new List<Piatto>();
            foreach (var item in menuViewModel.piatti)
            {
                piatti.Add(item.toPiatto());
            }
            return new MenuPiatti
            {
                MenuPiattiId = menuViewModel.MenuPiattiId,
                Nome = menuViewModel.Nome

            };
        }

        
    }
}
