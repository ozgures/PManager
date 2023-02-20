using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PManager.Repository.Configurations
{
    internal class ProductFeatureConfiguration : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            //builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            //builder.Property(x => x.Stock).IsRequired();
            //builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");

            //bir pFeature ın bir product ı olabilir,
            //bir product ın bir pFeature sı olabilir
            //foreignkey i ProductFeature üzerindeki ProductId olacaktır.
            builder.HasOne(x=>x.Product).WithOne(x => x.ProductFeature).HasForeignKey<ProductFeature>(x=>x.ProductId);
            builder.ToTable("ProductFeatures");
        }
    }
}
