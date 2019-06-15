using Data.Infrastructủe;
using Data.Repositories;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IProductCategoryService
    {
        ProductCategory Add(ProductCategory product);
        void Update(ProductCategory product);
        ProductCategory Delete(int id);
        ProductCategory Delete(ProductCategory productCategory);
        IEnumerable<ProductCategory> GetAll(string[] includes = null);
        ProductCategory GetById(int id);
        List<string> GetNameCategory();
        void Save();
    }
    public class ProductCategoryService : IProductCategoryService
    {
        private IProductCategoryRepository productCategoryRepository;
        private IUnitOfWork unitOfWork;
        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IUnitOfWork unitOfWork)
        {
            this.productCategoryRepository = productCategoryRepository;
            this.unitOfWork = unitOfWork;
        }
        public ProductCategory Add(ProductCategory product)
        {
            return productCategoryRepository.Add(product);
        }

        public ProductCategory Delete(int id)
        {
            return productCategoryRepository.Delete(id);
        }

        public ProductCategory Delete(ProductCategory productCategory)
        {
            return productCategoryRepository.Delete(productCategory);
        }

        public IEnumerable<ProductCategory> GetAll(string[] includes = null)
        {
            return productCategoryRepository.GetAll(includes);
        }

        public ProductCategory GetById(int id)
        {
            return productCategoryRepository.GetById(id);
        }

        public List<string> GetNameCategory()
        {
            return productCategoryRepository.GetNameCategory();
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public void Update(ProductCategory product)
        {
            productCategoryRepository.Update(product);
        }
    }
}
