namespace ForumApp.Data
{
    using Microsoft.EntityFrameworkCore;

    using Configuration;
    using Models;

    //using System.Collections.Generic;
    //using System.Reflection.Emit;

    public class ForumDbContext : DbContext
    {
        public ForumDbContext(DbContextOptions<ForumDbContext> options)
        : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
