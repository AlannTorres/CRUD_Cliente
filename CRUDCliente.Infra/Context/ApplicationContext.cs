using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDCliente.Domain.Entidades;

namespace CRUDCliente.Infra.Context;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions options) : base(options) {}

    public DbSet<Cliente> Clientes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cliente>(c =>
        {
            c.HasKey(p => p.Id);
            c.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            c.Property(p => p.Cpf).HasMaxLength(11).IsRequired();
            c.Property(p => p.Telefone).HasMaxLength(20).IsRequired();
        });
    }
}
