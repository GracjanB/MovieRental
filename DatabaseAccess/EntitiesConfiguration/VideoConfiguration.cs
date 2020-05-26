using DatabaseAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.EntitiesConfiguration
{
    public class VideoConfiguration : EntityTypeConfiguration<Video>
    {
        public VideoConfiguration()
        {
            // Primary Key
            HasKey(x => x.Id);

            Property(x => x.Title)
                .HasColumnName("Title")
                .HasColumnType("NVARCHAR")
                .IsRequired()
                .HasMaxLength(64);

            Property(x => x.Category)
                .HasColumnName("Category")
                .IsOptional();

            Property(x => x.ProductionYear)
                .HasColumnName("ProductionYear")
                .HasColumnType("INT")
                .IsOptional();

            Property(x => x.Description)
                .HasColumnName("Description")
                .HasColumnType("NVARCHAR")
                .IsOptional()
                .IsMaxLength();

            Property(x => x.Country)
                .HasColumnName("Country")
                .HasColumnType("NVARCHAR")
                .IsOptional()
                .HasMaxLength(64);

            Property(x => x.Director)
                .HasColumnName("Director")
                .HasColumnType("NVARCHAR")
                .IsOptional()
                .HasMaxLength(64);

            Property(x => x.Scenario)
                .HasColumnName("Scenario")
                .HasColumnType("NVARCHAR")
                .IsOptional()
                .HasMaxLength(64);

            Property(x => x.PricePerDay)
                .HasColumnName("PricePerDay")
                .HasColumnType("SMALLMONEY")
                .HasPrecision(6, 2);

            HasMany(x => x.Reviews)
                .WithRequired(x => x.Video)
                .HasForeignKey(x => x.VideoId);

            HasMany(x => x.VideoRentals)
                .WithRequired(x => x.Video)
                .HasForeignKey(x => x.VideoId);
        }
    }
}
