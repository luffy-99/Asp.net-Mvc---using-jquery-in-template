using Data.Infrastructủe;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        List<string> GetNameProduct();
        IEnumerable<Product> DealsProduct();
        IEnumerable<Product> LatestProduct();
        IEnumerable<Product> PickForYou();
        IEnumerable<Product> GetByCategory(int idCategory);
        Product GetByName(string name);
    }
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private readonly IDbSet<Product> dbSet;
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {
            dbSet = DbContext.Set<Product>();
        }

        public IEnumerable<Product> DealsProduct()
        {
            return dbSet.Where(x => x.PromotionPrice != null).OrderByDescending(x => x.UpdatedDate);
        }

        public List<string> GetNameProduct()
        {
            var products = dbSet;
            var nameProducts = new List<string>();
            foreach (var product in products)
            {
                nameProducts.Add(product.Name);
            }
            return nameProducts;
        }

        public IEnumerable<Product> LatestProduct()
        {
            return (from p in dbSet
                           orderby p.CreatedDate descending
                           select p).Take(6);
        }
        public IEnumerable<Product> PickForYou()
        {
            return (from p in dbSet orderby p.ViewCount descending select p).Take(4);
        }
        public Product GetByName(string name)
        {
            return dbSet.Where(x=>x.Name == name).SingleOrDefault();
        }

        public IEnumerable<Product> GetByCategory(int idCategory)
        {
            return dbSet.Where(x => x.CategoryID == idCategory);
        }
    }
}
