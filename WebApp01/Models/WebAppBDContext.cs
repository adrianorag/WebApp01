namespace WebApp01.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WebAppBDContext : DbContext
    {
        public WebAppBDContext()
            : base("name=WebAppBDContext")
        {
            
        }

        public DbSet<Usuario> Usuario { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
