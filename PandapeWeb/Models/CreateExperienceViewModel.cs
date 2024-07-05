namespace PandapeWeb.Models;

public class CreateExperienceViewModel
{
    public int IdCandidate { get; set; }
    public string Company { get; set; } = default!;
    public string Job { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Salary { get; set; }
    public DateTime BeginDate { get; set; }
    public DateTime? EndDate { get; set; }
}
