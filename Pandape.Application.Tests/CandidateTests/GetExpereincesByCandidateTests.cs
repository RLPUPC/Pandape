using Pandape.Domain.Dto;

namespace Pandape.Application.CandidateTests;

[TestFixture]
public class GetExpereincesByCandidateTests : BaseCandidateManagerTest
{
    private DateTime dt;
    private int idCandidate;

    [SetUp]
    public void SetUp()
    {
        dt = new DateTime(2022, 08, 08);
        BaseSetUp();
        _clockManager.SetCurrentUtc(dt);
        idCandidate = CreateCandidate("name", "surname", new DateTime(2000, 01, 30), "Candi1@Candi1.com", dt);
    }

    [TearDown]
    public void TearDown()
    {
        ClearCandidateDDBB();
    }

    [Test]
    public void GetExperiencesByCandidate()
    {
        int idExperience = CreateCandidateExperience(idCandidate, "mar", "montaña", "working", (decimal)22.5, new DateTime(2014, 07, 10), dt);
        int idExperience2 = CreateCandidateExperience(idCandidate, "playa", "montaña", "not working", (decimal)22.5, new DateTime(2014, 07, 10), dt);
        int idExperience3 = CreateCandidateExperience(idCandidate, "leer", "pelicula", "writer", (decimal)22.5, new DateTime(2014, 07, 10), dt, endDate: new DateTime(2015, 07, 10));
        var candidateExperiences = _candidateManager.GetExpereincesByCandidate(idCandidate);
        var CandidateexperiencesExpeted = new CandidateExperienceDto { 
            FullName = "name surname",
            IdCandidate = idCandidate,
            Experiences = new ExperienceDto[]
            {
                new ExperienceDto
                {
                    IdCandidateExperience = idExperience3,
                    IdCandidate = idCandidate,
                    Company = "leer",
                    Job = "pelicula",
                    Description = "writer",
                    Salary = (decimal)22.5,
                    BeginDate = new DateTime(2014, 07, 10),
                    EndDate = new DateTime(2015, 07, 10),
                    InsertDate = dt
                },
                new ExperienceDto
                {
                    IdCandidateExperience = idExperience,
                    IdCandidate = idCandidate,
                    Company = "mar",
                    Job = "montaña",
                    Description = "working",
                    Salary = (decimal)22.5,
                    BeginDate = new DateTime(2014, 07, 10),
                    InsertDate = dt
                },
                new ExperienceDto
                {
                    IdCandidateExperience = idExperience2,
                    IdCandidate = idCandidate,
                    Company = "playa",
                    Job = "montaña",
                    Description = "not working",
                    Salary = (decimal)22.5,
                    BeginDate = new DateTime(2014, 07, 10),
                    InsertDate = dt
                }
            } 
        };
        Assert.That(CandidateexperiencesExpeted, Is.EqualTo(candidateExperiences));
    }

    [Test]
    public void GetExperiencesByCandidateEmpty()
    {
        var experiences = _candidateManager.GetExpereincesByCandidate(idCandidate);
        var experiencesExpeted = new CandidateExperienceDto
        {
            FullName = "name surname",
            IdCandidate = idCandidate,
            Experiences = new ExperienceDto[] { }
        };
        Assert.That(experiencesExpeted, Is.EqualTo(experiences));
    }

    [Test]
    public void GetExperiencesByCandidateNotFound()
    {
        Assert.Throws<Exception>(() => _candidateManager.GetExpereincesByCandidate(0));
    }
}
