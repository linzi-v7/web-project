using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sampleproject.Models
{
    public class MyContext:DbContext
    {
        public MyContext(){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=WEBPROJECT;Integrated Security=True;");
        }


        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> departments { get; set; }
    }
}
