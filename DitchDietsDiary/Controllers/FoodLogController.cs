using DitchDietsDiary.Core;
using DitchDietsDiary.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DitchDietsDiary.Controllers;

[ApiController]
[Route("api/foodLog")]
public class FoodLogController : ControllerBase
{

    private readonly ILogger<FoodLogController> _logger;
    private readonly IFoodLoggingRepository _foodLoggingRepository;

    public FoodLogController(ILogger<FoodLogController> logger, IFoodLoggingRepository foodLoggingRepository)
    {
        _logger = logger;
        _foodLoggingRepository = foodLoggingRepository;
    }

    [HttpPost(Name = "log-meal-entry")]
    public IActionResult LogMealEntry([FromBody] FoodEntryModel foodEntryModel)
    {
        if (foodEntryModel == null)
        {
            return BadRequest("Food entry cannot be null.");
        }

        _foodLoggingRepository.SaveMealEntry(foodEntryModel);
        return Ok("Food entry logged successfully!");
    }
}
