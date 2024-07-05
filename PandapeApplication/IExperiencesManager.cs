namespace Pandape.Application;

public interface IExperiencesManager
{
    ExperienceDto CreateExperience(int idCandidate, CreateCandidateExperienceVO experience);
    ExperienceDto UpdateExperience(int idCandidate, int idExperience, UpdateCandidateExperienceVO experience);
    ExperienceDto GetExperienceById(int idExperience);
    void DeleteExperience(int idExperience);
}
