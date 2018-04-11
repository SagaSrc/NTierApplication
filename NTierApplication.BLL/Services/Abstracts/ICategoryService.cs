using NTierApplication.BLL.Dtos;
using NTierApplication.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApplication.BLL.Services
{
    public interface ICategoryService
    {
        ResultModel<Category> Create(Category model);
        object  GetById(int categoryId);
        List<Category>  GetAllList();
    }
}
