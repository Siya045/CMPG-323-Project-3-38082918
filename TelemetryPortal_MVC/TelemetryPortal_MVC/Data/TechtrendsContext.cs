using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TelemetryPortal_MVC.Models;

namespace TelemetryPortal_MVC.Data;

public partial class TechtrendsContext : DbContext
{
    public TechtrendsContext()
    {
    }

    public TechtrendsContext(DbContextOptions<TechtrendsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Project> Projects { get; set; }


  /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=project2-38082918.database.windows.net;Database=TechTrends2;User Id=cmpg323;Password=cmpg@323;");*/
   


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");

        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("Client", "Config");

            entity.Property(e => e.ClientId)
                .ValueGeneratedNever()
                .HasColumnName("ClientID");
            entity.Property(e => e.DateOnboarded).HasColumnType("datetime");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.ToTable("Project", "Config");

            entity.Property(e => e.ProjectId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ProjectID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.ProjectCreationDate)
                .HasDefaultValueSql("(dateadd(hour,(2),getdate()))")
                .HasColumnType("datetime");
            entity.Property(e => e.ProjectDescription)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ProjectName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ProjectStatus)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
