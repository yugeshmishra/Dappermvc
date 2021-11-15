using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DapperMVCCRUD.Models
{
    public class EmployeeModel
    {
        public int Empid { get; set; }

        public string Empname { get; set; }

        public int salary { get; set; }

        public string Email { get; set; }

        public string connectionstring { get; set; }

    }
}