using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Data.Entities;

namespace TestApplication.Data.Context
{
    public class TestDBContext : DbContext 
    {
        public TestDBContext()
            : base("name=DefaultConnection")
        {
        }
        public virtual DbSet<DevTest> DevTests { get; set; }
    }
}
