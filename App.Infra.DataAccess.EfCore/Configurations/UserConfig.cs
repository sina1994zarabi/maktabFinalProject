using App.Domain.Core.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.EfCore.Configurations
{
	public static class UserConfig 
	{
		public static void Seed(ModelBuilder builder)
		{
			
			var hasher = new PasswordHasher<AppUser>();

			var AdminUser = new AppUser
			{
				Id = 1,
				UserName = "adminUserName",
				NormalizedUserName = "ADMINUSERNAME",
				Email = "Admin@Gmail.com",
				NormalizedEmail = "ADMIN@GMAIL.COM",
				EmailConfirmed = true,
				SecurityStamp = Guid.NewGuid().ToString(),
				ProfilePicture = null,
				FullName = "AdminFullName"
			};
			AdminUser.PasswordHash = hasher.HashPassword(AdminUser, "Admin123!");

			var ClientUser1 = new AppUser
			{
				Id = 2,
				UserName = "Client1UserName",
				NormalizedUserName = "Client1USERNAME",
				Email = "Client1@Gmail.com",
				NormalizedEmail = "Client1@GMAIL.COM",
				EmailConfirmed = true,
				SecurityStamp = Guid.NewGuid().ToString(),
				ProfilePicture = null,
				FullName = "نام و نام خانوادگی کاربر یک"
			};
			ClientUser1.PasswordHash = hasher.HashPassword(ClientUser1, "Client123!");

			var Client2User = new AppUser
			{
				Id = 3,
				UserName = "Client2UserName",
				NormalizedUserName = "CLIENT2USERNAME",
				Email = "Client2@Gmail.com",
				NormalizedEmail = "CLIENT2@GMAIL.COM",
				EmailConfirmed = true,
				SecurityStamp = Guid.NewGuid().ToString(),
				ProfilePicture = null,
				FullName = "نام و نام خانوادگی کاربر دو"
			};

			Client2User.PasswordHash = hasher.HashPassword(Client2User, "Client2@123");

			var Expert1User = new AppUser
			{
				Id = 4,
				UserName = "Expert1UserName",
				NormalizedUserName = "EXPERT1USERNAME",
				Email = "Expert1@Gmail.com",
				NormalizedEmail = "EXPERT1@GMAIL.COM",
				EmailConfirmed = true,
				SecurityStamp = Guid.NewGuid().ToString(),
				ProfilePicture = null,
				FullName = "نام  و نام خانوادگی کارشناس شماره یک"
			};

			Expert1User.PasswordHash = hasher.HashPassword(Expert1User,"Expert1@123!");

			var Expert2User = new AppUser
			{
				Id = 5,
				UserName = "Expert2UserName",
				NormalizedUserName = "EXPERT2USERNAME",
				Email = "Expert2@Gmail.com",
				NormalizedEmail = "EXPERT2@GMAIL.COM",
				EmailConfirmed = true,
				SecurityStamp = Guid.NewGuid().ToString(),
				ProfilePicture = null,
				FullName = "نام  و نام خانوادگی کارشناس دو"
			};

			
			Expert2User.PasswordHash = hasher.HashPassword(Expert2User, "Expert2@123!");


			builder.
				Entity<AppUser>()
				.HasData(AdminUser,ClientUser1,Client2User,Expert1User,Expert2User);

			var AdminRoleId = 1;
			var ClientRoleId = 2;
			var ExpertRoleId = 3;

			builder.Entity<IdentityRole<int>>().HasData(
				new IdentityRole<int> { Id = AdminRoleId, Name = "Admin", NormalizedName = "ADMIN" },
				new IdentityRole<int> { Id = ClientRoleId, Name = "Client", NormalizedName = "CLIENT" },
				new IdentityRole<int> { Id = ExpertRoleId, Name = "Expert", NormalizedName = "EXPERT" }
			);

			
			builder.Entity<IdentityUserRole<int>>().HasData(
				new IdentityUserRole<int> { UserId = 1, RoleId = AdminRoleId },
				new IdentityUserRole<int> { UserId = 2, RoleId = ClientRoleId },
				new IdentityUserRole<int> { UserId = 3, RoleId = ClientRoleId },
				new IdentityUserRole<int> { UserId = 4, RoleId = ExpertRoleId },
				new IdentityUserRole<int> { UserId = 5, RoleId = ExpertRoleId }
			);
		}
	}
}
