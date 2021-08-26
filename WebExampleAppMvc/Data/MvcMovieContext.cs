using Microsoft.EntityFrameworkCore;

namespace WebExampleAppMvc.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<Models.MovieEntity> MovieEntity { get; set; }
    }
}
