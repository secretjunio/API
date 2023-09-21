﻿using Microsoft.EntityFrameworkCore;
using WebApi.Insfracstructure.Entities;

namespace WebApi.Insfracstructure.DBContext
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options)
       : base(options)
        {
        }

        public DbSet<WeatherForecast> Weathers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
    }
}
