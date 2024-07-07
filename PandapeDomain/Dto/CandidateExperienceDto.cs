using Microsoft.IdentityModel.Tokens;
using Pandape.Infrastructure.Domain.Dto;

namespace Pandape.Domain.Dto;
public class CandidateExperienceDto
{
    public string FullName { get; set; } = default!;
    public int IdCandidate { get; set; }
    public IEnumerable<ExperienceDto>? Experiences { get; set; }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        //Añado el Experiences != null para eliminar el warning
        var strExperiences = Experiences != null && !Experiences.IsNullOrEmpty() ? $", Experiences {Experiences.Select(x => x.ToString()).Aggregate((x, y) => $"{x} {y}")}" : string.Empty;
        return $"CandidateExperienceDto (FullName {FullName}, IdCandidate {IdCandidate}{strExperiences} )";
    }


    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if(obj.GetType() != GetType()) return false; 
        var toCompare = (CandidateExperienceDto)obj;
        return ((FullName == null) == (toCompare.FullName == null)) && (FullName == null || FullName.Equals(toCompare.FullName)) &&
            (IdCandidate == toCompare.IdCandidate) &&
#pragma warning disable CS8604
            ((Experiences == null) == (toCompare.Experiences == null)) && (Experiences == null || Experiences.SequenceEqual(toCompare.Experiences));
#pragma warning restore CS8604

    }
}

public record ExperienceDto
{
    public int IdCandidateExperience { get; set; }
    public int IdCandidate { get; set; }
    public string Company { get; set; } = default!;
    public string Job { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Salary { get; set; }
    public DateTime BeginDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime InsertDate { get; set; }
    public DateTime? ModifyDate { get; set; }
}


public static class CandidateExperiencesExtensions
{
    public static ExperienceDto ToCandidateExperienceDto(this CandidateExperience experience)
    {
        return new ExperienceDto
        {
            IdCandidateExperience = experience.IdCandidateExperience,
            IdCandidate = experience.IdCandidate,
            Company = experience.Company,
            Job = experience.Job,
            Description = experience.Description,
            Salary = experience.Salary,
            BeginDate = experience.BeginDate,
            EndDate = experience.EndDate,
            InsertDate = experience.InsertDate,
            ModifyDate = experience.ModifyDate,
        };
    }

    public static CandidateExperience ToCandidateExperience(this CreateCandidateExperienceVO experience, int idCandidate)
    {
        return new CandidateExperience
        {
            IdCandidate = idCandidate,
            Company = experience.Company,
            Job = experience.Job,
            Description = experience.Description,
            Salary = experience.Salary,
            BeginDate = experience.BeginDate,
            EndDate = experience.EndDate,
        };
    }
}    