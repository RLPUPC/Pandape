using Pandape.Domain.Dto;

namespace Pandape.Application.CandidateExperienceTests;

[TestFixture]
public class UpdateExperienceTests: BaseCandidateExtensionManagerTests
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
    public void UpdateExperienceOk() 
    {
        int idExperience = CreateCandidateExperience(idCandidate, "mar", "montaña", "working", (decimal)22.5, new DateTime(2014, 07, 10), dt.AddDays(-1));
        var updateExperience = new UpdateCandidateExperienceVO
        {
            BeginDate = new DateTime(2014, 10, 10),
            Description = "Not workin",
            EndDate = new DateTime(2016, 10, 10),
            Salary = (decimal)40.6
        };
        var experience = _experiencesManager.UpdateExperience(idCandidate,idExperience,updateExperience);
        var experienceExpected = new ExperienceDto
        {
            IdCandidateExperience = idExperience,
            IdCandidate = idCandidate,
            Company = "mar",
            Job = "montaña",
            Description = "Not workin",
            BeginDate = new DateTime(2014, 10, 10),
            EndDate = new DateTime(2016, 10, 10),
            Salary = (decimal)40.6,
            InsertDate = dt.AddDays(-1),
            ModifyDate = dt
        };
        Assert.That(experienceExpected, Is.EqualTo(experience));
    }

    [Test]
    public void UpdateExperienceOkDDBB()
    {
        int idExperience = CreateCandidateExperience(idCandidate, "mar", "montaña", "working", (decimal)22.5, new DateTime(2014, 07, 10), dt.AddDays(-1));
        var updateExperience = new UpdateCandidateExperienceVO
        {
            BeginDate = new DateTime(2014, 10, 10),
            Description = "Not workin",
            EndDate = new DateTime(2016, 10, 10),
            Salary = (decimal)40.6
        };
        _experiencesManager.UpdateExperience(idCandidate, idExperience, updateExperience);
        using(var toCheck = OurServiceLocator.GetUnitOfWork()) 
        {
            var experience = toCheck.CadidateExperiences.GetById(idExperience);
            Assert.IsNotNull(experience);
            Assert.That(experience.BeginDate, Is.EqualTo(new DateTime(2014, 10, 10)));
            Assert.That(experience.Description, Is.EqualTo("Not workin"));
            Assert.That(experience.EndDate, Is.EqualTo(new DateTime(2016, 10, 10)));
            Assert.That(experience.Salary, Is.EqualTo((decimal)40.6));
            Assert.That(experience.InsertDate, Is.EqualTo(dt.AddDays(-1)));
            Assert.That(experience.ModifyDate, Is.EqualTo(dt));

        }
    }

    [Test]
    public void UpdateExperienceNotFound()
    {
        var updateExperience = new UpdateCandidateExperienceVO
        {
            BeginDate = new DateTime(2014, 10, 10),
            Description = "Not workin",
            EndDate = new DateTime(2016, 10, 10),
            Salary = (decimal)40.6
        };
        Assert.Throws<Exception>(() => _experiencesManager.UpdateExperience(idCandidate,0, updateExperience));
    }

    [Test]
    public void UpdateExperienceUerNotFound()
    {
        var updateExperience = new UpdateCandidateExperienceVO
        {
            Description = "description",
            Salary = (decimal)12.5,
            BeginDate = new DateTime(2024, 01, 01),
        };
        Assert.Throws<Exception>(() => _experiencesManager.UpdateExperience(0, 0, updateExperience));
    }

    [Test]
    public void UpdateExperienceValidate() 
    {
        var updateExperience = new UpdateCandidateExperienceVO
        {
            Description = "Not workin",
            EndDate = new DateTime(2016, 10, 10),
            Salary = (decimal)40.6
        };
        Assert.Throws<ArgumentNullException>(() => _experiencesManager.UpdateExperience(idCandidate, 0, updateExperience));
    }
}
