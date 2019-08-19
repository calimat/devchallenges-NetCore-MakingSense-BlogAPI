using System;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Model
{
    public class PostContext : DbContext
    {
        public PostContext(DbContextOptions<PostContext> options)
            : base(options)
        {
        }

        public DbSet<PostEntity> Posts { get; set; }

       
    }
}
