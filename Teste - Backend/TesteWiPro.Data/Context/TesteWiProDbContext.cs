using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteWiPro.Business.Models;

namespace TesteWiPro.Data.Context
{
    public class TesteWiProDbContext: DbContext
    {
        public TesteWiProDbContext(DbContextOptions<TesteWiProDbContext> options) : base(options) { }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Aluguel> Alugueis { get; set; }

        protected override void OnModelCreating(ModelBuilder builder){}
    }
}
