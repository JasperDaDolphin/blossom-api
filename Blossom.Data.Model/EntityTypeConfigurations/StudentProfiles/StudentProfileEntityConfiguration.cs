using Blossom.Data.Model.StudentProfiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Blossom.Data.Model.EntityTypeConfigurations.StudentProfiles
{
	public class StudentProfileEntityConfiguration : IEntityTypeConfiguration<StudentProfileEntity>
	{
		public void Configure(EntityTypeBuilder<StudentProfileEntity> builder)
		{
			builder.ToTable("bc_studentprofile");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.HasColumnName("id")
				.IsRequired();
        }
	}
}