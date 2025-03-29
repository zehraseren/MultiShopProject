using MS.Comment.Entities;
using Microsoft.EntityFrameworkCore;

namespace MS.Comment.Context;

public class CommentContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1436;initial Catalog=MSCommentDb;User=sa;Password=123456aA*;TrustServerCertificate=True");
    }

    public DbSet<UserComment> UserComments { get; set; }
}
