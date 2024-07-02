using Pandape.Infrastructure.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandape.Domain;

public record CandidateDto() 
{
    public int IdCandidate { get; set; }
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public DateTime Birthdate { get; set; }
    public string Email { get; set; } = default!;
    public DateTime InsertDate { get; set; }
    public DateTime? ModifyDate { get; set; }
    public IEnumerable<CandidateExperienceDto>? Experience { get; set; }
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
}
