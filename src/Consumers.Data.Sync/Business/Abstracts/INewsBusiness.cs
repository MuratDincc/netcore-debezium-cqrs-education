using Consumers.Data.Sync.Business.Dto;

namespace Consumers.Data.Sync.Business.Abstracts;

public interface INewsBusiness
{
    Task<bool> Create(CreateNewsDto request);
    Task<bool> Update(int id, UpdateNewsDto request);
    Task<bool> Delete(int id);
}