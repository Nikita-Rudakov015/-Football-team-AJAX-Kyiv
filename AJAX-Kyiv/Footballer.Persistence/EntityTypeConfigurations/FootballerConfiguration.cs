using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AJAXKyiv.Domain;


namespace Footballers.Persistence.EntityTypeConfigurations
{
    public class FootballerConfiguration : IEntityTypeConfiguration<Footballer>
    {
        public void Configure(EntityTypeBuilder<Footballer> builder)
        {
            builder.HasKey(note => note.Id);
            builder.HasIndex(note => note.Id).IsUnique();
            builder.Property(note => note.Name).HasMaxLength(50);
            builder.Property(note => note.LastName).HasMaxLength(50);

        }
    }
}
