using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class EmployeeDetailContext : DbContext
    {
        public EmployeeDetailContext(DbContextOptions<EmployeeDetailContext> options) : base(options)
        {
        }

        // table or view not use primary key
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>(eb =>
        //    {
        //        eb.HasNoKey();
        //        eb.ToTable("tblUser");
        //    });
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    var foo = modelBuilder.Entity<User>();
        //    foo.Property(f => f.CreatedDt).HasColumnType("smalldatetime");

        //    base.OnModelCreating(modelBuilder);
        //}

        public DbSet<EmployeeDetail> tblEmployee { get; set; }
        public DbSet<User> tblUser { get; set; }

        public void AddUser(User user)
        {
            tblUser.Add(user);
            this.SaveChanges();
            return;
        }
    }
}
