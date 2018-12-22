using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ls.Prj.DTO;
using Re2017MVC.Models.Shared;

namespace Re2017MVC.Models.RptHouseManagement
{
    public class IndexViewModel: BaseViewModel
    {
        public IndexViewModel()
        {

        }
        public List<HouseDTO> LstHouses;
        public List<SelectListItem> LstYears;
        public List<SelectListItem> LstMonths;
        public string RptYear;
        public string RptMonth;
    }
}