using Pandape.Domain.Dto;

namespace Pandape.Application.CandidateExperienceTests;

[TestFixture]
public class CreateExperienceTests: BaseCandidateExtensionManagerTests
{
    private DateTime dt;
    private int idCandidate;

    [SetUp]
    public void SetUp() 
    {
        ClearCandidateDDBB();
        dt = new DateTime(2022,08,08);
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
    public void CreateExperienceOk() 
    {
        var idNewExperience = new CreateCandidateExperienceVO
        {
            Company = "mar",
            Job = "Job",
            Description = "description",
            Salary = (decimal)12.5,
            BeginDate = new DateTime(2024, 01, 01),
        };
        var experience = _experiencesManager.CreateExperience(idCandidate, idNewExperience);
        var experienceExpected = new ExperienceDto
        {
            IdCandidateExperience = experience.IdCandidateExperience,
            IdCandidate = idCandidate,
            Company = "mar",
            Job = "Job",
            Description= "description",
            Salary = (decimal)12.5,
            BeginDate = new DateTime(2024, 01, 01),
            InsertDate = dt
        };
        Assert.That(experienceExpected, Is.EqualTo(experience));
    }

    [Test]
    public void CreateExperienceOkDDBB()
    {
        var idNewExperience = new CreateCandidateExperienceVO
        {
            Company = "mar",
            Job = "Job",
            Description = "description",
            Salary = (decimal)12.5,
            BeginDate = new DateTime(2024, 01, 01),
        };
        var experience = _experiencesManager.CreateExperience(idCandidate, idNewExperience);
        using(var toCheck = OurServiceLocator.GetUnitOfWork()) 
        {
            var experienceChekc = toCheck.CadidateExperiences.GetById(experience.IdCandidate);
            Assert.IsNotNull(experienceChekc);
        }
    }

    [Test]
    public void CreateExperienceUserNotFound()
    {
        var idNewExperience = new CreateCandidateExperienceVO
        {
            Company = "mar",
            Job = "Job",
            Description = "description",
            Salary = (decimal)12.5,
            BeginDate = new DateTime(2024, 01, 01),
        };
        Assert.Throws<Exception>(() => _experiencesManager.CreateExperience(0, idNewExperience));
    }

    [Test]
    public void CreateExperienceValidate()
    {
        var idNewExperience = new CreateCandidateExperienceVO
        {
            Job = "Job",
            Description = "description",
            Salary = (decimal)12.5,
            BeginDate = new DateTime(2024, 01, 01),
        };
        Assert.Throws<ArgumentNullException>(() => _experiencesManager.CreateExperience(idCandidate, idNewExperience));
    }
}
