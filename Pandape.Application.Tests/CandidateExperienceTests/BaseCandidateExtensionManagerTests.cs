using Pandape.Application.Tests;

namespace Pandape.Application.CandidateExperienceTests;

public class BaseCandidateExtensionManagerTests: BaseUowTest
{
    public ExperiencesManager _experiencesManager = default!;

    public void BaseSetUp() 
    {
        _clockManager = new MockClockManager();
        _experiencesManager = new ExperiencesManager(OurServiceLocator.GetUnitOfWork(), _clockManager);
    }
}
