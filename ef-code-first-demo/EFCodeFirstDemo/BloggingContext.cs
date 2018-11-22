namespace EFCodeFirstDemo
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BloggingContext : DbContext
    {
        public BloggingContext(string s)
        {
            this.Database.Connection.ConnectionString = s;
        }

        public virtual DbSet<blogs> blogs { get; set; }
        public virtual DbSet<posts> posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<blogs>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<blogs>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<posts>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<posts>()
                .Property(e => e.Content)
                .IsUnicode(false);
        }
    }
}
