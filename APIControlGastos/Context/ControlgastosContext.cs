using APIControlGastos.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace APIControlGastos.Context
{
    public class ControlgastosContext : DbContext
    {
        public ControlgastosContext(DbContextOptions<ControlgastosContext> options)
            : base(options)
        {
        }

        public DbSet<Cobro> Cobros { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
    }
}
