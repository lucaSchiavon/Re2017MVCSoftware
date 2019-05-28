using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Ls.Prj.DTO;
using Ls.Prj.Utility;
using Re2017.Classes;
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

            UsaHousesPageManager ObjUsaHousesPageManager = new UsaHousesPageManager();

            //cod da decommentare con chiamata ad api
            //****************************************
            List<UsaHouseDTO> LstUsaHouses = new List<UsaHouseDTO>();
            List<UsaHouseDTO> LstUsaHousesWithDefault = new List<UsaHouseDTO>();

            if ( LoginUsr.role.Trim() == "INVESTOR")
            {
                LstUsaHouses = ObjUsaHousesPageManager.GetUSAHouses(LoginUsr.id.ToString());
            }
            else
            {
                LstUsaHouses = ObjUsaHousesPageManager.GetUSAHouses("");
            }

           

            foreach (UsaHouseDTO HouseObj in LstUsaHouses)
            {
                LstUsaHousesWithDefault.Add(SetDefaultForHouseDTO(HouseObj));
            }
            vm.LstHouses = LstUsaHousesWithDefault;
            //****************************************

            //vm.LstHouses = db.House.ToList();
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
            UsaHousesPageManager UsaHousesPageManagerObj = new UsaHousesPageManager();
            //Ls.Prj.Entity.House house = UsaHousesPageManagerObj.GetUsaHouse((int)id);
          UsaHouseDTO UsaHouseDTOObj= UsaHousesPageManagerObj.GetUsaHouseDTO((int)id);
            UsaHouseDTOObj = SetDefaultForHouseDTO(UsaHouseDTOObj);
           // house = SetDefaultForHouseEntity(house);
            //House house = db.House.Find(id);
            if (UsaHouseDTOObj == null)
            {
                return HttpNotFound();
            }
            RptHouseManagementManager ObjRptHouseManagementManager = new RptHouseManagementManager();
            List<HouseReportDTO> LstRptDTO = new List<HouseReportDTO>();
           LstRptDTO= ObjRptHouseManagementManager.GetReportsForHouses(UsaHouseDTOObj.Id.ToString());
           // http://2.235.241.7:8080//houses/5/reports/years/2018
            //*********************
            //codice vecchio
            //string report1 = Utility.ReadSetting("Re2017ApiUrl") + "/houses/" + UsaHouseDTOObj.Id + "/reports/years/2018";
            // string report2 = Utility.ReadSetting("Re2017ApiUrl") + "/houses/" + UsaHouseDTOObj.Id + "/reports/years/2019";
            //HouseReportDTO ObjHouseReportDTO1 = new HouseReportDTO();
            //ObjHouseReportDTO1.reportUrl = report1;
            //ObjHouseReportDTO1.year = "2018";
            //HouseReportDTO ObjHouseReportDTO2 = new HouseReportDTO();
            //ObjHouseReportDTO2.reportUrl = report2;
            //ObjHouseReportDTO2.year = "2019";
            //vm.ReportsUrl = new List<HouseReportDTO>() { ObjHouseReportDTO1, ObjHouseReportDTO2 };
            ////*********************

            vm.ReportsUrl = LstRptDTO;
           
            vm.HouseDTO = UsaHouseDTOObj;
            //vm.House = house;

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
        public ActionResult Create(Ls.Prj.Entity.House house)
        {
        //    public ActionResult Create([Bind(Include = "Id,nickname,state,city,address,housePhoto,zillowLink,purchasePrice,sqFeet,sqFeetPrice,constructionYear,grossRent,percVacancy,extimateAccountingExpense,extimateCondoExpense,extimateInsuranceExpense,extimateMaintenanceExpense,extimateProperyManagerExpense,extimateUtilitiesExpense,extimatePestControlExpense,extimatePropertyTax,closingCosts,titleCompanyCosts,agencyCosts,otherClosingCosts,enabled")] Ls.Prj.Entity.House house)
        //{
            var vm = InitializeIndexView();
            UsaHousesPageManager ObjUsaHousesPageManager = new UsaHousesPageManager();
            Ls.Prj.Entity.House ObjHouse=null;
            Ls.Prj.Entity.House HouseObj = SetDefaultForHouseEntity(house);
            if (ModelState.IsValid)
            {
             
                ObjHouse = ObjUsaHousesPageManager.NewUsaHouse(HouseObj);

                //db.House.Add(HouseObj);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            //Ls.Prj.Entity.House Casa = ObjUsaHousesPageManager.GetUsaHouse(ObjHouse.id);
           // House Casa = db.House.Find(house.Id);

            vm.House = house;

            //vm.House = new UsaHouseDTO();
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
            UsaHousesPageManager UsaHousesPageManagerObj = new UsaHousesPageManager();
            Ls.Prj.Entity.House house = UsaHousesPageManagerObj.GetUsaHouse((int)id);
            //TODO:Da togliere!!!
            house = SetDefaultForHouseEntity(house);
            //House house = db.House.Find(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            vm.House= house;

            //vm.House = new Ls.Prj.Entity.House();
            return View(vm);
            //return View(house);
        }

        // POST: Houses/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ls.Prj.Entity.House house)
        {
        //    public ActionResult Edit([Bind(Include = "Id,nickname,state,city,street,housePhoto,zillowLink,purchasePrice,sqFeet,sqFeetPrice,constructionYear,grossRent,percVacancy,extimateAccountingExpense,extimateCondoExpense,extimateInsuranceExpense,extimateMaintenanceExpense,extimateProperyManagerExpense,extimateUtilitiesExpense,extimatePestControlExpense,extimatePropertyTax,closingCosts,titleCompanyCosts,agencyCosts,otherClosingCosts,enabled")] House house)
        //{
            if (ModelState.IsValid)
            {
                UsaHousesPageManager ObjUsaHousesPageManager = new UsaHousesPageManager();
                ObjUsaHousesPageManager.UpdateUsaHouse(house);
                //db.Entry(house).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(house);
        }

        //// GET: Houses/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    House house = db.House.Find(id);
        //    if (house == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(house);
        //}

        //// POST: Houses/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    House house = db.House.Find(id);
        //    db.House.Remove(house);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
                LateralMenuVM = new LateralMenuViewModel { UserRole = LoginUsr.role.Trim() }
               
            };

            List<SelectListItem> LstSelectListItem = new List<SelectListItem>();
            LstSelectListItem.Add(new SelectListItem { Text = "YES", Value = "TRUE", Selected = true });
            LstSelectListItem.Add(new SelectListItem { Text = "NO", Value = "FALSE" });

            vm.LstYesNo = LstSelectListItem;
          
            return vm;
        }

        //private House SetDefaultForHouse(House HouseObj)
        //{
        //    Type type = HouseObj.GetType();
        //    PropertyInfo[] properties = type.GetProperties();

        //    foreach (PropertyInfo property in properties)
        //    {
        //        if (property.PropertyType == typeof(decimal?))
        //        {
        //            //    if (property.GetType()== typeof(decimal?))
        //            //{
        //            if (property.GetValue(HouseObj, null) == null)
        //            {
        //                property.SetValue(HouseObj, (decimal)0, null);
        //            }
        //        }
        //        else if (property.PropertyType == typeof(int?))
        //        {
        //            //    if (property.GetType()== typeof(decimal?))
        //            //{
        //            if (property.GetValue(HouseObj, null) == null)
        //            {
        //                property.SetValue(HouseObj, 0, null);
        //            }
        //        }
        //        else if (property.PropertyType == typeof(bool?))
        //        {
        //            //    if (property.GetType()== typeof(decimal?))
        //            //{
        //            if (property.GetValue(HouseObj, null) == null)
        //            {
        //                property.SetValue(HouseObj, true, null);
        //            }
        //        }

        //        Console.WriteLine("Name: " + property.Name + ", Value: " + property.GetValue(HouseObj, null));
        //    }

        //    if (HouseObj.agencyCosts == null)
        //    {
        //        HouseObj.agencyCosts = 0;
        //    }
        //    return HouseObj;
        //}
        private UsaHouseDTO SetDefaultForHouseDTO(UsaHouseDTO HouseObj)
        {
            Type type = HouseObj.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType == typeof(decimal?))
                {
                    //    if (property.GetType()== typeof(decimal?))
                    //{
                    if (property.GetValue(HouseObj, null) == null)
                    {
                        property.SetValue(HouseObj, (decimal)1, null);
                    }
                }
                else if (property.PropertyType == typeof(int?))
                {
                    //    if (property.GetType()== typeof(decimal?))
                    //{
                    if (property.GetValue(HouseObj, null) == null)
                    {
                        property.SetValue(HouseObj, 0, null);
                    }
                }
                else if (property.PropertyType == typeof(bool?))
                {
                    //    if (property.GetType()== typeof(decimal?))
                    //{
                    if (property.GetValue(HouseObj, null) == null)
                    {
                        property.SetValue(HouseObj, true, null);
                    }
                }
                else if (property.PropertyType == typeof(double?))
                {
                    //    if (property.GetType()== typeof(decimal?))
                    //{
                    if (property.GetValue(HouseObj, null) == null)
                    {
                        property.SetValue(HouseObj, 0, null);
                    }
                }

                Console.WriteLine("Name: " + property.Name + ", Value: " + property.GetValue(HouseObj, null));
            }

            if (HouseObj.agencyCosts == null)
            {
                HouseObj.agencyCosts = 0;
            }
            return HouseObj;
        }
        private Ls.Prj.Entity.House SetDefaultForHouseEntity(Ls.Prj.Entity.House HouseObj)
        {
            Type type = HouseObj.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType == typeof(decimal?))
                {
                    //    if (property.GetType()== typeof(decimal?))
                    //{
                    if (property.GetValue(HouseObj, null) == null)
                    {
                        property.SetValue(HouseObj, (decimal)1, null);
                    }
                }
                else if (property.PropertyType == typeof(int?))
                {
                    //    if (property.GetType()== typeof(decimal?))
                    //{
                    if (property.GetValue(HouseObj, null) == null)
                    {
                        property.SetValue(HouseObj, 1, null);
                    }
                }
                else if (property.PropertyType == typeof(bool?))
                {
                    //    if (property.GetType()== typeof(decimal?))
                    //{
                    if (property.GetValue(HouseObj, null) == null)
                    {
                        property.SetValue(HouseObj, true, null);
                    }
                }

                Console.WriteLine("Name: " + property.Name + ", Value: " + property.GetValue(HouseObj, null));
            }

            if (HouseObj.agencyCosts == null)
            {
                HouseObj.agencyCosts = 0;
            }
            return HouseObj;
        }
        #endregion
    }
}
