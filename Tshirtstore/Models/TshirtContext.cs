namespace Tshirtstore.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TshirtContext : DbContext
    {
        // Your context has been configured to use a 'TshirtContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Tshirtstore.Models.TshirtContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'TshirtContext' 
        // connection string in the application configuration file.
        public TshirtContext()
            : base("name=TshirtContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Order> Order { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}