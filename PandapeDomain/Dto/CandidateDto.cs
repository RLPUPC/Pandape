using Pandape.Infrastructure.Domain.Dto;

namespace Pandape.Domain.Dto;

public record CandidateDto()
{
    public int IdCandidate { get; set; }
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public DateTime Birthdate { get; set; }
    public string Email { get; set; } = default!;
    public DateTime InsertDate { get; set; }
    public DateTime? ModifyDate { get; set; }
    public IEnumerable<ExperienceDto>? Experience { get; set; }
}

public static class CandidateDtoExtension
{
    public static CandidateDto ToCandidateDto(this Candidate candidate)
    {
        return new CandidateDto
        {
            IdCandidate = candidate.IdCandidate,
            Name = candidate.Name,
            Surname = candidate.Surname,
            Birthdate = candidate.Birthdate,
            Email = candidate.Email,
            InsertDate = candidate.InsertDate,
            ModifyDate = candidate.ModifyDate,
        };
    }

    public static Candidate ToCandidate(this CreateCandidateVO candidate)
    {
        return new Candidate
        {
            Name = candidate.Name,
            Surname = candidate.Surname,
            Birthdate = candidate.Birthdate,
            Email = candidate.Email,
        };
    }
}
