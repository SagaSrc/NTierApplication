using FluentValidation;
using NTierApplication.DAL;
using NTierApplication.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApplication.BLL.Services.Validations
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Need Name");
          //  RuleFor(x => x.Name).Must(CategoryMustNotExist).WithMessage(" Must Need Category Name");
        }

        //public bool CategoryMustNotExist(string categoryname)
        //{
        //    using (PrjObjectContext context = new PrjObjectContext())
        //    {
        //       return !context.get<Category>.Any(x => x.Name == categoryname);
        //    }
        //}
    } 
}
