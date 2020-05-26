using DatabaseAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.EntitiesConfiguration
{
    public class ReviewConfiguration : EntityTypeConfiguration<Review>
    {
        public ReviewConfiguration()
        {
            // Primary Key
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
