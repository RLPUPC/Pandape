namespace Pandape.Domain.Dto;

public class UpdateCandidateVO
{
    public string Email { get; set; } = default!;
    public DateTime Birthdate { get; set; }

    public void Validate()
    {
        if (string.IsNullOrEmpty(Email))
            throw new ArgumentNullException(nameof(Email), "The Email is requiered");
        if (Birthdate == default(DateTime))
            throw new ArgumentNullException(nameof(Birthdate), "The Birthdate is requiered");
    }
}
