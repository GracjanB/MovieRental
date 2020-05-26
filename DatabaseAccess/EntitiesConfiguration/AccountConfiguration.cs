using DatabaseAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.EntitiesConfiguration
{
    public class AccountConfiguration : EntityTypeConfiguration<Account>
    {
        public AccountConfiguration()
        {
            // Primary Key
            HasKey(x => x.Id);

            Property(x => x.Username)
                .HasColumnName("Username")
                .HasColumnType("NVARCHAR")
                .IsRequired()
                .HasMaxLength(64);

            Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR")
                .IsRequired()
                .HasMaxLength(64);

            Property(x => x.Password)
                .HasColumnName("Password")
                .HasColumnType("NVARCHAR")
                .IsRequired()
                .HasMaxLength(256);

            Property(x => x.FirstName)
                .HasColumnName("Firstname")
                .HasColumnType("NVARCHAR")
                .IsRequired()
                .HasMaxLength(64);

            Property(x => x.LastName)
                .HasColumnName("Lastname")
                .HasColumnType("NVARCHAR")
                .IsRequired()
                .HasMaxLength(64);

            Property(x => x.IsActive)
                .HasColumnName("IsActive")
                .HasColumnType("BIT")
                .IsOptional();

            HasMany(x => x.Reviews)
                .WithRequired(x => x.Account)
                .HasForeignKey(x => x.AccountId);

            HasMany(x => x.VideoRentals)
                .WithRequired(x => x.Account)
                .HasForeignKey(x => x.AccountId);
        }
    }
}
