using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ls.Prj.DTO;
using Re2017MVC.Models.Shared;

namespace Re2017MVC.Models.Houses
{
    public class IndexViewModel: BaseViewModel
    {
        public IndexViewModel()
        {

        }
       // public List<Re2017MVC.House> LstHouses;
        public List<UsaHouseDTO> LstHouses;
        //public Re2017MVC.House House;
        public UsaHouseDTO HouseDTO;
        public Ls.Prj.Entity.House House;
        public List<SelectListItem> LstYesNo;
        public List<HouseReportDTO> ReportsUrl;
    }
}