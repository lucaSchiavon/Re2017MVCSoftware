using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Re2017MVC.Models.RptHouseManagement;
using Re2017MVC.Models.Shared;
using Re2017.Classes;
using Ls.Prj.DTO;
using System.Globalization;

namespace Re2017MVC.Controllers
{
    public class RptHouseManagementController : BaseController
    {
        // GET: RptHouseManagement
        public ActionResult Index()
        {
        //    var vm = new IndexViewModel();
        //    vm.UtenteCorrente = LoginUsr;
        //    vm.HeaderVM = new HeaderViewModel
        //    {
        //        UtenteCorrente = vm.UtenteCorrente,
        //        LateralMenuVM = new LateralMenuViewModel()
                
        //};

        //    //recupero dati...
        //    TrackManagement2PageManager ObjTrackManagement2PageManager = new TrackManagement2PageManager();
        //    List<HouseDTO> LstHouses=  ObjTrackManagement2PageManager.GetHouse();
        //    vm.LstHouses = LstHouses;
        //    //List<string> LstYears = new List<string>() {"2017","2018" };
        //    List<SelectListItem> LstYears = new List<SelectListItem>();
        //    //carica da 2017 all'anno attuale e mette selezionato l'anno corrente

        //    LstYears.Add(new SelectListItem { Text="2017",Value="2017" });
        //    LstYears.Add(new SelectListItem { Text = "2018", Value = "2018", Selected=true });
        //    //carica tutti i mesi
        //    //List<SelectListItem> LstMonths = new List<SelectListItem>();
        //    //LstMonths.Add(new SelectListItem { Text = "January", Value = "1", Selected = true });
        //    //LstMonths.Add(new SelectListItem { Text = "February", Value = "2" });

           
        //    vm.LstYears = GetLstYearsForCombo();
        //    vm.LstMonths = GetLstMonthsForCombo();
            return View(InitializeIndexView());
           
        }
        public ActionResult GeneraReport(int Id,string Year,string Month,string Note)
        {
            
            RptHouseManagementManager ObjRptHouseManagementManager = new RptHouseManagementManager();
            NewReportInputDto ObjNewReportInputDto = new NewReportInputDto();
            ObjNewReportInputDto.year = Year;
            ObjNewReportInputDto.month = Month;
            ObjNewReportInputDto.notes = Note;
            IndexViewModel vm = InitializeIndexView();
            try
            {
                ObjRptHouseManagementManager.NewReport(ObjNewReportInputDto, Id);
                //throw new Exception("errore colossale");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index","Errore",new { @Errore=ex.Message });
            }
               
           
                //valorizza
             
           

           
           // return View("Index",vm);

        }

        public ActionResult Errore()
        {
            var vm = new IndexViewModel();
            vm.UtenteCorrente = LoginUsr;
            vm.HeaderVM = new HeaderViewModel
            {
                UtenteCorrente = vm.UtenteCorrente,
                LateralMenuVM = new LateralMenuViewModel()

            };
            return View(vm);
        }

            #region "rutine private"
            private IndexViewModel InitializeIndexView()
        {
            var vm = new IndexViewModel();
            vm.UtenteCorrente = LoginUsr;
            vm.HeaderVM = new HeaderViewModel
            {
                UtenteCorrente = vm.UtenteCorrente,
                LateralMenuVM = new LateralMenuViewModel()

            };

            //recupero dati...
            TrackManagement2PageManager ObjTrackManagement2PageManager = new TrackManagement2PageManager();
            List<HouseDTO> LstHouses = ObjTrackManagement2PageManager.GetHouse();
            vm.LstHouses = LstHouses;
            //List<string> LstYears = new List<string>() {"2017","2018" };
            List<SelectListItem> LstYears = new List<SelectListItem>();
            //carica da 2017 all'anno attuale e mette selezionato l'anno corrente

            LstYears.Add(new SelectListItem { Text = "2017", Value = "2017" });
            LstYears.Add(new SelectListItem { Text = "2018", Value = "2018", Selected = true });
            //carica tutti i mesi
            //List<SelectListItem> LstMonths = new List<SelectListItem>();
            //LstMonths.Add(new SelectListItem { Text = "January", Value = "1", Selected = true });
            //LstMonths.Add(new SelectListItem { Text = "February", Value = "2" });


            vm.LstYears = GetLstYearsForCombo();
            vm.LstMonths = GetLstMonthsForCombo();
            return vm;
        }
        private List<SelectListItem> GetLstYearsForCombo()
        {
            List<SelectListItem> LstYears = new List<SelectListItem>();
            int Anno = 2012;
            do
            {

                if (DateTime.Now.Year == Anno)
                {
                    LstYears.Add(new SelectListItem { Text = Anno.ToString(), Value = Anno.ToString(), Selected = true });
                }
                else
                {
                    LstYears.Add(new SelectListItem { Text = Anno.ToString(), Value = Anno.ToString() });
                }
                   
                Anno += 1;
            } while (DateTime.Now.Year != Anno - 1);


            return LstYears;
        }
        private List<SelectListItem> GetLstMonthsForCombo()
        {
            List<SelectListItem> LstMonths = new List<SelectListItem>();
            for (int i = 1; i < 13; i++)
            {
                string fullMonthName = new DateTime(2015, i, 1).ToString("MMMM", CultureInfo.CreateSpecificCulture("en"));

                if (DateTime.Now.Month == i)
                {
                    //si tratta del mese corrente
                    LstMonths.Add(new SelectListItem { Text = fullMonthName, Value = i.ToString(), Selected = true });
                }
                else
                {
                    LstMonths.Add(new SelectListItem { Text = fullMonthName, Value = i.ToString() });
                }

            }

            return LstMonths;
        }
        #endregion

    }
}