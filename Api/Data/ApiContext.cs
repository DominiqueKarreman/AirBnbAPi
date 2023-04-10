using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api.Model;
using MVC.Models;
using Api.Model;

namespace Api.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext (DbContextOptions<ApiContext> options)
            : base(options)
        {
        }



        public DbSet<Api.Model.Landlord> Landlord { get; set; }

        public DbSet<Api.Model.Customer> Customer { get; set; }
        public DbSet<Api.Model.Reservation> Reservation { get; set; }

        public DbSet<Api.Model.Location> Location { get; set; }
        public DbSet<Api.Model.Image> Image { get; set; }
    }
}
