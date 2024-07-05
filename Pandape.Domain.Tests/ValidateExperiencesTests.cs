using Pandape.Domain.Dto;

namespace Pandape.Domain.Tests;

[TestFixture]
public class ValidateExperiencesTests
{
#pragma warning disable CS8601 // Disable warning to check null or empty
    [TestCase(null)]
    [TestCase("")]
    [Test]
    public void CreateCompanyIsNull(string? company) 
    {
        var createExperience = new CreateCandidateExperienceVO
        {
            Company = company,
            Job = "Job",
            Description = "Description",
            Salary = 2,
            BeginDate = new DateTime(2022, 05, 05),
        };
        Assert.Throws<ArgumentNullException>(() => createExperience.Validate());
    }
    
    [TestCase(null)]
    [TestCase("")]
    [Test]
    public void CreateJobIsNull(string? job) 
    {
        var createExperience = new CreateCandidateExperienceVO
        {
            Company = "Company",
            Job = job,
            Description = "Description",
            Salary = 2,
            BeginDate = new DateTime(2022, 05, 05),
        };
        Assert.Throws<ArgumentNullException>(() => createExperience.Validate());
    }
    
    [TestCase(null)]
    [TestCase("")]
    [Test]
    public void CreateDescriptionIsNull(string? description) 
    {
        var createExperience = new CreateCandidateExperienceVO
        {
            Company = "Company",
            Job = "Job",
            Description = description,
            Salary = 2,
            BeginDate = new DateTime(2022, 05, 05),
        };
        Assert.Throws<ArgumentNullException>(() => createExperience.Validate());
    }

    [TestCase(null)]
    [TestCase("")]
    [Test]
    public void UpdateDescriptionIsNull(string? description)
    {
        var updateExperience = new UpdateCandidateExperienceVO
        {
            Description = description,
            Salary = 2,
            BeginDate = new DateTime(2022, 05, 05),
        };
        Assert.Throws<ArgumentNullException>(() => updateExperience.Validate());
    }


#pragma warning restore CS8601 // Disable warning to check null or empty

    [Test]
    public void CreateSalaryIsNull()
    {
        var createExperience = new CreateCandidateExperienceVO
        {
            Company = "Company",
            Job = "Job",
            Description = "Description",
            BeginDate = new DateTime(2022, 05, 05),
        };
        Assert.Throws<ArgumentNullException>(() => createExperience.Validate());
    }

    [Test]
    public void CreateBegindateIsNull()
    {
        var createExperience = new CreateCandidateExperienceVO
        {
            Company = "Company",
            Job = "Job",
            Description = "Description",
            Salary = 2,
        };
        Assert.Throws<ArgumentNullException>(() => createExperience.Validate());
    }
    
    [Test]
    public void UpdateSalaryIsNull()
    {
        var updateExperience = new UpdateCandidateExperienceVO
        {
            Description = "Description",
            BeginDate = new DateTime(2022, 05, 05),
        };
        Assert.Throws<ArgumentNullException>(() => updateExperience.Validate());
    }

    [Test]
    public void UpdateBegindateIsNull()
    {
        var updateExperience = new UpdateCandidateExperienceVO
        {
            Description = "Description",
            Salary = 2,
        };
        Assert.Throws<ArgumentNullException>(() => updateExperience.Validate());
    }
}
