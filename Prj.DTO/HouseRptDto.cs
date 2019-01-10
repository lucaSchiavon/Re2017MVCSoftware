using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ls.Prj.DTO
{
    //[Serializable]
    public class HouseRptDTO
    {

        public int id { get; set; }
        public string nickname { get; set; }
       
        public string monthToView {
            get {
                if (month != 0)
                {
                    return month.ToString();
                }
                else
                {
                    return "";
                }
            }
          
        }
       
        public string yearToView
        {
            get
            {
                if (year != 0)
                {
                    return year.ToString();
                }
                else
                {
                    return "";
                }
            }

        }

        public string messageToView
        {
            get
            {
                if (month != 0)
                {
                    return "Last generated report ";
                }
                else
                {
                    return "No generated report ";
                }
            }

        }
        public int month { get; set; }
        public int year { get; set; }

    }
}
