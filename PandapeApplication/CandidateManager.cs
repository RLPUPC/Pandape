using Microsoft.Identity.Client;
using Pandape.Domain;
using Pandape.Infrastructure.Database.Repository;
using Pandape.Infrastructure.Domain.Dto;
using PandapeWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandape.Application
{
    public class CandidateManager: ICandidateManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClockManager _clockManager;

        public CandidateManager(IUnitOfWork unitOfWork, IClockManager clockManager) 
        {
            _unitOfWork = unitOfWork;
            _clockManager = clockManager;
        }

        public CandidateDto CreateCandidate(CreateCanditeViewModel newCandidate)
        {
            throw new NotImplementedException();
        }

        public void DeleteCandidate(Candidate candidate)
        {
            throw new NotImplementedException();
        }

        public CandidateDto UpdateCandidate()
        {
            throw new NotImplementedException();
        }
    }
}
