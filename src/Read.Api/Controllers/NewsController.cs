using Microsoft.AspNetCore.Mvc;
using Read.Api.Business.Abstracts;
using Read.Api.Business.Dto;

namespace Read.Api.Controllers;

/// <summary>
/// News
/// </summary>
[Route("api/v1/news")]
public class NewsController : ControllerBase
{
    #region Fields

    private readonly INewsBusiness _newsBusiness;

    #endregion
    
    #region Ctor
    
    public NewsController(INewsBusiness newsBusiness)
    {
        _newsBusiness = newsBusiness;
    }

    #endregion
    
    #region Methods
    
    /// <summary>
    /// Get News By Id
    /// </summary>
    /// <param name="id">Id</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(NewsDto), 200)]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _newsBusiness.Get(id));
    }
    
    /// <summary>
    /// Get News
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<NewsDto>), 200)]
    public async Task<IActionResult> Get()
    {
        return Ok(await _newsBusiness.GetAll());
    }
    
    #endregion
}
