using Microsoft.EntityFrameworkCore;
using Pandape.Infrastructure.Database.TypeConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandape.Infrastructure.Database;

public class PandapeDbContext: DbContext
{
    public string? _connectionString;
    public IEnumerable<IEntityConfiguration> _entityConfigurations;

    public PandapeDbContext(DbContextOptions<PandapeDbContext> options, IEnumerable<IEntityConfiguration> entityConfigurations) : base(options)
    {
        _entityConfigurations = entityConfigurations;
    }

    public PandapeDbContext(string connectionString, IEnumerable<IEntityConfiguration> entityConfigurations)
    {
        _connectionString = connectionString;
        _entityConfigurations = entityConfigurations;
        _entityConfigurations = entityConfigurations;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entityConfiguration in _entityConfigurations) 
        {
            entityConfiguration.AddConfiguration(modelBuilder);   
        }
    }
}
