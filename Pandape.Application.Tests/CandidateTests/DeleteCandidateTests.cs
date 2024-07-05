namespace Pandape.Application.CandidateTests;

[TestFixture]
public class DeleteCandidateTests : BaseCandidateManagerTest
{
    private int id1;
    private DateTime dt;

    [SetUp]
    public void SetUp()
    {
        dt = new DateTime(2022, 08, 08);
        BaseSetUp();
        _clockManager.SetCurrentUtc(dt);
        id1 = CreateCandidate("name3", "surname3", new DateTime(2000, 01, 30), "Candi4@Candi1.com", dt);
    }

    [TearDown]
    public void TearDown() 
    {
        ClearCandidateDDBB();
    }

    [Test]
    public void DeleteCandidateOkDDBB()
    {
        _candidateManager.DeleteCandidate(id1);
        using (var toCheck = OurServiceLocator.GetUnitOfWork())
        {
            var candite = toCheck.Cadidates.GetById(id1);
            Assert.IsNull(candite);
        }
    }

    [Test]
    public void DeleteCandidateWithExperiencesOkDBB()
    {
        int idExperience = CreateCandidateExperience(id1, "mar", "montaña", "working", (decimal)22.5, new DateTime(2014,07,10), dt);
        _candidateManager.DeleteCandidate(id1);
        using (var toCheck = OurServiceLocator.GetUnitOfWork())
        {
            var canditeExperience = toCheck.CadidateExperiences.GetById(idExperience);
            Assert.IsNull(canditeExperience);
            var candite = toCheck.Cadidates.GetById(id1);
            Assert.IsNull(candite);
        }
    }

    [Test]
    public void DeleteCandidateNotFound()
    {
        Assert.Throws<Exception>(() => _candidateManager.DeleteCandidate(0));
    }

}
