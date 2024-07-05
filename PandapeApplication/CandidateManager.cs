using Pandape.Infrastructure.Domain.Dto;

namespace Pandape.Application;

public class CandidateManager: ICandidateManager
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClockManager _clockManager;

    public CandidateManager(IUnitOfWork unitOfWork, IClockManager clockManager) 
    {
        _unitOfWork = unitOfWork;
        _clockManager = clockManager;
    }

    public CandidateDto CreateCandidate(CreateCandidateVO createCandidate)
    {
        createCandidate.Validate();
        if (_unitOfWork.Cadidates.GetAll().Any(x => x.Email.Equals(createCandidate.Email)))
            throw new Exception("Email already exists");
        var candidate = createCandidate.ToCandidate();
        candidate.InsertDate = _clockManager.GetCurrentUtc();
        var newCadidate = _unitOfWork.Cadidates.Add(candidate);
        _unitOfWork.Commit(); 
        return newCadidate.ToCandidateDto();  
    }

    public void DeleteCandidate(int idCandite)
    {
        var candidate = _unitOfWork.Cadidates.GetById(idCandite);
        if (candidate == null)
            throw new Exception("The candidate does not exists");
        _unitOfWork.Cadidates.Delete(candidate);
        _unitOfWork.Commit();
    }

    public CandidateDto GetCandidateById(int idCandidate)
    {
        var candidate = _unitOfWork.Cadidates.GetById(idCandidate);
        if(candidate == null)
            throw new Exception("The candidate does not exists");
        return candidate.ToCandidateDto();
    }

    public IEnumerable<CandidateDto> GetCandidates()
    {
        return _unitOfWork.Cadidates.GetAll().OrderBy(x => x.Name).ThenBy(x => x.Surname).Select(x => x.ToCandidateDto());
    }

    public CandidateDto UpdateCandidate(int idCandite, UpdateCandidateVO updateCandidate)
    {
        updateCandidate.Validate();
        var dt = _clockManager.GetCurrentUtc();
        var candidate = _unitOfWork.Cadidates.GetById(idCandite);
        if(candidate == null)
            throw new Exception("The candidate does not exists");
        var anyCandidate = _unitOfWork.Cadidates.GetAll().FirstOrDefault(x => x.Email == updateCandidate.Email);
        if (anyCandidate != null && anyCandidate.IdCandidate != idCandite)
            throw new Exception("Email already exists");
        try
        {
            _unitOfWork.Cadidates.DetachEntity(candidate);
            candidate.Email = updateCandidate.Email;
            candidate.Birthdate = updateCandidate.Birthdate;
            candidate.ModifyDate = dt;
            _unitOfWork.Cadidates.AttachEntity(candidate);
            var candidateDt = _unitOfWork.Cadidates.Update(candidate);
            _unitOfWork.Commit();
            return candidateDt.ToCandidateDto();
        }
        catch (Exception)
        {
            _unitOfWork.Rollback();
            throw new Exception("Error updating candidate ");
        }
        
    }

    public CandidateExperienceDto GetExpereincesByCandidate(int idCandidate)
    {
        var candidate = _unitOfWork.Cadidates.Include(x => x.Experiences).FirstOrDefault(x => x.IdCandidate == idCandidate);
        if (candidate == null)
            throw new Exception("The candidate does not exists");
        var aux = candidate.Experiences.ToArray();
        var experiences = candidate.Experiences.OrderBy(x => x.Company).ThenBy(x => x.Job).Select(x => x.ToCandidateExperienceDto()).ToArray();
        var candidateReturn = new CandidateExperienceDto
        {
            FullName = $"{candidate.Name} {candidate.Surname}",
            IdCandidate = candidate.IdCandidate,
            Experiences = experiences
        };
        return candidateReturn;
    }
}
