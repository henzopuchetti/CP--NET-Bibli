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
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "Biblioteca.Api");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var builder = new DbContextOptionsBuilder<BibliotecaDbContext>();

            var connectionString = configuration.GetConnectionString("OracleDb");

            builder.UseOracle(connectionString);

            return new BibliotecaDbContext(builder.Options);
        }
    }
}
