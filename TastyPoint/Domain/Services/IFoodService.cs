using TastyPoint.API.TastyPoint.Domain.Models;
using TastyPoint.API.TastyPoint.Domain.Services.Communication;

namespace TastyPoint.API.TastyPoint.Domain.Services;

public interface IFoodService
{
    Task<IEnumerable<Food>> ListFoodsAsync();
    Task<FoodResponse> GetFoodByFoodIdAsync(int foodId);
    Task<FoodResponse> AddFoodAsync(Food newFood);
    Task<FoodResponse> UpdateFoodAsync(int foodId, Food updatedFood);
    Task<FoodResponse> DeleteFoodAsync(int foodId);
}


