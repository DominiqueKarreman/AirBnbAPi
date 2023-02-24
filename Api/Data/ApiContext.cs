using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api.Model;
using MVC.Models;
using Api.Models;

namespace Api.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext (DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<Api.Model.Student> Student { get; set; } = default!;

        public DbSet<Api.Models.Landlord> Landlord { get; set; }

        public DbSet<Api.Models.Customer> Customer { get; set; }

        public DbSet<Api.Models.Property> Property { get; set; }
    }
}
