using Write.Api.Data;

namespace Write.Api.Middleware;

public class DatabaseInstallerMiddleware
{
    private readonly RequestDelegate _next;
    
    public DatabaseInstallerMiddleware(RequestDelegate next)
    {
        _next = next;
    }
 
    public async Task Invoke(HttpContext httpContext, NewsDbContext dbContext)
    {
        await dbContext.Database.EnsureCreatedAsync();
        await _next.Invoke(httpContext);
    }
}