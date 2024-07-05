using System.ComponentModel.DataAnnotations;

namespace PandapeWeb.Models;

public class UpdateCandidateViewModel
{
    public int IdCandidate { get; set; }
    public string Email { get; set; } = default!;
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime Birthdate { get; set; }
}
