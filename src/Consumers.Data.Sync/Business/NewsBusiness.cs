using Consumers.Data.Sync.Business.Abstracts;
using Consumers.Data.Sync.Business.Dto;
using Consumers.Data.Sync.Data.Repository.Abstracts;

namespace Consumers.Data.Sync.Business;

public class NewsBusiness : INewsBusiness
{
    private readonly IRepository<Entities.News> _newsRepository;
    
    public NewsBusiness(IRepository<Entities.News> newsRepository)
    {
        _newsRepository = newsRepository;
    }
    
    public Task<bool> Create(CreateNewsDto request)
    {
        try
        {
            _newsRepository.Insert(new Entities.News
            {
                NewsId = request.NewsId,
                Title = request.Title,
                ShortDesc = request.ShortDesc,
                LongDesc = request.LongDesc,
                Published = request.Published,
                CreatedOnUtc = DateTimeOffset.UtcNow
            });
            
            return Task.FromResult(true);
        }
        catch (Exception e)
        {
            return Task.FromResult(false);
        }
    }

    public Task<bool> Update(int id, UpdateNewsDto request)
    {
        try
        {
            var data = _newsRepository.GetAll().Where(x => x.NewsId == id).FirstOrDefault();
            if (data is null)
                return Task.FromResult(false);
            
            data.Title = request.Title;
            data.ShortDesc = request.ShortDesc;
            data.LongDesc = request.LongDesc;
            data.Published = request.Published;
            data.UpdatedOnUtc = DateTimeOffset.UtcNow;
            
            _newsRepository.Update(data);
            
            return Task.FromResult(true);
        }
        catch (Exception e)
        {
            return Task.FromResult(false);
        }
    }

    public Task<bool> Delete(int id)
    {
        try
        {
            var data = _newsRepository.GetAll().Where(x => x.NewsId == id).FirstOrDefault();
            if (data is null)
                return Task.FromResult(false);
            
            _newsRepository.Delete(data.Id);
            
            return Task.FromResult(true);
        }
        catch (Exception e)
        {
            return Task.FromResult(false);
        }
    }
}