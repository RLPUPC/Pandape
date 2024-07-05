namespace Pandape.Application
{
    public interface ICandidateManager
    {
        IEnumerable<CandidateDto> GetCandidates();
        CandidateDto GetCandidateById(int idCandidate);
        CandidateDto CreateCandidate(CreateCandidateVO newCandidate);
        CandidateDto UpdateCandidate(int idCandite, UpdateCandidateVO updateCandidate);
        void DeleteCandidate(int idCandite);
        CandidateExperienceDto GetExpereincesByCandidate(int idCandidate);
    }
}
