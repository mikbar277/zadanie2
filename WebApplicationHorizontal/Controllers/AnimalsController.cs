using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private IAnimalsService _animalsService;

    public AnimalsController(IAnimalsService animalsService)
    {
        _animalsService = animalsService;
    }
    
    // Endpoint used to return list of animals.
    [HttpGet]
    public IActionResult GetAnimals(string orderBy = "")
    {
        var animals = _animalsService.GetAnimals(orderBy);
        return Ok(animals);
    }
}