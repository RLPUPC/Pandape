namespace Pandape.Domain.Dto;

public class CreateCandidateVO
{
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public DateTime Birthdate { get; set; }
    public string Email { get; set; } = default!;

    public void Validate() 
    {
        if(string.IsNullOrEmpty(Name))
            throw new ArgumentNullException(nameof(Name), "The Name is requiered");
        if(string.IsNullOrEmpty(Surname))
            throw new ArgumentNullException(nameof(Surname), "The Surname is requiered");
        if(string.IsNullOrEmpty(Email))
            throw new ArgumentNullException(nameof(Email), "The Email is requiered");
        if (Birthdate == default(DateTime))
            throw new ArgumentNullException(nameof(Birthdate), "The Birthdate is requiered");
    }
}
