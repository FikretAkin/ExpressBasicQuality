using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }
        public virtual DbSet<xUser> xUser { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<xUser>(entity =>
            {
                entity.Property(e => e.EMail)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(e => e.Password1)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(e => e.Role1)
                    .IsRequired()
                    .HasMaxLength(255);
            });
        }
    }
}
