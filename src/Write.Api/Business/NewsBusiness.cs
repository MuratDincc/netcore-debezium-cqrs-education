using Write.Api.Business.Abstracts;
using Write.Api.Data;
using Write.Api.Models.Request;
using Write.Api.Models.Response;

namespace Write.Api.Business;

public class NewsBusiness : INewsBusiness
{
    private readonly NewsDbContext _dbContext;
    
    public NewsBusiness(NewsDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<CreateNewsResponse> CreateNews(CreateNewsRequest request)
    {
        var news = new Entities.News
        {
            Title = request.Title,
            ShortDesc = request.ShortDesc,
            LongDesc = request.LongDesc,
            Published = request.Published
        };
        
        _dbContext.News.Add(news);
        await _dbContext.SaveChangesAsync();
        
        return new CreateNewsResponse
        {
            Id = news.Id
        };
    }
    
    public async Task UpdateNews(int id, UpdateNewsRequest request)
    {
        var news = await _dbContext.News.FindAsync(id);
        if (news == null)
            throw new Exception("News not found");
        
        news.Title = request.Title;
        news.ShortDesc = request.ShortDesc;
        news.LongDesc = request.LongDesc;
        news.Published = request.Published;
        
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task DeleteNews(int id)
    {
        var news = await _dbContext.News.FindAsync(id);
        if (news == null)
            throw new Exception("News not found");
        
        _dbContext.News.Remove(news);
        await _dbContext.SaveChangesAsync();
    }
}