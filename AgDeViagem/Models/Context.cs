using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgDeViagem.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Contato> contatos { get; set; }
        public DbSet<Passagem> passagens { get; set; }
        public DbSet<Promoção> promoções { get; set; }
    }
}
