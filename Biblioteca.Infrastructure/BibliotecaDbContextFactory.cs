using Biblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Biblioteca.Infrastructure
{
    public class BibliotecaDbContextFactory : IDesignTimeDbContextFactory<BibliotecaDbContext>
    {
        public BibliotecaDbContext CreateDbContext(string[] args)
        {
            // Determina o caminho da API de forma relativa ao projeto atual
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "Biblioteca.Api");

            // Carrega appsettings.json da API
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var builder = new DbContextOptionsBuilder<BibliotecaDbContext>();

            // Pega a connection string chamada "OracleDb" do appsettings.json
            var connectionString = configuration.GetConnectionString("OracleDb");

            // Configura o DbContext para usar Oracle
            builder.UseOracle(connectionString);

            return new BibliotecaDbContext(builder.Options);
        }
    }
}
