using Microsoft.EntityFrameworkCore;
using TastyPoint.API.Shared.Persistence.Contexts;
using TastyPoint.API.Shared.Persistence.Repositories;
using TastyPoint.API.TastyPoint.Domain.Models;
using TastyPoint.API.TastyPoint.Domain.Repositories;

namespace TastyPoint.API.TastyPoint.Persistence.Repositories;

public class FoodRepository: BaseRespository,IFoodRepository
{
    
    public FoodRepository(TastyPointDbContext tastyPointDbContext) : base(tastyPointDbContext)
    {
    }
    
    public async Task<IEnumerable<Food?>> ListFoodAsync()
    {
        return await _tastyPointDbContext.Foods.ToListAsync();
    }

    public async Task<Food> GetFoodByFoodIdAsync(int foodId)
    {
        return await _tastyPointDbContext.Foods.FindAsync(foodId);
    }

    public async Task AddFoodAsync(Food newFood)
    {
        await _tastyPointDbContext.Foods.AddAsync(newFood);
    }

    public void UpdateFood(Food updatedFood)
    {
        _tastyPointDbContext.Foods.Update(updatedFood);
    }

    public void RemoveFood(Food toDeleteFood)
    {
        _tastyPointDbContext.Foods.Remove(toDeleteFood);
    }
    
}