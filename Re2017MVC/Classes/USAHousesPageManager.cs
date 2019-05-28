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
     public  class UsaHousesPageManager
    {

         HttpClient client = new HttpClient();

       public UsaHousesPageManager()
        {
            client.BaseAddress = new Uri(Utility.ReadSetting("Re2017ApiUrl"));
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        #region UsaHouses


       

        public List<UsaHouseDTO> GetUSAHouses(string IdUser)
        {

            List<House> LstUSAHouses = new List<House>();

            if (IdUser=="")
                {
                LstUSAHouses = GetAsyncUSAHouses("houses").Result;
                }
            else
                {
                LstUSAHouses = GetAsyncUSAHouses("houses?userId=" + IdUser).Result;
            }

          

            //mapping su DTO
            List<UsaHouseDTO> LstUSAHousesDTO = new List<UsaHouseDTO>();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Utente, UserDTO>()
                .ForMember(dest => dest.enabled, opt => opt.MapFrom(src => (((bool)src.active) ? "YES" : "NO")));
            });



            IMapper mapper = config.CreateMapper();
            LstUSAHousesDTO = mapper.Map<List<House>, List<UsaHouseDTO>>(LstUSAHouses);

            return LstUSAHousesDTO;


        }

        async Task<List<House>> GetAsyncUSAHouses(string path)
        {
            List<House> Lst = null;
            HttpResponseMessage response = await client.GetAsync(path, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                Lst = await response.Content.ReadAsAsync<List<House>>();
            }
            return Lst;
        }

        public UsaHouseDTO GetUsaHouseDTO(int Id)
        {

            House ObjHouse = null;

            ObjHouse = GetAsyncUsaHouse("houses/" + Id.ToString()).Result;


            //mapping su DTO
            UsaHouseDTO ObjUsaHouseDTO = new UsaHouseDTO();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<House, UsaHouseDTO>()
             //.ForMember(dest => dest.enabled, opt => opt.MapFrom(src => (((bool)src.disabled) ? "NO" : "YES")));
                .ForMember(dest => dest.country, opt => opt.MapFrom(src => src.country));
            });

            IMapper mapper = config.CreateMapper();
            ObjUsaHouseDTO = mapper.Map<House, UsaHouseDTO>(ObjHouse);

            return ObjUsaHouseDTO;

        }

        public House GetUsaHouse(int Id)
        {

            House ObjHouse = null;

            ObjHouse = GetAsyncUsaHouse("houses/" + Id.ToString()).Result;
            return ObjHouse;

        }

        public async Task<House> GetAsyncUsaHouse(string path)
        {
            House Obj = null;
            HttpResponseMessage response = await client.GetAsync(path, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                Obj = await response.Content.ReadAsAsync<House>();
            }
            return Obj;
        }

        public House NewUsaHouse(House ObjTemplate)
        {

            string str = GetAsyncNewUsaHouse("houses", ObjTemplate).Result;
            House ObjTemplate2 = JsonConvert.DeserializeObject<House>(str);
            return ObjTemplate2;

        }

        public async Task<string> GetAsyncNewUsaHouse(string path, House ObjHouse)
        {

            var myContent = JsonConvert.SerializeObject(ObjHouse);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = client.PostAsync(path, byteContent);
            return await response.Result.Content.ReadAsStringAsync();

        }

        public void UpdateUsaHouse(House ObjHouse)
        {

            var myContent = JsonConvert.SerializeObject(ObjHouse);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = client.PutAsync("houses/" + ObjHouse.id, byteContent).Result;
        }

        #endregion



        #region House
        //public List<HouseDTO> GetHouse()
        //{

        //    //client.BaseAddress = new Uri(Utility.ReadSetting("Re2017ApiUrl"));
        //    //client.DefaultRequestHeaders.Accept.Clear();
        //    //client.DefaultRequestHeaders.Accept.Add(
        //    //    new MediaTypeWithQualityHeaderValue("application/json"));
        //    List<HouseDTO> LstHouse = new List<HouseDTO>();

        //    LstHouse = GetAsyncHouse("houses/names").Result;

        //    return LstHouse;
        //}
        //async Task<List<HouseDTO>> GetAsyncHouse(string path)
        //{
        //    List<HouseDTO> Lst = null;


        //    HttpResponseMessage response = await client.GetAsync(path, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        Lst = await response.Content.ReadAsAsync<List<HouseDTO>>();
        //    }
        //    return Lst;
        //}

        //public void UpdateHouseEvt(UpdateHouseEvtInputDto ObjUpdateHouseEvtInputDto)
        //{

        //    var myContent = JsonConvert.SerializeObject(ObjUpdateHouseEvtInputDto);
        //    var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
        //    var byteContent = new ByteArrayContent(buffer);
        //    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        //    var result = client.PutAsync("events/" + ObjUpdateHouseEvtInputDto.id, byteContent).Result;
        //}

        #endregion

    }
}