using HR_Manager.Models;
using Microsoft.EntityFrameworkCore;

namespace HR_Manager.Data
{
    public class HR_ManagerContext : DbContext
    {
        public HR_ManagerContext(DbContextOptions<HR_ManagerContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<Business> Business { get; set; }

        public DbSet<Customer> Customer { get; set; }
    }
}