using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PManager.Repository.Seed
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData
                (
                new Product
                {
                    id = 1,
                    CategoryId = 1,
                    Name = "Kalem 1",
                    Price = 100,
                    Stock = 20,
                    CreatedDate = DateTime.Now
                },
                new Product
                {
                    id = 2,
                    Name = "Kalem 2",
                    CategoryId = 1,
                    Price = 100,
                    Stock = 20,
                    CreatedDate = DateTime.Now
                },
                new Product
                {
                    id = 3,
                    Name = "Kalem 3",
                    CategoryId = 1,
                    Price = 500,
                    Stock = 60,
                    CreatedDate = DateTime.Now
                },
                new Product
                {
                    id = 4,
                    Name = "Kitap 1",
                    CategoryId = 2,
                    Price = 500,
                    Stock = 60,
                    CreatedDate = DateTime.Now
                },
                new Product
                {
                    id = 5,
                    Name = "Kitap 2",
                    CategoryId = 2,
                    Price = 500,
                    Stock = 60,
                    CreatedDate = DateTime.Now
                }

                );
        }
    }
}
