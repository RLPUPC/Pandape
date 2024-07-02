using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pandape.Infrastructure.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandape.Infrastructure.Database.TypeConfigurations
{
    public class CandidateConfiguration: IEntityTypeConfiguration<Candidate>, IEntityConfiguration
    {

        public void AddConfiguration(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfiguration(this);
        }
     
        

        public void Configure(EntityTypeBuilder<Candidate> builder) 
        {
            builder.HasKey(e => new { e.IdCandidate });
            builder.HasAlternateKey(e => e.Email);
            builder.Property(e => e.IdCandidate)
                .HasColumnName("IdCandidate")
                .IsRequired()
                .UseIdentityColumn(seed: 0, increment: 1);
            builder.Property(e => e.Name)
                .HasColumnName("Name")
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(e => e.Surname)
                .HasColumnName("Surname")
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(e => e.Birthdate)
                .HasColumnName("Birthdate")
                .IsRequired();
            builder.Property(e => e.Email)
                .HasColumnName("Email")
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(e => e.InsertDate)
                .HasColumnName("InsertDate")
                .IsRequired();
            builder.Property(e => e.ModifyDate)
                .HasColumnName("ModifyDate");
            builder.HasMany(x => x.Experiences)
                .WithOne(b => b.Candidate)
                .HasForeignKey(e => e.IdCandidate);

            builder.ToTable("Candidates");

        }
    }
}
