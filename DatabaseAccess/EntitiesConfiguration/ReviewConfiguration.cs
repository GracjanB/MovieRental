using DatabaseAccess.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DatabaseAccess.EntitiesConfiguration
{
    public class ReviewConfiguration : EntityTypeConfiguration<Review>
    {
        public ReviewConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Description)
                .HasColumnName("Description")
                .HasColumnType("NVARCHAR")
                .IsOptional()
                .IsMaxLength();

            Property(x => x.Rating)
                .HasColumnName("Rating")
                .HasColumnType("INT")
                .IsRequired();
        }
    }
}
