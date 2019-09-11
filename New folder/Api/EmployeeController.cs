using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using WebApiApp1.Models;

namespace WebApiApp1.Controllers
{
    [EnableCors("*", "*", "*")]
    public class EmployeeController : ApiController
    {
        RegistrationDAL objRegister = new RegistrationDAL();
        EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();

        [HttpGet]
       [Route("api/Employee/Index")]   //URL
        //[Route("api/{employees}")]
        public IEnumerable<Employee> Index()
        {
            return objemployee.GetAllEmployees();
            //IEnumerable<Employee> sequenceOfFoos = objemployee.GetAllEmployees();

            //var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            //string outputOfFoos = serializer.Serialize(sequenceOfFoos);
            //return Json(serializer);
        }
        [HttpPost]
        [Route("api/Employee/Create")]
        public int Create(Employee employee)
        {
            return objemployee.AddEmployee(employee);
        }

        //public int Create(Registration Register)
        //{
        //    return objRegister.AddUser(Register);
        //}

        [HttpGet]
        [Route("api/Employee/Details/{id}")]
        public Employee Details(int id)
        {
            return objemployee.GetEmployeeData(id);
        }
        [HttpPut]
        [Route("api/Employee/Edit")]
        public int Edit(Employee employee)
        {
            return objemployee.UpdateEmployee(employee);
        }
        [HttpDelete]
        [Route("api/Employee/Delete/{id}")]
        public int Delete(int id)
        {
            return objemployee.DeleteEmployee(id);
        }



    }
}
