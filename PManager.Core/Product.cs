using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PManager.Core
{
    public class Product:BaseEntity
    {
        public Product() { }
        public Product(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(Name)); 
          
        }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ProductFeature ProductFeature  { get; set; }

}
}
