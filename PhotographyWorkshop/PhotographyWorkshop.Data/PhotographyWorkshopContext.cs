using PhotographyWorkshop.Models;

namespace PhotographyWorkshop.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhotographyWorkshopContext : DbContext
    {

        public PhotographyWorkshopContext()
            : base("name=PhotographyWorkshop")
        {
        }

        public virtual DbSet<Lens> Lenses { get; set; }
        public virtual DbSet<Camera> Cameras { get; set; }
        public virtual DbSet<Accessory> Accessories { get; set; }
        public virtual DbSet<Photographer> Photographers { get; set; }
        public virtual DbSet<Workshop> Workshops { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Photographer>()
                .HasMany(photo => photo.WorkshopsParticipant)
                .WithMany(work => work.Participants)
                .Map(
                    config =>
                    {
                        config.MapLeftKey("PhotographerId");
                        config.MapRightKey("WorkshopId");
                        config.ToTable("ParticipantsWorkshops");
                    });

            modelBuilder.Entity<Workshop>()
                .HasRequired(work => work.Trainer)
                .WithMany(trainer => trainer.WorkshopsTrainer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Photographer>()
                .HasRequired(photo => photo.PrimaryCamera)
                .WithMany(cam => cam.PhotographersPrimary)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Photographer>()
                .HasRequired(photo => photo.SecondaryCamera)
                .WithMany(cam => cam.PhotographersSecondary)
                .WillCascadeOnDelete(false);

        }
    }


}