using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using NetCoreMicroservices.API.Configurations;
using NetCoreMicroservices.API.Models;
using System.Collections.Generic;

namespace NetCoreMicroservices.API.Data
{
    /// <summary>
    /// Db context for product's manipulations.
    /// </summary>
    public class ProductContext
    {
        /// <summary>
        /// Paged collection of <seealso cref="IConfiguration"/> objects.
        /// </summary>
        /// <param name="configuration"></param>
        public ProductContext(IConfiguration configuration)
        {
            var dbSettings = configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();
            var client = new MongoClient(dbSettings.ConnectionString);
            var databases = client.GetDatabase(dbSettings.DatabaseName);
            Products = databases.GetCollection<Product>(dbSettings.CollectionName);
            SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; set; }

        /// <summary>
        /// Seed data of static products.
        /// </summary>
        /// <param name="productCollection">MongoDb collection</param>
        private static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();

            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }


        /// <summary>
        /// Static list of products.
        /// </summary>
        /// <returns></returns>
        private static List<Product> GetPreconfiguredProducts()
        {
            return new List<Product>
            {
                new Product()
                {
                    Name = "IPhone",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-1.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "Samsung 10",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-2.png",
                    Price = 840.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "Huawei Plus",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-3.png",
                    Price = 650.00M,
                    Category = "White Appliances"
                },
                new Product()
                {
                    Name = "Xiaomi Mi 9",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-4.png",
                    Price = 470.00M,
                    Category = "White Appliances"
                },
                new Product()
                {
                    Name = "HTC U11+ Plus",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-5.png",
                    Price = 380.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "LG G7 ThinQ New8",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-6.png",
                    Price = 240.00M,
                    Category = "Home Kitchen"
                }
            };
        }
    }
}
