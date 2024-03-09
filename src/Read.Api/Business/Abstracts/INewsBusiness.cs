using Read.Api.Business.Dto;

namespace Read.Api.Business.Abstracts;

public interface INewsBusiness
{
    Task<NewsDto> Get(int id);
    Task<IList<NewsDto>> GetAll();
}