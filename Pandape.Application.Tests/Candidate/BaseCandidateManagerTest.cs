using Pandape.Infrastructure.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandape.Application.Tests.Candidate
{
    public class BaseCandidateManagerTest
    {
        protected CandidateManager _candidateManager = default!;
        protected MockClockManager _clockManager = default!;

        public void BaseSetUp() 
        {
            _clockManager = new MockClockManager();
            _candidateManager = new CandidateManager(OurServiceLocator.GetUnitOfWork(), _clockManager);
        }

        public int CreateCandidate(string name, string surname, DateTime birthDate, string email, DateTime insertDate, DateTime modifyDate) 
        {
            using (var toCreate = OurServiceLocator.GetUnitOfWork())
            {
                var newCandite = new Infrastructure.Domain.Dto.Candidate { Name = name, Surname = surname, Birthdate = birthDate, Email = email, InsertDate = insertDate, ModifyDate = modifyDate };
                newCandite = toCreate.Cadidates.Add(newCandite);
                toCreate.Commit();
                return newCandite.IdCandidate;
            }
        }

        public void ClearCandidateDDBB() 
        {
            using (var toDelete = OurServiceLocator.GetUnitOfWork())
            {
                var candidates = toDelete.Cadidates.GetAll();
                foreach (var candidate in candidates) 
                {
                    toDelete.Cadidates.Delete(candidate);
                }
                toDelete.Commit();
            }
        }

    }
}
