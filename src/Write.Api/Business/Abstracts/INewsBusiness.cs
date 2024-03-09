using Write.Api.Models.Request;
using Write.Api.Models.Response;

namespace Write.Api.Business.Abstracts;

public interface INewsBusiness
{
    Task<CreateNewsResponse> CreateNews(CreateNewsRequest request);
    Task UpdateNews(int id, UpdateNewsRequest request);
    Task DeleteNews(int id);
}