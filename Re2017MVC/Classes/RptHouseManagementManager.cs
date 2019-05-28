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


        public List<HouseReportDTO> GetReportsForHouses(string IdHouse)
        {

            List<HouseReportDTO> LstRpt = new List<HouseReportDTO>();
            LstRpt = GetAsyncReportsForHouses("houses/" + IdHouse + "/reports").Result;

            //mapping su DTO
            List<HouseReportDTO> LstHouseReportDTO2 = new List<HouseReportDTO>();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HouseReportDTO, HouseReportDTO>()
                .ForMember(dest => dest.reportUrl, opt => opt.MapFrom(src => Utility.ReadSetting("Re2017ApiUrl") +  src.reportUrl));
            });



            IMapper mapper = config.CreateMapper();
            LstHouseReportDTO2 = mapper.Map<List<HouseReportDTO>, List<HouseReportDTO>>(LstRpt);

            return LstHouseReportDTO2;

            //return LstRpt;


        }

        async Task<List<HouseReportDTO>> GetAsyncReportsForHouses(string path)
        {
            List<HouseReportDTO> Lst = null;
            //todo: security passaggio token a riccardo
            //--------------------------
            //var tk = System.Web.HttpContext.Current.Session["jwt"].ToString() ;
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tk);
            //--------------------------
            //client.DefaultRequestHeaders.Add("token", "klkfjglfd");
            //*****************
            //var jwt = JsonWebToken.Encode(token, APISECRET, JwtHashAlgorithm.HS256);
            //var tk = GetTokenFromApi(); // basically returns an encrypted string.
           
           
            //request.Headers.Set("Authorization", string.Format("Bearer {0}", tk));
            //var authenticationHeaderValue = new AuthenticationHeaderValue("Bearer", tk);
            //******************

            HttpResponseMessage response = await client.GetAsync(path, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                Lst = await response.Content.ReadAsAsync<List<HouseReportDTO>>();
            }

            //Utility.ReadSetting("Re2017ApiUrl")
            return Lst;
        }

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