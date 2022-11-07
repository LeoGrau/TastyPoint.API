using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TastyPoint.API.TastyPoint.Domain.Models;
using TastyPoint.API.TastyPoint.Domain.Services;
using TastyPoint.API.TastyPoint.Resources.ShowResources;

namespace TastyPoint.API.TastyPoint.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces("application/json")]
[SwaggerTag("Create, read, update and delete food.")]
public class FoodController: ControllerBase
{
    private readonly IFoodService _foodService;
    private readonly IMapper _mapper;

    public FoodController(IFoodService foodService, IMapper mapper)
    {
        _foodService = foodService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<FoodResource>> GetAllFoods()
    {
        var foods = await _foodService.ListFoodsAsync();
        var resourcesFood = _mapper.Map<IEnumerable<Food>,IEnumerable<FoodResource>>(foods); 
        return resourcesFood;
    }

}