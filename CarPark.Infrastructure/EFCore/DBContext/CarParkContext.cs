using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarPark.ApplicationCore.Entities;


namespace CarPark.Infrastructure.EFCore.DBContext
{
    public class CarParkContext : IdentityDbContext<CarParkUser>
    {

        public CarParkContext(DbContextOptions<CarParkContext> options) : base(options)
        {

        }
        public DbSet<CarParkUser> Users { get; set; }
        public DbSet<Carpark> Carparks { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<ApplicationLogin> ApplicationLogins {get;set;}

    }
}
