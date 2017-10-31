using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using Econom_Sudno.Models;

namespace Econom_Sudno.Context
{
    class UserContext : DbContext
    {
        public UserContext()
            : base("DefaultConnection")
        {
 
        }
    public DbSet<User> Users { get; set; }
    public DbSet<UserApplication> UserApplications { get; set; }
    public DbSet<ShipTemplate> ShipTemplates { get; set; }
    }
}
