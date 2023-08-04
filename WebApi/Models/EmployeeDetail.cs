using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class EmployeeDetail
    {
        [Key]
        public short EmpID { get; set; }
        public string EmpName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
    }
}
