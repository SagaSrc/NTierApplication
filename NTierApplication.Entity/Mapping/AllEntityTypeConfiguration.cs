using System.Data.Entity.ModelConfiguration;

namespace NTierApplication.Entity.Mapping
{
    /// <summary>
    /// Entity configuration
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AllEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : class
    {
        /// <summary>
        /// Ctor
        /// </summary>
        protected AllEntityTypeConfiguration()
        {
            PostInitialize();
        }

        /// <summary>
        /// Developers can override this method in custom partial classes
        /// in order to add some custom initialization code to constructors
        /// </summary>
        protected virtual void PostInitialize()
        {
            
        }
    }
}