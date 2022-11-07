using TastyPoint.API.TastyPoint.Domain.Models;

namespace TastyPoint.API.TastyPoint.Domain.Repositories;

public interface IFoodRepository
{
    Task<IEnumerable<Food?>> ListFoodAsync();
    Task<Food> GetFoodByFoodIdAsync(int foodId);
    Task AddFoodAsync(Food newFood);
    void UpdateFood(Food updatedFood);
    void RemoveFood(Food toDeleteFood);
}