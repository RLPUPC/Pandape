namespace Pandape.Domain.Dto;

public class CreateCandidateExperienceVO
{
    public string Company { get; set; } = default!;
    public string Job { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Salary { get; set; }
    public DateTime BeginDate { get; set; }
    public DateTime? EndDate { get; set; }

    public void Validate()
    {
        if (string.IsNullOrEmpty(Company))
            throw new ArgumentNullException(nameof(Company), "The Company is requiered");
        if (string.IsNullOrEmpty(Job))
            throw new ArgumentNullException(nameof(Job), "The Job is requiered");
        if (string.IsNullOrEmpty(Description))
            throw new ArgumentNullException(nameof(Description), "The Email is requiered");
        if(Salary == default)
            throw new ArgumentNullException(nameof(Salary), "The Salary is requiered");
        if (BeginDate == default(DateTime))
            throw new ArgumentNullException(nameof(BeginDate), "The BeginDate is requiered");
    }
}

public class UpdateCandidateExperienceVO
{
    public string Description { get; set; } = default!;
    public decimal Salary { get; set; }
    public DateTime BeginDate { get; set; }
    public DateTime? EndDate { get; set; }
    public void Validate()
    {
        if (string.IsNullOrEmpty(Description))
            throw new ArgumentNullException(nameof(Description), "The Email is requiered");
        if (Salary == default)
            throw new ArgumentNullException(nameof(Salary), "The Salary is requiered");
        if (BeginDate == default(DateTime))
            throw new ArgumentNullException(nameof(BeginDate), "The BeginDate is requiered");
    }
}
