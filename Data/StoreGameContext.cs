using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using razor_pages_ef.Models;

    public class StoreGameContext : DbContext
    {
        public StoreGameContext (DbContextOptions<StoreGameContext> options)
            : base(options)
        {
        }

        public DbSet<razor_pages_ef.Models.Game> Game { get; set; }
    }
