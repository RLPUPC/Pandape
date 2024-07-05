namespace Pandape.Infrastructure.Database.Repository;

public interface IUnitOfWork: IDisposable
{
    public void Commit();
    public void Rollback();
    IRepository<Candidate> Cadidates { get; }
    IRepository<CandidateExperience> CadidateExperiences { get; }
}
