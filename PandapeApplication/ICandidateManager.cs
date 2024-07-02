using Pandape.Domain;
using Pandape.Infrastructure.Domain.Dto;
using PandapeWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandape.Application
{
    public interface ICandidateManager
    {
        CandidateDto CreateCandidate(CreateCanditeViewModel newCandidate);
        CandidateDto UpdateCandidate();
        void DeleteCandidate(Candidate candidate);
    }
}
