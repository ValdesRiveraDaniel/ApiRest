using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiRest.Models;

namespace ApiRest.Data
{
    public class ApiRestContext : DbContext
    {
        public ApiRestContext (DbContextOptions<ApiRestContext> options)
            : base(options)
        {
        }

        public DbSet<ApiRest.Models.Coches> Coches { get; set; }
    }
}
