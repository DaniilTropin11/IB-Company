using IB_Company.Models;
using Microsoft.EntityFrameworkCore;

namespace IB_Company.Data
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options) : base(options) 
        {
                
        }

        public DbSet <Category> Category { get; set; }
    }
}
