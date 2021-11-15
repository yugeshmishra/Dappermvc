using Dapper;
using DapperMVCCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DapperMVCCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View(DapperORM.ReturnList<EmployeeModel>("EmployeeViewAll"));
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id=0)
        {
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Empid", id);
                return View(DapperORM.ReturnList<EmployeeModel>("EmployeeViewByID",param).FirstOrDefault<EmployeeModel>());
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(EmployeeModel emp)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Empid", emp.Empid);
            param.Add("@Empname", emp.Empname);
            param.Add("@salary", emp.salary);
            param.Add("@Email", emp.Email);
            DapperORM.ExecuteWithoutReturn("EmployeeAddOrEdit", param);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Empid", id);
            DapperORM.ExecuteWithoutReturn("EmployeeDeleteByID", param);
            return RedirectToAction("Index");

        }
        
    }
}