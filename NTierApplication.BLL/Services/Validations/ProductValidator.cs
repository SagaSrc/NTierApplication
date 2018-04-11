using FluentValidation;
using NTierApplication.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApplication.BLL.Services.Validations
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Need Name");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price Need >0");
            

        }

        public bool Kural(decimal fiyat)
        {
           
            return true;
        }

       
        public bool KompleksKural(Product model)
        {
            if (model.Name=="A" || model.Price>10 )
            {
                return true;
            }

            return false;
        }

    }
}
