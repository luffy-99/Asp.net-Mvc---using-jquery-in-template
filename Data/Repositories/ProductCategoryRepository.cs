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
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        List<string> GetNameCategory();
    }
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        private readonly IDbSet<ProductCategory> dbSet;
        public ProductCategoryRepository(IDbFactory dbFactory): base(dbFactory)
        {
            dbSet = DbContext.Set<ProductCategory>();
        }

        public List<string> GetNameCategory()
        {
            var categories = dbSet.AsQueryable();
            var nameCategories = new List<string>();
            foreach (var category in categories)
            {
                nameCategories.Add(category.Name);
            }
            return nameCategories;
        }
    }
}
