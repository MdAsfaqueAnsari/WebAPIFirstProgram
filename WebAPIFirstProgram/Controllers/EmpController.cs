using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIFirstProgram.DB_Contex;
using WebAPIFirstProgram.Models;

namespace WebAPIFirstProgram.Controllers
{
    public class EmpController : ApiController
    {
        [HttpGet]
        [Route("Emp/GetEmployee")]
        public List<tbl_Employee> GetEmp()
        {
            List<EmployeeModel> ListEmp = new List<EmployeeModel>();  

            EmployeeEntities1 objlist = new EmployeeEntities1();

            var res = objlist.tbl_Employee.ToList();

            return res;
        }

        [HttpPost]
        [Route("Emp/SaveEmployee")]
        public HttpResponseMessage SaveEmp(tbl_Employee obj)
        {
            EmployeeEntities1 Dbcon=new EmployeeEntities1();

            tbl_Employee tblEmp= new tbl_Employee();

            if (obj.Id == 0)
            {
                Dbcon.tbl_Employee.Add(obj);
                Dbcon.SaveChanges();
            }
            else
            {
                Dbcon.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                Dbcon.SaveChanges();
            }

            HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
            return res;
        }
    }
}