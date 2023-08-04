using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    [BindProperties]
    public class User
    {
        [Required]
        [Key]
        public short EmpID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public byte Role { get; set; }

        public bool isDelete { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime CreatedDt { get; set; }
    }
}
