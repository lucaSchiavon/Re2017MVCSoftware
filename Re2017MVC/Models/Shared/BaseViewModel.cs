using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ls.Prj.DTO;

namespace Re2017MVC.Models.Shared
{
    public class BaseViewModel
    {
        public UserDTO UtenteCorrente;
        public HeaderViewModel HeaderVM { get; set; }
       
    }
}