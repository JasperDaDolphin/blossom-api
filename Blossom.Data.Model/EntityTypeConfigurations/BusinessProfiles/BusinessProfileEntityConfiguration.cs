using Blossom.Data.Model.BusinessProfiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Blossom.Data.Model.EntityTypeConfigurations.BusinesProfiles
{
	public class BusinessProfileEntityConfiguration : IEntityTypeConfiguration<BusinessProfileEntity>
	{
		public void Configure(EntityTypeBuilder<BusinessProfileEntity> builder)
		{
			builder.ToTable("bc_businessprofile");

			builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.Location)
                .HasColumnName("location")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.Size)
                .HasColumnName("size")
                .HasMaxLength(255)
                .IsRequired();
        }
	}
}