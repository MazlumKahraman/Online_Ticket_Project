using System;
using System.Collections.Generic;
using E_vent.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace E_vent.DataAccess.Concrete
{
    public partial class EventOnlineTicketContext : DbContext
    {
        public EventOnlineTicketContext()
        {
        }

        public EventOnlineTicketContext(DbContextOptions<EventOnlineTicketContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Entegrator> Entegrators { get; set; } = null!;
        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<EventTicket> EventTickets { get; set; } = null!;
        public virtual DbSet<EventUser> EventUsers { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserDetail> UserDetails { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'default')");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Entegrator>(entity =>
            {
                entity.Property(e => e.DomainName).HasMaxLength(100);

                entity.Property(e => e.MailAdress).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.SecretKey).HasMaxLength(50);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.Adress).HasMaxLength(100);

                entity.Property(e => e.BegginigTime).HasColumnType("datetime");

                entity.Property(e => e.LastAttendance).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.StatusId).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Events_Categories");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Events_Cities");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Events_Statuses");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Events_Users");
            });

            modelBuilder.Entity<EventTicket>(entity =>
            {
                entity.HasOne(d => d.Entegrator)
                    .WithMany(p => p.EventTickets)
                    .HasForeignKey(d => d.EntegratorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventTickets_Entegrators");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventTickets)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventTickets_Events");
            });

            modelBuilder.Entity<EventUser>(entity =>
            {
                entity.Property(e => e.ActionTime).HasColumnType("datetime");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventUsers)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventUsers_Events");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EventUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventUsers_Users");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.StatusName).HasMaxLength(50);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ActionTime).HasColumnType("datetime");

                entity.HasOne(d => d.EventTicket)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.EventTicketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tickets_EventTickets");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tickets_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.MailAdress).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(30);

                entity.HasOne(d => d.Detail)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DetailId)
                    .HasConstraintName("FK_Users_UserDetails");
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasKey(e => e.DetailId);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .HasColumnName("MiddleNAme");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
