using System.ComponentModel.DataAnnotations;

namespace PandapeWeb.Models;

public class CandidateExperienceViewModel
{
    public string FullName { get; set; } = default!;
    public int IdCandidate { get; set; }
    public IEnumerable<ExperienceViewModel> Experiences { get; set; } = Array.Empty<ExperienceViewModel>();
}

public class ExperienceViewModel
{
    public int IdCandidateExperience { get; set; }
    public string Company { get; set; } = default!;
    public string Job { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Salary { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime BeginDate { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime? EndDate { get; set; }
}
