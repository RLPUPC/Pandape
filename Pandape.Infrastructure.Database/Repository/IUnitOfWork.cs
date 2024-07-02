using Pandape.Infrastructure.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandape.Infrastructure.Database.Repository
{
    public interface IUnitOfWork: IDisposable
    {
        public void Commit();
        public void Rollback();
        IRepository<Candidate> Cadidates { get; }
        IRepository<CandidateExperience> CadidateExperiences { get; }
    }
}
