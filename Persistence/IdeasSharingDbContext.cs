﻿using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
	public class IdeasSharingDbContext : DbContext
	{
        public IdeasSharingDbContext(DbContextOptions<IdeasSharingDbContext> options)
            : base (options)
        {
            
        }

        public DbSet<Category> Ideas { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Like> Likes { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdeasSharingDbContext).Assembly);

			// seed data, which is added by migrations
			var businessGuid = Guid.Parse("{2ed64fe5-cd54-4cd0-9898-8d3d759c2f00}");
			var educationGuid = Guid.Parse("{1e6075a3-a411-42d0-9711-f901714c86df}");
			var entertainmentGuid = Guid.Parse("{ed2fa5f2-0692-41f2-ba8e-4b41847b2c44}");
			var medicineGuid = Guid.Parse("{d3ee4713-ea7b-4097-9c99-3c6f585185d8}");
			var utilityGuid = Guid.Parse("{3088c1ee-60be-45e8-bbb1-6d9f5b68365b}");

			modelBuilder.Entity<Category>().HasData(new Category
			{
				Id = businessGuid,
				Name = "Business",
			});

			modelBuilder.Entity<Category>().HasData(new Category
			{
				Id = educationGuid,
				Name = "Education",
			});

			modelBuilder.Entity<Category>().HasData(new Category
			{
				Id = entertainmentGuid,
				Name = "Entertainment",
			});

			modelBuilder.Entity<Category>().HasData(new Category
			{
				Id = medicineGuid,
				Name = "Medicine",
			});

			modelBuilder.Entity<Category>().HasData(new Category
			{
				Id = utilityGuid,
				Name = "Utility",
			});

			// Ideas seeding
			modelBuilder.Entity<Category>().HasData(new Category
			{
				Id = utilityGuid,
				Name = "Create an weather app powered by AI!",
				Description = "With recent AI advancements, application development can benefit greatly. This use case is one of the many viable ones."
			});

			modelBuilder.Entity<Category>().HasData(new Category
			{
				Id = utilityGuid,
				Name = "Metro application featuring AI",
				Description = "An app which makes recommendations on which metro stations to improve based on feedback and recommendations on where one could be opened to meet the demand."
			});

			base.OnModelCreating(modelBuilder);
		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
		{
			foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
			{
				switch (entry.State)
				{
					case EntityState.Added:
						entry.Entity.CreatedDate = DateTime.UtcNow;
						break;
					case EntityState.Modified:
						entry.Entity.LastModifiedDate = DateTime.UtcNow;
						break;
				}
			}

			return base.SaveChangesAsync(cancellationToken);
		}
	}
}