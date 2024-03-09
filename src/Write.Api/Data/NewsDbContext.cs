using Microsoft.EntityFrameworkCore;

namespace Write.Api.Data;

public class NewsDbContext : DbContext
{
    // dotnet ef migrations add v1.0.0 -c Write.Api.Data.NewsDbContext -p ../Write.Api
    // dotnet ef migrations script 0 v1.0.0 -c Write.Api.Data.NewsDbContext -p ../Write.Api

    public NewsDbContext(DbContextOptions<NewsDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DbSet<Entities.News> News { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("public");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NewsDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}
