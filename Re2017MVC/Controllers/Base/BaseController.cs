using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Re2017.Classes;
using Ls.Prj.DTO;

namespace Re2017MVC.Controllers
{
    public class BaseController : Controller
    {
        #region public propery of controller
        public UserDTO LoginUsr
        {
            get { return GetLoginUser(); }

        }

        #endregion



        #region routine private al controller
        private UserDTO GetLoginUser()
        {
            UserPageManager ObjUserPageManager = new UserPageManager();
            string IdUsr = System.Web.HttpContext.Current.Request.Cookies["IdUser"].Value;
            UserDTO LogUsr = ObjUserPageManager.GetUtente(Convert.ToInt32(IdUsr));
            return LogUsr;
        }


        #endregion
    }
}