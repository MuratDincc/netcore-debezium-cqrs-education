using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Write.Api.Business.Abstracts;
using Write.Api.Models.Request;
using Write.Api.Models.Response;

namespace Write.Api.Controllers;

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
    /// Create News
    /// </summary>
    /// <param name="request">Request Model</param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(CreateNewsResponse), 200)]
    public async Task<IActionResult> Post([FromBody] CreateNewsRequest request)
    {
        return Ok(await _newsBusiness.CreateNews(request));
    }

    /// <summary>
    /// Update News
    /// </summary>
    /// <param name="id">News Id</param>
    /// <param name="request">Request Model</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> Patch([FromRoute] int id, [FromBody] UpdateNewsRequest request)
    {
        await _newsBusiness.UpdateNews(id, request);
        
        return Ok();
    }

    /// <summary>
    /// Delete News
    /// </summary>
    /// <param name="id">News Id</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _newsBusiness.DeleteNews(id);

        return Ok();
    }
    
    #endregion
}
