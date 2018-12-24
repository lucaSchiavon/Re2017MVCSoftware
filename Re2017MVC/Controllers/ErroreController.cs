using Re2017MVC.Models.Errore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Re2017MVC.Models.Shared;

namespace Re2017MVC.Controllers
{
    public class ErroreController : BaseController
    {
        // GET: Errore
        public ActionResult Index(string Errore)
        {

            var vm = new IndexViewModel();

            vm.UtenteCorrente = LoginUsr;
            vm.HeaderVM = new HeaderViewModel
            {
                UtenteCorrente = vm.UtenteCorrente,
                LateralMenuVM = new LateralMenuViewModel()

            };
            vm.Messaggio = Errore;
            return View(vm);
        }
    }
}