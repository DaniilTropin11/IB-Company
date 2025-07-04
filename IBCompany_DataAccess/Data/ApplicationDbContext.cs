﻿using IBCompany_Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IBCompany_DataAccess.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<ApplicationType> ApplicationType { get; set; }
		public DbSet<Product> Product { get; set; } 
        public DbSet<ApplicationUser> ApplicationUser {  get; set; }

        public DbSet<OrderVM> Orders { get; set; }
    }
}
