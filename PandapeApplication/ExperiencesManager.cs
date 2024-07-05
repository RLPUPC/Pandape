using Pandape.Infrastructure.Domain.Dto;

namespace Pandape.Application;

public class ExperiencesManager: IExperiencesManager
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClockManager _clockManager;

    public ExperiencesManager(IUnitOfWork unitOfWork, IClockManager clockManager) 
    {
        _unitOfWork = unitOfWork;
        _clockManager = clockManager;
    }

    public ExperienceDto CreateExperience(int idCandidate, CreateCandidateExperienceVO crateExperience)
    {
        var candidate = _unitOfWork.Cadidates.GetById(idCandidate);
        if (candidate == null)
            throw new Exception("The candidate does not exists");
        crateExperience.Validate();
        var newExperience = crateExperience.ToCandidateExperience(idCandidate);
        newExperience.InsertDate = _clockManager.GetCurrentUtc();
        var experience = _unitOfWork.CadidateExperiences.Add(newExperience);
        _unitOfWork.Commit();
        return experience.ToCandidateExperienceDto();
    }

    public void DeleteExperience(int idExperience)
    {
        var experience = _unitOfWork.CadidateExperiences.GetById(idExperience);
        if (experience == null)
            throw new Exception("The experience does not exists");
        _unitOfWork.CadidateExperiences.Delete(experience);
        _unitOfWork.Commit();
    }

    public ExperienceDto GetExperienceById(int idExperience)
    {
        var experience = _unitOfWork.CadidateExperiences.GetById(idExperience);
        if (experience == null)
            throw new Exception("The experience does not exists");
        return experience.ToCandidateExperienceDto();
    }

    public ExperienceDto UpdateExperience(int idCandidate, int idExperience, UpdateCandidateExperienceVO updateExperience)
    {

        var candidate = _unitOfWork.Cadidates.GetById(idCandidate);
        if (candidate == null)
            throw new Exception("The candidate does not exists");
        updateExperience.Validate();
        var experience = _unitOfWork.CadidateExperiences.GetById(idExperience);
        if (experience == null)
            throw new Exception("The experience does not exists");
        experience.Description = updateExperience.Description;
        experience.Salary = updateExperience.Salary;
        experience.BeginDate = updateExperience.BeginDate;
        experience.EndDate = updateExperience.EndDate;
        experience.ModifyDate = _clockManager.GetCurrentUtc();
        var experienceUpdated = _unitOfWork.CadidateExperiences.Update(experience);
        _unitOfWork.Commit();
        return experienceUpdated.ToCandidateExperienceDto();
    }
}
