#region Namespaces ...
using DataModel.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion


namespace DataModel.DAL
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("ProductContext")
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Token> TokenEntity { get; set; }
        public DbSet<User> User { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
