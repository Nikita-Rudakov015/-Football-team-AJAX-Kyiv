using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Footballers.Persistence.EntityTypeConfigurations
{
    public class FootballerConfiguration : IEntityTypeConfiguration<AJAXKyiv.Domain.Footballer>
    {
        public void Configure(EntityTypeBuilder<AJAXKyiv.Domain.Footballer> builder)
        {
            builder.HasKey(note => note.Id);
            builder.HasIndex(note => note.Id).IsUnique();
            builder.Property(note => note.Name).HasMaxLength(50);
            builder.Property(note => note.LastName).HasMaxLength(50);

        }
    }
}
