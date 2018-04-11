using NTierApplication.BLL.Dtos;
using NTierApplication.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApplication.BLL.Services
{
    // eğer yaptığınız işte herhangi bir iş kuralı mevcut ise bu iş kuralı validasyon,transaction,alt yapı işlemleri, loglama, hata yakalama veya msj atma vs.. gibi işlemler ise ve aynı zamanda yapacağınız iş içinde birden fazla repository kullanmanız gerekirse ozaman bu hizmeti bize servisin vermesi daha mantıklıdır. Onun dışında servis üzerinden her işlemi yapmak zahmetlidir ve zaman kaybına yol açar
    //burada iş gereği ne kullanmam gerekiyor ise interface'i mi o şekilde güncelliyorum. O yüzden belirgin bir operasyon tanımı servis için yoktur.

    public interface IProductService
    {
        ResultModel<Product> ProductSave(Product model);
        List<Product> GetProductsByCategoryId(int Id);
        List<Product> GetAllProducts();
        void Delete(int id);
    }
}
