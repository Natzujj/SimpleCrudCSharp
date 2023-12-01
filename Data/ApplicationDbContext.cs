using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MeuCrudCSharp.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuCrudCSharp.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Item> Items { get; set; }
    }
 
}