using DatabaseAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.EntitiesConfiguration
{
    public class VideoRentalConfiguration : EntityTypeConfiguration<VideoRental>
    {
        public VideoRentalConfiguration()
        {
            // Primary Key
            HasKey(x => x.Id);

            Property(x => x.DateCreated)
                .HasColumnName("DateCreated")
                .HasColumnType("DATETIME2")
                .IsRequired();

            Property(x => x.DateStart)
                .HasColumnName("DateStart")
                .HasColumnType("DATETIME2")
                .IsRequired();

            Property(x => x.DateEnd)
                .HasColumnName("DateEnd")
                .HasColumnType("DATETIME2")
                .IsRequired();

            Property(x => x.Price)
                .HasColumnName("Price")
                .HasColumnType("SMALLMONEY")
                .HasPrecision(6, 2);
        }
    }
}
