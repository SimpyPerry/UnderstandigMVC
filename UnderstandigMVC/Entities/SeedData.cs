using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderstandigMVC.Entities
{
    public static class SeedData
    {


        public static void Seed(this MvcContext _mvcContext)
        {
           

            if (!_mvcContext.Products.Any())
            {
                var products = new List<Product>()
                {
                    new Product()
                    {
                        Title="Baby ænder",
                        Category="Paint on Paint",
                        Artist="Anders And",
                        ArtistBirth=DateTime.UtcNow,
                        ArtistDeath=DateTime.UtcNow,
                        ArtistId = "Randers Drengen"
                    },

                     new Product()
                    {
                        Title="Baby Mænd",
                        Category="Paint on Paint",
                        Artist="Andersine And",
                        ArtistBirth=DateTime.UtcNow,
                        ArtistDeath=DateTime.UtcNow,
                        ArtistId = "Randers Pigen"
                    },

                      new Product()
                    {
                        Title="Baby katte",
                        Category="Paint on Sand",
                        Artist="Anders And",
                        ArtistBirth=DateTime.UtcNow,
                        ArtistDeath=DateTime.UtcNow,
                        ArtistId = "Randers Drengen"
                    },

                       new Product()
                    {
                        Title="Baby Fluer",
                        Category="Paint on water",
                        Artist="Robert Dølhus",
                        ArtistBirth=DateTime.UtcNow,
                        ArtistDeath=DateTime.UtcNow,
                        ArtistId = "Mie Miaw"
                    },
                };
                _mvcContext.Products.AddRange(products);

                
                

                _mvcContext.SaveChanges();
            }
            return;
        }
        
    }
}
