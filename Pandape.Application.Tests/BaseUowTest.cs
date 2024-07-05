using Pandape.Infrastructure.Domain.Dto;

namespace Pandape.Application.Tests;

public class BaseUowTest
{
    protected MockClockManager _clockManager = default!;

    public static int CreateCandidate(string name, string surname, DateTime birthDate, string email, DateTime insertDate, DateTime? modifyDate = null)
    {
        using (var toCreate = OurServiceLocator.GetUnitOfWork())
        {
            var newCandite = new Candidate { Name = name, Surname = surname, Birthdate = birthDate, Email = email, InsertDate = insertDate, ModifyDate = modifyDate };
            newCandite = toCreate.Cadidates.Add(newCandite);
            toCreate.Commit();
            return newCandite.IdCandidate;
        }
    }

    public int CreateCandidateExperience(int idCandidate, string company, string job, string description, decimal salary, DateTime beginDate, DateTime insertDate, DateTime? endDate = null, DateTime? modifyDate = null)
    {
        using (var toCreate = OurServiceLocator.GetUnitOfWork())
        {
            var newCanditeExperience = new CandidateExperience
            {
                IdCandidate = idCandidate,
                Company = company,
                Job = job,
                Description = description,
                Salary = salary,
                BeginDate = beginDate,
                EndDate = endDate,
                InsertDate = insertDate,
                ModifyDate = modifyDate
            };
            newCanditeExperience = toCreate.CadidateExperiences.Add(newCanditeExperience);
            toCreate.Commit();
            return newCanditeExperience.IdCandidateExperience;
        }

    }

    public void ClearCandidateDDBB()
    {
        using (var toDelete = OurServiceLocator.GetUnitOfWork())
        {
            var candidates = toDelete.Cadidates.GetAll();
            foreach (var candidate in candidates)
            {
                toDelete.Cadidates.Delete(candidate);
            }
            var experiences = toDelete.CadidateExperiences.GetAll();
            foreach (var experience in experiences)
            {
                toDelete.CadidateExperiences.Delete(experience);
            }
            toDelete.Commit();
        }
    }
}
