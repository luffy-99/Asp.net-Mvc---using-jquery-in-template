﻿using Data.Infrastructủe;
using Data.Repositories;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IProductService
    {
        Product Add(Product product);
        void Update(Product product);
        Product Delete(int id);
        Product Delete(Product product);
        IEnumerable<Product> GetAll(string[] includes= null);
        Product GetById(int id);
        List<string> GetNameProduct();
        IEnumerable<Product> DealsProduct();
        IEnumerable<Product> LatestProduct();
        IEnumerable<Product> PickForYou();
        Product GetByName(string name);
        void Save();
    }
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private IUnitOfWork _unitOfWork;
        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this._productRepository = productRepository;
            this._unitOfWork = unitOfWork;
        }
        public Product Add(Product product)
        {
            return _productRepository.Add(product);
        }

        public IEnumerable<Product> DealsProduct()
        {
            return _productRepository.DealsProduct();
        }

        public Product Delete(int id)
        {
            return _productRepository.Delete(id);
        }

        public Product Delete(Product product)
        {
            return _productRepository.Delete(product);
        }

        public IEnumerable<Product> GetAll(string[] includes = null)
        {
            return _productRepository.GetAll(includes);
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public Product GetByName(string name)
        {
            return _productRepository.GetByName(name);
        }

        public List<string> GetNameProduct()
        {
            return _productRepository.GetNameProduct();
        }

        public IEnumerable<Product> LatestProduct()
        {
            return _productRepository.LatestProduct();
        }

        public IEnumerable<Product> PickForYou()
        {
            return _productRepository.PickForYou();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }
    }
}
