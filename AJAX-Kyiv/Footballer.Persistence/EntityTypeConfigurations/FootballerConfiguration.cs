using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Footballers.Persistence.EntityTypeConfigurations
{
    public class FootballerConfiguration : IEntityTypeConfiguration<AJAXKyiv.Domain.Footballer>
    {
        public void Configure(EntityTypeBuilder<AJAXKyiv.Domain.Footballer> builder)
        {
            builder.HasKey(footballer => footballer.Id);
            builder.Property(footballer => footballer.Id)
                   .ValueGeneratedOnAdd();            
            builder.HasIndex(footballer => footballer.Id).IsUnique();
            builder.Property(footballer => footballer.Name).HasMaxLength(50);
            builder.Property(footballer => footballer.LastName).HasMaxLength(50);

        }
    }
}
