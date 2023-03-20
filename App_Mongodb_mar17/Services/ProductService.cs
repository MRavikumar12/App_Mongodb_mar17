using App_Mongodb_mar17.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace App_Mongodb_mar17.Services
{
    public class ProductService
    {
        private readonly IMongoCollection<Product> _products;
        public ProductService(IOptions<ProductStoreSetting> productStoreSetting)
        {
            var mongoClient=new MongoClient(productStoreSetting.Value.ConnectionString);

            var mongodb=mongoClient.GetDatabase(productStoreSetting.Value.DatabaseName);

            _products = mongodb.GetCollection<Product>(productStoreSetting.Value.ProductCollectionName);

        }

        public async Task<List<Product>>GetProducts()=>
            await _products.Find(_=>true).ToListAsync();

        public async Task<Product>GetProductById(string id)=>
            await _products.Find(x=>x.id== id).FirstOrDefaultAsync();

        public async Task<Product>GetByName(string category)=>
            await _products.Find(x=> x.category == category).FirstOrDefaultAsync();
        public async Task AddProduct(Product product)=>
            await _products.InsertOneAsync(product);

        public async Task UpdateProduct(string id, Product product) =>
            await _products.ReplaceOneAsync(x => x.id == id,product);

        public async Task DeleteProduct(string id)=>
            await _products.DeleteOneAsync(x=>x.id== id);

    }
}
