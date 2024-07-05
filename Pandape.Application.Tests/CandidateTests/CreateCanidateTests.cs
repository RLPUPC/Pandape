using Pandape.Domain.Dto;
using Pandape.Infrastructure.Domain.Dto;

namespace Pandape.Application.CandidateTests;

[TestFixture]
public class CreateCanidateTests : BaseCandidateManagerTest
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
        var newCandidate = new CreateCandidateVO
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
        var newCandidate = new CreateCandidateVO
        {
            Name = "Candi1",
            Surname = "SurnameCandi1",
            Email = "Candi1@Candi1.com",
            Birthdate = new DateTime(2000, 01, 01)
        };
        CreateCandidate("name", "surname", new DateTime(2000, 01, 30), "Candi1@Candi1.com", dt);
        var error = Assert.Throws<Exception>(() => _candidateManager.CreateCandidate(newCandidate));
        Assert.That(error.Message, Is.EqualTo("Email already exists"));
    }

    [Test]
    public void CreateCanidateOkDDBB()
    {
        var newCandidate = new CreateCandidateVO
        {
            Name = "Candi1",
            Surname = "SurnameCandi1",
            Email = "Candi1@Candi1.com",
            Birthdate = new DateTime(2000, 01, 01)
        };
        var candidate = _candidateManager.CreateCandidate(newCandidate);
        using (var toCheck = OurServiceLocator.GetUnitOfWork())
        {
            var canidate = toCheck.Cadidates.GetAll().FirstOrDefault(x => x.Email == "Candi1@Candi1.com");
            Assert.IsNotNull(canidate);
            Assert.That(canidate.Name, Is.EqualTo("Candi1"));
            Assert.That(canidate.Surname, Is.EqualTo("SurnameCandi1"));
            Assert.That(canidate.Email, Is.EqualTo("Candi1@Candi1.com"));
            Assert.That(canidate.Birthdate, Is.EqualTo(new DateTime(2000, 01, 01)));
            Assert.That(canidate.InsertDate, Is.EqualTo(dt));
        }
    }

    [Test]
    public void CreateCanidateErrorNameNull()
    {
        var newCandidate = new CreateCandidateVO
        {
            Surname = "SurnameCandi1",
            Email = "Candi1@Candi1.com",
            Birthdate = new DateTime(2000, 01, 01)
        };
        Assert.Throws<ArgumentNullException>(() => _candidateManager.CreateCandidate(newCandidate));
    }
}
