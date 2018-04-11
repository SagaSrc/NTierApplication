using NTierApplication.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTierApplication.BLL.Dtos;
using NTierApplication.DAL.Base;
using NTierApplication.Entity.Entities;
using NTierApplication.BLL.Services.Validations; 
 

namespace NTierApplication.BLL.Services
{   
    public class ProductService : IProductService
    {
       
        private readonly IRepository<Product> _productRepository;
     

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
         

        public void Delete(int id)
        {
            var obj = _productRepository.GetById(id);
            _productRepository.Delete(obj);

        }

        public List<Product> GetProductsByCategoryId(int Id)
        { 
            var query = from p in _productRepository.Table
                        where p.CategoryId == Id
                        select p;
            var products = query.ToList();
            
            return products;

        }

        public List<Product> GetAllProducts( )
        {
            var query = from p in _productRepository.Table 
                        select p;
            var products = query.ToList();

            return products;

        }
     

        public ResultModel<Product> ProductSave(Product model)
        {
            var validator = new ProductValidator().Validate(model);

            if (validator.IsValid)
            {
                _productRepository.Insert(model);
                 
                return new ResultModel<Product>
                {
                    Errors = null,
                    IsValid = true,
                    Message = "Record succeeded"
                };
            }

            return new ResultModel<Product>
            {
                Errors = validator.Errors.Select(x => x.ErrorMessage).ToList(),
                IsValid = false,
                Message = "Record"
            };
        }
    }
}
