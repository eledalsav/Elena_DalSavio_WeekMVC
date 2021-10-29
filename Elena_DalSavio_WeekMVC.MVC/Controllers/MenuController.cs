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
    public class MenuController : Controller
    {
        private readonly IBusinessLayer BL;
        public MenuController(IBusinessLayer bl)
        {
            BL = bl;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var menu = BL.GetAllMenu();

            List<MenuViewModel> menuViewModel = new List<MenuViewModel>();

            foreach (var item in menu)
            {
                menuViewModel.Add(item.toMenuViewModel());
            }
            return View(menuViewModel);
        }


        [HttpGet]
        public IActionResult Details(string id)
        {
            var menu = BL.GetAllMenu().FirstOrDefault(m => m.MenuPiattiId == id);
            var menuViewModel = menu.toMenuViewModel();

            return View(menuViewModel);
        }

        //add
        //[Authorize(Policy = "Adm")] //non solo chiede il login/autenticazione ma richiede che il ruolo sia Administrator
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //[Authorize(Policy = "Adm")] //non solo chiede il login/autenticazione ma richiede che il ruolo sia Administrator
        [HttpPost]
        public IActionResult Create(MenuViewModel menuViewModel)
        {
            if (ModelState.IsValid) //se la validazione è andata a buon fine, aggiungo alla lista e torno alla Index
            {
                BL.AggiungiMenu(menuViewModel.toMenuPiatti());
                return RedirectToAction(nameof(Index)); //qui mi rimandi alla index
            }
            LoadViewBag();
            return View(menuViewModel); //se non va a buon fine, ritorno 
        }

        //Edit
        //[Authorize(Policy = "Adm")] //non solo chiede il login/autenticazione ma richiede che il ruolo sia Administrator
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var menu = BL.GetAllMenu().FirstOrDefault(m => m.MenuPiattiId == id);
            var menuViewModel = menu.toMenuViewModel();
            return View(menuViewModel);
        }

        [HttpPost]
        //[Authorize(Policy = "Adm")] //non solo chiede il login/autenticazione ma richiede che il ruolo sia Administrator
        public IActionResult Edit(MenuViewModel menuViewModel)
        {
            var menu = menuViewModel.toMenuPiatti();

            if (ModelState.IsValid) //se la validazione è andata a buon fine, aggiungo alla lista e torno alla Index
            {
                BL.ModificaMenu(menu.MenuPiattiId, menu.Nome);
                return RedirectToAction(nameof(Index)); //qui mi rimandi alla index
            }
            LoadViewBag();
            return View(menuViewModel); //se non va a buon fine, ritorno 
        }

        //Delete
        //[Authorize(Policy = "Adm")] //non solo chiede il login/autenticazione ma richiede che il ruolo sia Administrator
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var menu = BL.GetAllMenu().FirstOrDefault(m => m.MenuPiattiId == id);
            var menuViewModel = menu.toMenuViewModel();
            return View(menuViewModel);
        }

        [HttpPost]
        //[Authorize(Policy = "Adm")] //non solo chiede il login/autenticazione ma richiede che il ruolo sia Administrator
        public IActionResult Delete(MenuViewModel menuViewModel)
        {
            var menu = menuViewModel.toMenuPiatti();

            if (ModelState.IsValid)
            {
                BL.DeleteMenuById(menuViewModel.MenuPiattiId);
                return RedirectToAction(nameof(Index));
            }
            return View(menuViewModel);
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
