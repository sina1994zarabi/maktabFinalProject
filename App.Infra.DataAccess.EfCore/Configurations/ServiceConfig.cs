﻿using App.Domain.Core.Entities.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.EfCore.Configurations
{
    public class ServiceConfig : IEntityTypeConfiguration<Service>
	{
		public void Configure(EntityTypeBuilder<Service> builder)
		{
			builder.HasOne(s => s.Subcategory)
				   .WithMany(sc => sc.Services)
				   .HasForeignKey(s => s.SubCategoryId);

			builder.HasMany(s => s.ServiceRequests)
				   .WithOne(sr => sr.Service);

			builder.HasMany(s => s.Experts)
				   .WithMany(sp => sp.Services);
			

			builder.HasData( 
			new Service
			{
				Id = 1,
				Title = "سرویس عادی نظافت",
				Description = "توضیحات سرویس عادی نظافت ",
				SubCategoryId = 1,
				Price = 1000
			},
            new Service
            {
                Id = 2,
                Title = "کارواش سیار",
                Description = "توضیحات کارواش سیار ",
                SubCategoryId = 2,
                Price = 500
            });
		}
	}
}
