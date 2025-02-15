using App.Domain.Core.Entities.User;
using App.Domain.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.EfCore.Configurations
{
    public class ExpertConfig : IEntityTypeConfiguration<Expert>
	{
		public void Configure(EntityTypeBuilder<Expert> builder)
		{

			builder.HasMany(sp => sp.ServiceOfferings)
				   .WithOne(so => so.Expert);


			builder.HasData(
				new Expert
				{
					Id = 1,
					FullName = "نام و نام خانوادگی کارشناس شماره یک",
					PhoneNumber = "09xxxxxxxxx",
					Gender = Gender.male,
					AppUserId = 4
				},
				new Expert
				{
					Id = 2,
					FullName = "نام و نام خانوادگی کارشناس شماره دو",
					PhoneNumber = "09yyyyyyyyy",
					Gender = Gender.male,
					AppUserId = 5
				}
				);
		}
	}
}
