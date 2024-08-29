using IkJet.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IkJet.DAL.Data
{
	public class IkJetDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
	{
		public IkJetDbContext(DbContextOptions<IkJetDbContext> options) : base(options)
		{ }
		public DbSet<Expense> Expenses { get; set; }
		public DbSet<Prepayment> Prepayments { get; set; }
		public DbSet<WorkOff> WorkOffs { get; set; }
		public DbSet<Company> Companies { get; set; }


		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			var hasher = new PasswordHasher<AppUser>();
			builder.Entity<AppUser>()
				.HasData(new AppUser
				{
					Id = 1,
					FirstName = "adminName",
					LastName = "adminSurname",
					UserName = "admin",
					SecondName = "adminSecondName",
					SecondLastName = "adminSecondLastName",
					BirthDate = new DateTime(2024, 8, 1),
					BirthPlace = "admin",
					TCIdentityNumber = "12345678901",
					HireDate = new DateTime(2024, 8, 1),
					TerminationDate = new DateTime(2024, 8, 1),
					IsActive = true,
					JobTitle = "admin",
					Department = "admin",
					CompanyName = "admin",
					Address = "admin",
					Salary = 1,
					ConfirmationEmail = "admin@admin.com",
					ImageName = "admin",
					NormalizedUserName = "ADMIN",
					Email = "admin@mail.com",
					NormalizedEmail = "ADMIN@MAIL.COM",
					EmailConfirmed = true,
					PhoneNumberConfirmed = true,
					PhoneNumber = "-",
					PasswordHash = hasher.HashPassword(null, "Az*123456"),
					SecurityStamp = Guid.NewGuid().ToString(),
					CompanyId = null

				});





			builder.Entity<IdentityRole<int>>()
			   .HasData(new IdentityRole<int>
			   {
				   Id = 1,
				   Name = "Admin",
				   NormalizedName = "ADMIN",
			   });

			builder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int> { Id = 2, Name = "Personnel", NormalizedName = "PERSONNEL" });

			builder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int> { Id = 3, Name = "HRManager", NormalizedName = "HRMANAGER" });





			builder.Entity<IdentityUserRole<int>>()
				.HasData(new IdentityUserRole<int>
				{
					UserId = 1,
					RoleId = 1
				});






		}
	}
}
