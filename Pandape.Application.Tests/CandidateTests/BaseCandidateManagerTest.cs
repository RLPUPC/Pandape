using Pandape.Application.Tests;

namespace Pandape.Application.CandidateTests;

public class BaseCandidateManagerTest: BaseUowTest
{
    protected CandidateManager _candidateManager = default!;

    public void BaseSetUp()
    {
        _clockManager = new MockClockManager();
        _candidateManager = new CandidateManager(OurServiceLocator.GetUnitOfWork(), _clockManager);
    }

}
