using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ls.Prj.Entity;
using System.Data.SqlClient;
using AutoMapper;
using Ls.Prj.DTO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Ls.Prj.Utility;
using Newtonsoft.Json;
using System.Globalization;


namespace Re2017.Classes
{
     public  class RptHouseManagementManager
    {


         HttpClient client = new HttpClient();

       public RptHouseManagementManager()
        {
            client.BaseAddress = new Uri(Utility.ReadSetting("Re2017ApiUrl"));
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

      

        #region Reports


       

        public void NewReport(NewReportInputDto ObjNewReportInputDto, int IdHouse)
        {

            var myContent = JsonConvert.SerializeObject(ObjNewReportInputDto);
            //var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var buffer = System.Text.Encoding.UTF8.GetBytes(ObjNewReportInputDto.notes);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            ///houses/{houseId}/reports/years/{year}/months/{month}
            var result = client.PostAsync("houses/" + IdHouse + "/reports/years/" + ObjNewReportInputDto.year + "/months/" + ObjNewReportInputDto.month, byteContent).Result;
            if (!result.IsSuccessStatusCode)
            {
                throw new Exception("An error occurred during creation of the report.");
            }
        }

        #endregion

       
    }
}