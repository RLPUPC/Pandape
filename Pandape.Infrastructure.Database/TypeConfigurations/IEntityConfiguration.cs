using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandape.Infrastructure.Database.TypeConfigurations
{
    public interface IEntityConfiguration
    {
        void AddConfiguration(ModelBuilder modelBuilder);
    }
}
