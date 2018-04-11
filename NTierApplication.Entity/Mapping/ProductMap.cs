using NTierApplication.Entity.Entities;

namespace NTierApplication.Entity.Mapping
{
    public class ProductMap: AllEntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            HasKey<int>(x => x.Id);
            Property(x => x.Name).HasMaxLength(100);
            //null geçilebilir.
            Property(x => x.Price).IsOptional();
            Property(x => x.Stock).IsRequired();

            //category ile product arasında bire çok ilişki var fakat categoryıd foreign key alanı zorunlu alan değil boş geçilebilir.

            HasOptional(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);



        }
    }
}
