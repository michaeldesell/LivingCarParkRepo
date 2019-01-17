using LivingCarPark.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivingCarPark.Data
{
    public class LivingCarParkContext : DbContext
    {

        public LivingCarParkContext(DbContextOptions<LivingCarParkContext> options): base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Carpark> Carparks { get; set; }

    }
}
