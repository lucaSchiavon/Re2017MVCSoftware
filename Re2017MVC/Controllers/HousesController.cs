using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Re2017MVC;
using Re2017MVC.Models.Shared;

namespace Re2017MVC.Controllers
{
    public class HousesController : BaseController
    {
        private Model1 db = new Model1();

        // GET: Houses
        public ActionResult Index()
        {
            var vm = InitializeIndexView();
          
            vm.LstHouses = db.House.ToList();
            return View(vm);
            // return View(db.House.ToList());
        }

        // GET: Houses/Details/5
        public ActionResult Details(int? id)
        {
            var vm = InitializeIndexView();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = db.House.Find(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            vm.House = house;

            return View(vm);
            //return View(house);
        }

        // GET: Houses/Create
        public ActionResult Create()
        {
            var vm = InitializeIndexView();
            return View(vm);
        }

        // POST: Houses/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nickname,state,city,street,housePhoto,zillowLink,purchasePrice,sqFeet,sqFeetPrice,constructionYear,grossRent,percVacancy,extimateAccountingExpense,extimateCondoExpense,extimateInsuranceExpense,extimateMaintenanceExpense,extimateProperyManagerExpense,extimateUtilitiesExpense,extimatePestControlExpense,extimatePropertyTax,closingCosts,titleCompanyCosts,agencyCosts,otherClosingCosts,enabled")] House house)
        {
            var vm = InitializeIndexView();

            if (ModelState.IsValid)
            {
                db.House.Add(house);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            House Casa = db.House.Find(house.Id);
            vm.House = Casa;
            return View(vm);
        }

        // GET: Houses/Edit/5
        public ActionResult Edit(int? id)
        {
            var vm = InitializeIndexView();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = db.House.Find(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            vm.House= house;
            return View(vm);
            //return View(house);
        }

        // POST: Houses/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nickname,state,city,street,housePhoto,zillowLink,purchasePrice,sqFeet,sqFeetPrice,constructionYear,grossRent,percVacancy,extimateAccountingExpense,extimateCondoExpense,extimateInsuranceExpense,extimateMaintenanceExpense,extimateProperyManagerExpense,extimateUtilitiesExpense,extimatePestControlExpense,extimatePropertyTax,closingCosts,titleCompanyCosts,agencyCosts,otherClosingCosts,enabled")] House house)
        {
            if (ModelState.IsValid)
            {
                db.Entry(house).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(house);
        }

        // GET: Houses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = db.House.Find(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            return View(house);
        }

        // POST: Houses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            House house = db.House.Find(id);
            db.House.Remove(house);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        #region "rutine private"
        private Re2017MVC.Models.Houses.IndexViewModel InitializeIndexView()
        {
            var vm = new Re2017MVC.Models.Houses.IndexViewModel();
            vm.UtenteCorrente = LoginUsr;
            vm.HeaderVM = new HeaderViewModel
            {
                UtenteCorrente = vm.UtenteCorrente,
                LateralMenuVM = new LateralMenuViewModel()

            };

            return vm;
        }
        #endregion
    }
}
