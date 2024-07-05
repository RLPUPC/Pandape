using Pandape.Domain.Dto;

namespace Pandape.Application.CandidateTests;

[TestFixture]
public class GetCandidatesTests: BaseCandidateManagerTest
{
    private DateTime dt;


    [SetUp]
    public void SetUp() 
    {
        ClearCandidateDDBB();
        dt = new DateTime(2024,08,08);
        BaseSetUp();
        _clockManager.SetCurrentUtc(dt);
    }

    [TearDown]
    public void TearDown() 
    {
        ClearCandidateDDBB();
    }

    [Test]
    public void GetCandidatesOk() 
    {
        int idAnna = CreateCandidate("Anna","A",new DateTime(2000,01,01),"AnnaA@email.com",dt);
        int idRaquel = CreateCandidate("Raquel","Z",new DateTime(2000,01,01),"RaquelZ@email.com",dt);
        int idRaquel2 = CreateCandidate("Raquel","C",new DateTime(2000,01,01),"RaquelC@email.com",dt);
        int idRaul = CreateCandidate("Raul", "D",new DateTime(2000, 01, 01), "RaulD@email.com", dt);
        var candidates = _candidateManager.GetCandidates();
        var candidatesExpected = new CandidateDto[]
        {
            new CandidateDto
            {
                IdCandidate = idAnna,
                Name = "Anna",
                Surname = "A",
                Birthdate = new DateTime(2000,01,01),
                Email = "AnnaA@email.com",
                InsertDate = dt
            },
            new CandidateDto
            {
                IdCandidate = idRaquel2,
                Name = "Raquel",
                Surname = "C",
                Birthdate = new DateTime(2000,01,01),
                Email = "RaquelC@email.com",
                InsertDate = dt
            },
            new CandidateDto
            {
                IdCandidate = idRaquel,
                Name = "Raquel",
                Surname = "Z",
                Birthdate = new DateTime(2000,01,01),
                Email = "RaquelZ@email.com",
                InsertDate = dt
            },
            new CandidateDto
            {
                IdCandidate = idRaul,
                Name = "Raul",
                Surname = "D",
                Birthdate = new DateTime(2000,01,01),
                Email = "RaulD@email.com",
                InsertDate = dt
            },
        };
        Assert.That(candidatesExpected, Is.EquivalentTo(candidates));
    }

    [Test]
    public void GetCandidatesEmptyOk()
    {
        var candidates = _candidateManager.GetCandidates();
        var candidatesExpected = new CandidateDto[]{};
        Assert.That(candidatesExpected, Is.EquivalentTo(candidates));
    }
}
