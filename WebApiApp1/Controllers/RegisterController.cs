using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiApp1.Models;

namespace WebApiApp1.Controllers
{
    [EnableCors("*", "*", "*")]
    public class RegisterController : ApiController
    {
        RegistrationDAL objRegister = new RegistrationDAL();

        [HttpGet]
        [Route("api/Register/Index")]   //URL
        public IEnumerable<Registration> Index()
        {
            return objRegister.GetAllUsers();

            //return objemployee.GetAllEmployees();
            //IEnumerable<Employee> sequenceOfFoos = objemployee.GetAllEmployees();

            //var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            //string outputOfFoos = serializer.Serialize(sequenceOfFoos);
            //return Json(serializer);
        }

        [HttpPost]
        [Route("api/Register/Create")]
        public int Create(Registration Register)
        {
            return objRegister.AddUser(Register);
        }





    }
}
