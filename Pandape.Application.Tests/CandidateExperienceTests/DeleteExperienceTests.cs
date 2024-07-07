namespace Pandape.Application.CandidateExperienceTests;

[TestFixture]
public class DeleteExperienceTests: BaseCandidateExtensionManagerTests
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
    public void DeleteExperienceOkDDBB()
    {
        int idExperience = CreateCandidateExperience(idCandidate, "mar", "montaña", "working", (decimal)22.5, new DateTime(2014, 07, 10), dt);
        _experiencesManager.DeleteExperience(idExperience);
        using (var toCheck = OurServiceLocator.GetUnitOfWork())
        {
            var candite = toCheck.Cadidates.GetById(idExperience);
            Assert.IsNull(candite);
        }
    }

    [Test]
    public void DeleteExperienceNotFound()
    {
        Assert.Throws<Exception>(() => _experiencesManager.DeleteExperience(0));
    }
}
