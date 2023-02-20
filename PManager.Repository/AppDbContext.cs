using Microsoft.EntityFrameworkCore;
using PManager.Core;
using PManager.Repository.Configurations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PManager.Repository
{
    public class AppDbContext:DbContext
    {
        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        //{
        //    //ProductFeature dbSet e eklemeden Product üzerinden erişlebilir
        //    //BestPractes açısından doğru olan bu şekilde yapılmaktadır.
        //    //var p = new Product()
        //    //{
        //    //    ProductFeature = new ProductFeature() { }
        //    //};

        //}

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public  DbSet<Product> Products { get; set; }

        //public DbSet<ProductFeature> ProductFeatures { get; set; }  


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            //entity core u haberdar ediyoruz
            //burada tüm configure dosyalarını tanıtır.burada otomatik tüm classları tanıtıyoruz.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //burada tek tek classları tanıtmamız lazım
            // modelBuilder.ApplyConfiguration(new ProductConfiguration());

            //modelBuilder.Entity<ProductFeature>().HasData(
            //new ProductFeature()
            //{
            //    Id = 1,
            //    Color = "Mavi",
            //    Height = 100,
            //    Widht = 200,
            //    ProductId = 1
            //},
            //  new ProductFeature()
            //  {
            //      Id = 2,
            //      Color = "Sarı",
            //      Height = 120,
            //      Widht = 118,
            //      ProductId = 1
            //  }
            //);
              
            base.OnModelCreating(modelBuilder); 
        }
    }
}
