using WebApiApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApiApp1.Controllers
{
    [EnableCors("*", "*", "*")]
    public class RegistrationController : ApiController
	{
		RegistrationDAL objRegister = new RegistrationDAL();


        [HttpGet]
        [Route("api/Registration/Index")]   //URL
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
		[Route("api/Registration/Create")]
		public int Create(Registration Register)
		{
			return objRegister.AddUser(Register);
		}


		//// GET api/<controller>
		//public IEnumerable<string> Get()
		//{
		//	return new string[] { "value1", "value2" };
		//}

		//// GET api/<controller>/5
		//public string Get(int id)
		//{
		//	return "value";
		//}

		//// POST api/<controller>
		//public void Post([FromBody]string value)
		//{
		//}

		//// PUT api/<controller>/5
		//public void Put(int id, [FromBody]string value)
		//{
		//}

		//// DELETE api/<controller>/5
		//public void Delete(int id)
		//{
		//}
	}
}