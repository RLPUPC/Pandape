using Microsoft.Extensions.Configuration;
using Pandape.Infrastructure.Database.TypeConfigurations;
using Pandape.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandape.Application.Tests;

[SetUpFixture]
public class SetUp
{
    [OneTimeSetUp]
    public void RunBeforeAnyTest() 
    {
        string? dbConnectionString = OurServiceLocator.ConfigurationRoot.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(dbConnectionString))
            throw new ArgumentNullException(nameof(dbConnectionString));
        var entities = new IEntityConfiguration[]
        {
            new CandidateConfiguration(),
            new CandidateExperienceConfiguration()
        };
        var pandapeContext = new PandapeDbContext(dbConnectionString, entities);
        pandapeContext.Database.EnsureCreated();
    }
}
