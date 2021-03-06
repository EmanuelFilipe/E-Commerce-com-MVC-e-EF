using CasaDoCodigo.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>().HasKey(p => p.Id);

            modelBuilder.Entity<Pedido>().HasKey(p => p.Id);
            modelBuilder.Entity<Pedido>().HasMany(p => p.Itens).WithOne(i => i.Pedido);
            modelBuilder.Entity<Pedido>().HasOne(p => p.Cadastro).WithOne(c => c.Pedido).IsRequired();

            modelBuilder.Entity<ItemPedido>().HasKey(ip => ip.Id);
            modelBuilder.Entity<ItemPedido>().HasOne(ip => ip.Pedido);
            modelBuilder.Entity<ItemPedido>().HasOne(ip => ip.Produto);

            modelBuilder.Entity<Cadastro>().HasKey(c => c.Id);
            modelBuilder.Entity<Cadastro>().HasOne(c => c.Pedido);
        }

    }
}
