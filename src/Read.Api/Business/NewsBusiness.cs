using Read.Api.Business.Abstracts;
using Read.Api.Business.Dto;
using Read.Api.Data.Repository.Abstracts;

namespace Read.Api.Business;

public class NewsBusiness : INewsBusiness
{
    private readonly IRepository<Entities.News> _newsRepository;
    
    public NewsBusiness(IRepository<Entities.News> newsRepository)
    {
        _newsRepository = newsRepository;
    }
    
    public async Task<NewsDto> Get(int id)
    {
        var data = _newsRepository.GetAll().FirstOrDefault(x => x.NewsId == id);
        if (data == null)
            return null;
        
        return new NewsDto
        {
            Id = data.NewsId,
            Title = data.Title,
            ShortDesc = data.ShortDesc,
            LongDesc = data.LongDesc,
            Published = data.Published
        };
    }
    
    public async Task<IList<NewsDto>> GetAll()
    {
        return _newsRepository.GetAll().Select(x => new NewsDto
        {
            Id = x.NewsId,
            Title = x.Title,
            ShortDesc = x.ShortDesc,
            LongDesc = x.LongDesc,
            Published = x.Published
        }).ToList();
    }
}