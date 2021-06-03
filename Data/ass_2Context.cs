using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ass_2.Models;

    public class ass_2Context : DbContext
    {
        public ass_2Context (DbContextOptions<ass_2Context> options)
            : base(options)
        {
        }

        public DbSet<ass_2.Models.Product> Product { get; set; }
    }
