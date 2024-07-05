using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Pandape.Domain.Dto;

namespace Pandape.Domain.Tests;

public class ValidateCandiateTests
{
#pragma warning disable CS8601 // Disable warning to check null or empty
    [TestCase(null)]
    [TestCase("")]
    [Test]
    public void CreateNameIsNullOrEmpty(string? name)
    {
        var newCandidate = new CreateCandidateVO
        {
            Name = name,
            Surname = "SurnameCandi1",
            Email = "Candi1@Candi1.com",
            Birthdate = new DateTime(2000, 01, 01)
        };
        Assert.Throws<ArgumentNullException>(() => newCandidate.Validate());
    }

    [TestCase(null)]
    [TestCase("")]
    [Test]
    public void CreateSurnameIsNull(string? surname)
    {
        var newCandidate = new CreateCandidateVO
        {
            Name = "Candi1",
            Surname = surname,
            Email = "Candi1@Candi1.com",
            Birthdate = new DateTime(2000, 01, 01)
        };
        Assert.Throws<ArgumentNullException>(() => newCandidate.Validate());
    }

    [TestCase(null)]
    [TestCase("")]
    [Test]
    public void CreateEmailIsNull(string? email)
    {
        var newCandidate = new CreateCandidateVO
        {
            Name = "Candi1",
            Surname = "SurnameCandi1",
            Email = email,
            Birthdate = new DateTime(2000, 01, 01)
        };
        Assert.Throws<ArgumentNullException>(() => newCandidate.Validate());
    }



    [TestCase(null)]
    [TestCase("")]
    [Test]
    public void UpdateEmailIsNul(string? email)
    {
        var newCandidate = new UpdateCandidateVO
        {
            Email = email,
            Birthdate = new DateTime(2000, 01, 01)
        };
        Assert.Throws<ArgumentNullException>(() => newCandidate.Validate());
    }
#pragma warning restore CS8601 // Disable warning to check null or empty

    [Test]
    public void CreateBirthdayIsNull()
    {
        var newCandidate = new CreateCandidateVO
        {
            Name = "Candi1",
            Surname = "SurnameCandi1",
            Email = "Candi1@Candi1.com",
        };
        Assert.Throws<ArgumentNullException>(() => newCandidate.Validate());
    }

    [Test]
    public void UpdateBirthdayIsNull()
    {
        var newCandidate = new UpdateCandidateVO
        {
            Email = "Candi1@Candi1.com",
        };
        Assert.Throws<ArgumentNullException>(() => newCandidate.Validate());
    }
}
