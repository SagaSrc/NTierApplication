using NTierApplication.Entity.Entities;

namespace NTierApplication.Entity.Mapping
{
    public class CategoryMap : AllEntityTypeConfiguration<Category>
    { 
        public CategoryMap()
        {
            HasIndex<int>(x => x.Id);
            Property(x => x.Name)
                .IsRequired() //IsFixed  
                .IsUnicode()
                .HasMaxLength(50);  //nvarchar50 not null  

            Property(x => x.Name)
                .HasColumnName("Product Category");

        }
    }
}
