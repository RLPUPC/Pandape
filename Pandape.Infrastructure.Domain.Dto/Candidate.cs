using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandape.Infrastructure.Domain.Dto;

public class Candidate
{
    public int IdCandidate { get; set; }
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public DateTime Birthdate { get; set; }
    public string Email { get; set; } = default!;
    public DateTime InsertDate { get; set; }
    public DateTime? ModifyDate { get; set; }


    public virtual ICollection<CandidateExperience> Experiences { get; set; } = new List<CandidateExperience>();
}
