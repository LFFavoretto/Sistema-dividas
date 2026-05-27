using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SistemaDividasConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDividasConsole.Data
{
    public class SistemaDbContext : DbContext
    {
        public DbSet<Divida> Dividas => Set<Divida>();
        public DbSet<Cliente> Clientes => Set<Cliente>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Development.json")
                .Build();

            var connectionString = builder.GetConnectionString("Default");

            optionsBuilder.UseMySQL(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCliente = modelBuilder.Entity<Cliente>();
            modelCliente.ToTable("clientes");
            modelCliente.Property(e => e.Id).HasColumnName("id");
            modelCliente.Property(e => e.Nome).HasColumnName("nome");
            modelCliente.Property(e => e.Cpf).HasColumnName("cpf");
            modelCliente.Property(e => e.DataNascimento).HasColumnName("data_nascimento");
            modelCliente.Property(e => e.Email).HasColumnName("email");
            modelCliente.HasKey(e => e.Id);

            var modelDivida = modelBuilder.Entity<Divida>();
            modelDivida.ToTable("dividas");
            modelDivida.Property(e => e.Id).HasColumnName("id");
            modelDivida.Property(e => e.Valor).HasColumnName("valor");
            modelDivida.Property(e => e.Pago).HasColumnName("pago");
            modelDivida.Property(e => e.DataCriacao).HasColumnName("data_criacao");
            modelDivida.Property(e => e.DataPagamento).HasColumnName("data_pagamento");
            modelDivida.HasOne(e => e.Cliente).WithMany(c => c.Dividas).HasForeignKey(e => e.ClienteId);
            modelDivida.Property(e => e.ClienteId).HasColumnName("id_cliente");
            modelDivida.HasKey(e => e.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
