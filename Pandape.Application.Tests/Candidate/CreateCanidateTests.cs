using Pandape.Domain;
using PandapeWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandape.Application.Tests.Candidate
{
    [TestFixture]
    public class CreateCanidateTests: BaseCandidateManagerTest
    {
        private DateTime dt;

        [SetUp]
        public void SetUp() 
        {
            dt = new DateTime(2024, 07, 07, 10, 00, 00);
            BaseSetUp();
            ClearCandidateDDBB();
            _clockManager.SetCurrentUtc(new DateTime(2024, 07, 07, 10, 00, 00));
        }

        [TearDown]
        public void TearDown() 
        {
            ClearCandidateDDBB();
        }

        [Test]
        public void CreateCanidateOk() 
        {
            var newCandidate = new CreateCanditeViewModel
            {
                Name = "Candi1",
                Surname = "SurnameCandi1",
                Email = "Candi1@Candi1.com",
                Birthdate = new DateTime(2000, 01, 01)
            };
            var candidate = _candidateManager.CreateCandidate(newCandidate);
            var candidateExpected = new CandidateDto
            {
                IdCandidate = candidate.IdCandidate,
                Name = "Candi1",
                Surname = "SurnameCandi1",
                Email = "Candi1@Candi1.com",
                Birthdate = new DateTime(2000, 01, 01),
                InsertDate = dt
            };
            Assert.That(candidateExpected, Is.EqualTo(candidate));
        }

        [Test]
        public void CreateCanidateSameMail()
        {
            var newCandidate = new CreateCanditeViewModel
            {
                Name = "Candi1",
                Surname = "SurnameCandi1",
                Email = "Candi1@Candi1.com",
                Birthdate = new DateTime(2000, 01, 01)
            };
            var error = Assert.Throws<Exception>(() => _candidateManager.CreateCandidate(newCandidate));
            Assert.That(error.Message, Is.EqualTo("Already Exists email"));
        }

        [Test]
        public void CreateCanidateOkDDBB()
        {
            var newCandidate = new CreateCanditeViewModel
            {
                Name = "Candi1",
                Surname = "SurnameCandi1",
                Email = "Candi1@Candi1.com",
                Birthdate = new DateTime(2000, 01, 01)
            };
            var candidate = _candidateManager.CreateCandidate(newCandidate);
            using(var toCheck = OurServiceLocator.GetUnitOfWork()) 
            {
                var canidate = toCheck.Cadidates.GetAll().FirstOrDefault(x => x.Email == "Candi1@Candi1.com");
                
            }
        }
    }
}
