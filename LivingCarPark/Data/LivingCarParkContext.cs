using LivingCarPark.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivingCarPark.Data
{
    public class LivingCarParkContext : IdentityDbContext<CarParkUser>
    {
        //public LivingCarParkContext DBContext;
        public LivingCarParkContext(DbContextOptions<LivingCarParkContext> options): base(options)
        {
            //DBContext = new LivingCarParkContext(options);
        }
        public DbSet<CarParkUser> Users { get; set; }
        public DbSet<Carpark> Carparks { get; set; }

    }
}
