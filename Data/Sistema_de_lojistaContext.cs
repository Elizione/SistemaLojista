using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sistema_de_lojista.Models;

    public class Sistema_de_lojistaContext : DbContext
    {
        public Sistema_de_lojistaContext (DbContextOptions<Sistema_de_lojistaContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; } = default!;
    }
