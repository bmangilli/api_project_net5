using Microsoft.EntityFrameworkCore;
using System;

namespace ApiClientes.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.CNPJ)
                .IsRequired()
                .HasMaxLength(14);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Endereco)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Telefone)
                .IsRequired()
                .HasMaxLength(13);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.DataCadastro)
                .IsRequired();

            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.CNPJ)
                .IsUnique();

            modelBuilder.Entity<Cliente>()
                .HasData(
                    new Cliente
                    {
                        Id = 1,
                        Nome = "Empresa 1",
                        CNPJ = "12345678901234",
                        Endereco = "Rua 1, 123",
                        Telefone = "5548912345678",
                        DataCadastro = DateTime.Now
                    },
                    new Cliente
                    {
                        Id = 2,
                        Nome = "Empresa 2",
                        CNPJ = "43210987654321",
                        Endereco = "Rua 2, 123",
                        Telefone = "5548987654321",
                        DataCadastro = DateTime.Now
                    }
                );
        }
    }
}
