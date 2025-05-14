using Microsoft.EntityFrameworkCore;

namespace WebApiDotNetCore9.DataBase
{
    public class VideoGameDbContext : DbContext
    {
        public VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : base(options)
        {
        }
        public DbSet<VideoGamecs> VideoGames { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VideoGamecs>().HasData(

            new VideoGamecs { Id = 1, Title = "The Legend of Zelda: Breath of the Wild", Platform = "Nintendo Switch", Developer = "Nintendo", Publisher = "Nintendo" },
            new VideoGamecs { Id = 2, Title = "The Witcher 3: Wild Hunt", Platform = "PC", Developer = "CD Projekt Red", Publisher = "CD Projekt" },
            new VideoGamecs { Id = 3, Title = "Dark Souls III", Platform = "PC", Developer = "FromSoftware", Publisher = "Bandai Namco Entertainment" });
        }
    }
    
}
