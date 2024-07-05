using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pandape.Infrastructure.Database.TypeConfigurations;

public class CandidateExperienceConfiguration: IEntityTypeConfiguration<CandidateExperience>, IEntityConfiguration
{

    public void AddConfiguration(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(this);
    }

    public void Configure(EntityTypeBuilder<CandidateExperience> builder)
    {
        builder.HasKey(e => new { e.IdCandidateExperience });
        builder.Property(e => e.IdCandidateExperience)
            .HasColumnName("IdCandidateExperience")
            .IsRequired();
        builder.Property(e => e.IdCandidate)
            .HasColumnName("IdCandidate")
            .IsRequired();
        builder.Property(e => e.Company)
            .HasColumnName("Company")
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(e => e.Job)
            .HasColumnName("Job")
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(e => e.Description)
            .HasColumnName("Description")
            .HasMaxLength(4000)
            .IsRequired();
        builder.Property(e => e.Salary)
            .HasColumnName("Salary")
            .HasPrecision(8,2)
            .IsRequired();
        builder.Property(e => e.BeginDate)
            .HasColumnName("BeginDate")
            .IsRequired();
        builder.Property(e => e.EndDate)
            .HasColumnName("EndDate");
        builder.Property(e => e.InsertDate)
            .HasColumnName("InsertDate")
            .IsRequired();
        builder.Property(e => e.ModifyDate)
            .HasColumnName("ModifyDate");

        builder.ToTable("CandidatesExperiences");

    }
}
