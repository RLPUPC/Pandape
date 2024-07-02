namespace PandapeWeb.Models;

public class CreateCanditeViewModel
{
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public DateTime Birthdate { get; set; }
    public string Email { get; set; } = default!;
}
