using Microsoft.AspNetCore.Mvc;
using SeafoodSharp.Server.DAL;
using SeafoodSharp.Shared;

namespace SeafoodSharp.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantMenuController : ControllerBase
{
    private readonly ILogger<RestaurantMenuController> _logger;

    public RestaurantMenuController(ILogger<RestaurantMenuController> logger)
    {
        _logger = logger;
    }

    [HttpGet("GetCompleteMenu")]
    public RestaurantCompleteMenu GetCompleteMenu()
    {
        RestaurantMenuDAO dao = new();
        return dao.GetCompleteMenu();
    }
}