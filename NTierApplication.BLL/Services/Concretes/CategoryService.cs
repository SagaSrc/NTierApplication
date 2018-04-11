using NTierApplication.BLL.Dtos;
using NTierApplication.BLL.Services.Validations;
using NTierApplication.DAL.Base;
using NTierApplication.Entity.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NTierApplication.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        
        private readonly IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public ResultModel<Category> Create(Category model)
        {
            var validator = new CategoryValidator().Validate(model);

            if (validator.IsValid)
            {
                _categoryRepository.Insert(model);

                return new ResultModel<Category>
                {
                    Errors = null,
                    IsValid = true,
                    Message = "Category added!"
                };
            }

            return new ResultModel<Category>
            {
                Errors = validator.Errors.Select(x => x.ErrorMessage).ToList(),
                IsValid = false,
                Message = "Failed"
            };

        } 

        public object GetById(int categoryId)
        {
            object obj =  _categoryRepository.GetById(categoryId);
            return obj;

        }

        public List<Category> GetAllList()
        {
            List<Category> obj =null; 
            var query = _categoryRepository.Table;  
            obj=query.ToList();
            return obj;
        }


    }
}
