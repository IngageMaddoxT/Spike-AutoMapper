using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.Web.Script.Serialization;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TestMapping();

            var cr = new Models.Crossroads.PersonalInfo();
            cr.Email = "tony.maddox@aol.com";
            cr.FirstName = "Tony";

            var dictionary = cr.ToDictionary();

            return View();
        }

        private void TestMapping()
        {
            var inputFromMp = new Dictionary<string, object>();
            inputFromMp.Add("Contact_Id", 12345);
            inputFromMp.Add("Email_Address", "tony.maddox@aol.com");
            inputFromMp.Add("First_Name", "Tony");
            inputFromMp.Add("Last_Name", "Maddox");
            inputFromMp.Add("Marital_Status_ID", 2);

            //Map dictionary into MP object
            var serializer = new JavaScriptSerializer();
            var contact = serializer.Deserialize<Models.MinistryPlatform.Contact>(serializer.Serialize(inputFromMp));

            //Map MP object to Crossroads Object
            Mapper.CreateMap<Models.MinistryPlatform.Contact, Models.Crossroads.PersonalInfo>()
                .ForMember(m=> m.ContactId, m=>m.MapFrom(s=>s.Contact_Id))
                .ForMember(m => m.Email, m => m.MapFrom(s => s.Email_Address))
                .ForMember(m => m.FirstName, m => m.MapFrom(s => s.First_Name))
                .ForMember(m => m.LastName, m => m.MapFrom(s => s.Last_Name))
                .ForMember(m => m.MaritalStatusId, m => m.MapFrom(s => s.Marital_Status_Id));
            var crdsPersonalInfo = Mapper.Map<Models.Crossroads.PersonalInfo>(contact);

            //transform Crossroads object to dictionary for POST
            var outputToMpPost = crdsPersonalInfo.ToDictionary();

            var stop = 0;

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}