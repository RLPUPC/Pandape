using Pandape.Domain.Dto;

namespace Pandape.Application.CandidateTests;

[TestFixture]
public class UpdateCandidateTests: BaseCandidateManagerTest
{
    private DateTime dt;

    [SetUp]
    public void SetUp() 
    {
        dt = new DateTime(2022, 08, 08);
        BaseSetUp();
        _clockManager.SetCurrentUtc(dt);
    }

    [TearDown]
    public void TearDown() 
    {
        ClearCandidateDDBB();
    }

    [Test]
    public void UpdateCandidateOkEmail()
    {
        var idUpdate = CreateCandidate("Candi1", "SurnameCandi1", new DateTime(2000, 01, 30), "Candi1@Candi1.com", dt.AddDays(-1));
        var updateCandidate = new UpdateCandidateVO
        {
            Email = "Candi2@Candi1.com",
            Birthdate = new DateTime(2000, 01, 30)
        };
        var candidate = _candidateManager.UpdateCandidate(idUpdate,updateCandidate);
        var candidateExpected = new CandidateDto
        {
            IdCandidate = candidate.IdCandidate,
            Name = "Candi1",
            Surname = "SurnameCandi1",
            Email = "Candi2@Candi1.com",
            Birthdate = new DateTime(2000, 01, 30),
            InsertDate = dt.AddDays(-1),
            ModifyDate = dt

        };
        Assert.That(candidateExpected, Is.EqualTo(candidate));
    }

    [Test]
    public void UpdateCandidateOkBirthdate()
    {
        var idUpdate = CreateCandidate("Candi1", "SurnameCandi1", new DateTime(2000, 01, 30), "Candi1@Candi1.com", dt.AddDays(-1));
        var updateCandidate = new UpdateCandidateVO
        {
            Email = "Candi1@Candi1.com",
            Birthdate = new DateTime(1999, 01, 30)
        };
        var candidate = _candidateManager.UpdateCandidate(idUpdate, updateCandidate);
        var candidateExpected = new CandidateDto
        {
            IdCandidate = candidate.IdCandidate,
            Name = "Candi1",
            Surname = "SurnameCandi1",
            Email = "Candi1@Candi1.com",
            Birthdate = new DateTime(1999, 01, 30),
            InsertDate = dt.AddDays(-1),
            ModifyDate = dt
        };
        Assert.That(candidateExpected, Is.EqualTo(candidate));
    }

    [Test]
    public void UpdateCandidateOkModifydate()
    {
        var idUpdate = CreateCandidate("Candi1", "SurnameCandi1", new DateTime(2000, 01, 30), "Candi1@Candi1.com", dt.AddDays(-2),dt.AddDays(-1));
        var updateCandidate = new UpdateCandidateVO
        {
            Email = "Candi2@Candi1.com",
            Birthdate = new DateTime(1999, 01, 30)
        };
        var candidate = _candidateManager.UpdateCandidate(idUpdate, updateCandidate);
        var candidateExpected = new CandidateDto
        {
            IdCandidate = idUpdate,
            Name = "Candi1",
            Surname = "SurnameCandi1",
            Email = "Candi2@Candi1.com",
            Birthdate = new DateTime(1999, 01, 30),
            InsertDate = dt.AddDays(-2),
            ModifyDate = dt
        };
        Assert.That(candidateExpected, Is.EqualTo(candidate));
    }

    [Test]
    public void UpdateCandidateOtherCandidateSameMail()
    {
        var updateCandidate = new UpdateCandidateVO
        {
            Email = "Candi4@Candi1.com",
            Birthdate = new DateTime(2000, 01, 30)
        };
        CreateCandidate("name3", "surname3", new DateTime(2000, 01, 30), "Candi4@Candi1.com", dt);
        var idUpdate = CreateCandidate("name", "surname", new DateTime(2000, 01, 30), "Candi1@Candi1.com", dt);
        var error = Assert.Throws<Exception>(() => _candidateManager.UpdateCandidate(idUpdate,updateCandidate));
        Assert.That(error.Message, Is.EqualTo("Email already exists"));
    }

    [Test]
    public void UpdateCandidateOkDDBB()
    {
        var idUpdate = CreateCandidate("Candi1", "SurnameCandi1", new DateTime(2000, 01, 30), "Candi1@Candi1.com", dt.AddDays(-1));
        var updateCandidate = new UpdateCandidateVO
        {
            Email = "email2",
            Birthdate = new DateTime(1999, 01, 30)
        };
        var candidate = _candidateManager.UpdateCandidate(idUpdate, updateCandidate);
        using (var toCheck = OurServiceLocator.GetUnitOfWork())
        {
            var canidate = toCheck.Cadidates.GetAll().FirstOrDefault(x => x.Email == "email2");
            Assert.IsNotNull(canidate);
            Assert.That(canidate.Name, Is.EqualTo("Candi1"));
            Assert.That(canidate.Surname, Is.EqualTo("SurnameCandi1"));
            Assert.That(canidate.Email, Is.EqualTo("email2"));
            Assert.That(canidate.Birthdate, Is.EqualTo(new DateTime(1999, 01, 30)));
            Assert.That(canidate.InsertDate, Is.EqualTo(dt.AddDays(-1)));
            Assert.That(canidate.ModifyDate, Is.EqualTo(dt));
        }
    }

    [Test]
    public void UpdateCandidateNonExists()
    {
        var updateCandidate = new UpdateCandidateVO
        {
            Email = "Candi1@Candi1.com",
            Birthdate = new DateTime(2000, 01, 01)
        };
        var error = Assert.Throws<Exception>(() => _candidateManager.UpdateCandidate(0, updateCandidate));
        Assert.That(error.Message, Is.EqualTo("The candidate does not exists"));
    }

    [Test]
    public void UpdateCandidateErrorEmailNull()
    {
        var updateCandidate = new UpdateCandidateVO
        {
            Birthdate = new DateTime(2000, 01, 01)
        };
        Assert.Throws<ArgumentNullException>(() => _candidateManager.UpdateCandidate(0, updateCandidate));
    }
}
