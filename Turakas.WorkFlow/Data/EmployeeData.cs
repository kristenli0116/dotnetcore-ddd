using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Models;

namespace Turakas.WorkFlow.Data
{
    public class EmployeeData
    {
        public int EmployeeID { get; set; }

        public string EmployeeName { get; set; }

        public int EmployeeAge { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}