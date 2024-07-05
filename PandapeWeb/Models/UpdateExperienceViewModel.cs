using System.ComponentModel.DataAnnotations;

namespace PandapeWeb.Models;

public class UpdateExperienceViewModel
{
    public int IdExperience { get; set; }  
    public int IdCandidate { get; set; }
    public string Description { get; set; } = default!;
    public decimal Salary { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime BeginDate { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime? EndDate { get; set; }
}
