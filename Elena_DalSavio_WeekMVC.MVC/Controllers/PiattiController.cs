using Elena_DalSavio_WeekMVC.Core;
using Elena_DalSavio_WeekMVC.MVC.Helper;
using Elena_DalSavio_WeekMVC.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elena_DalSavio_WeekMVC.MVC.Controllers
{
    public class PiattiController : Controller
    {
        private readonly IBusinessLayer BL;
        public PiattiController(IBusinessLayer bl)
        {
            BL = bl;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var piatti = BL.GetAllPiatti();

            List<PiattoViewModel> piattiViewModel = new List<PiattoViewModel>();

            foreach (var item in piatti)
            {
                piattiViewModel.Add(item.toPiattoViewModel());
            }
            return View(piattiViewModel);
        }


        [HttpGet]
        public IActionResult Details(string id)
        {
            var piatti = BL.GetAllPiatti().FirstOrDefault(p => p.PiattoId == id);
            var piattoViewModel = piatti.toPiattoViewModel();

            return View(piattoViewModel);
        }

        //add
        //[Authorize(Policy = "Adm")] //non solo chiede il login/autenticazione ma richiede che il ruolo sia Administrator
        [HttpGet]
        public IActionResult Create()
        {
            LoadViewBag();
            return View();
        }

        //[Authorize(Policy = "Adm")] //non solo chiede il login/autenticazione ma richiede che il ruolo sia Administrator
        [HttpPost]
        public IActionResult Create(PiattoViewModel piattoViewModel)
        {
            if (ModelState.IsValid) 
            {
                BL.AggiungiPiatti(piattoViewModel.toPiatto());
                return RedirectToAction(nameof(Index));
            }
            LoadViewBag();
            return View(piattoViewModel);  
        }

        //Edit
        //[Authorize(Policy = "Adm")] //non solo chiede il login/autenticazione ma richiede che il ruolo sia Administrator
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var piatti = BL.GetAllPiatti().FirstOrDefault(p => p.PiattoId == id);
            var piattiViewModel = piatti.toPiattoViewModel();
            return View(piattiViewModel);
        }

        [HttpPost]
        //[Authorize(Policy = "Adm")] //non solo chiede il login/autenticazione ma richiede che il ruolo sia Administrator
        public IActionResult Edit(PiattoViewModel piattiViewModel)
        {
            var piatti = piattiViewModel.toPiatto();

            if (ModelState.IsValid) //se la validazione è andata a buon fine, aggiungo alla lista e torno alla Index
            {
                BL.ModificaPiatto(piatti.PiattoId, piatti.Nome, piatti.Descrizione, piatti.Tipologia, piatti.Prezzo, piatti.MenuPiattiId);
                return RedirectToAction(nameof(Index)); //qui mi rimandi alla index
            }
            LoadViewBag();
            return View(piattiViewModel); //se non va a buon fine, ritorno 
        }

        //Delete
        //[Authorize(Policy = "Adm")] //non solo chiede il login/autenticazione ma richiede che il ruolo sia Administrator
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var piatto = BL.GetAllPiatti().FirstOrDefault(p => p.PiattoId== id);
            var piattoViewModel = piatto.toPiattoViewModel();
            return View(piattoViewModel);
        }

        [HttpPost]
        //[Authorize(Policy = "Adm")] //non solo chiede il login/autenticazione ma richiede che il ruolo sia Administrator
        public IActionResult Delete(PiattoViewModel piattoViewModel)
        {
            var piatto = piattoViewModel.toPiatto();

            if (ModelState.IsValid)
            {
                BL.DeletePiattoById(piattoViewModel.PiattoId);
                return RedirectToAction(nameof(Index));
            }
            return View(piattoViewModel);
        }


        private void LoadViewBag()
        {
            ViewBag.Tipologia = new SelectList(new[]{
                new { Value="1", Text="Primo"},
                new { Value="2", Text="Secondo"},
                new { Value="3", Text="Contorno"},
                new { Value="4", Text="Dolce"} }.OrderBy(x => x.Text), "Value", "Text");
        }
    }
}
