using TastyPoint.API.Shared.Domain.Repositories;
using TastyPoint.API.TastyPoint.Domain.Models;
using TastyPoint.API.TastyPoint.Domain.Repositories;
using TastyPoint.API.TastyPoint.Domain.Services;
using TastyPoint.API.TastyPoint.Domain.Services.Communication;

namespace TastyPoint.API.TastyPoint.Services;

public class FoodService: IFoodService
{

    private readonly IFoodRepository _foodRepository;
    private readonly IUnitOfWork _unitOfWork;

    public FoodService(IFoodRepository foodRepository, IUnitOfWork unitOfWork)
    {
        _foodRepository = foodRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Food>> ListFoodsAsync()
    {
        return await _foodRepository.ListFoodAsync();
    }

    public async Task<FoodResponse> GetFoodByFoodIdAsync(int foodId)
    {
        var existingFood = await _foodRepository.GetFoodByFoodIdAsync(foodId);
        if (existingFood == null)
            return new FoodResponse("We are sorry, but food does not exist.");
        try
        {
            return new FoodResponse(existingFood);
        }
        catch (Exception exception)
        {
            return new FoodResponse($"An error has ocurred: {exception.Message}");
        }
    }

    public async Task<FoodResponse> AddFoodAsync(Food newFood)
    {
        try
        {
            await _foodRepository.AddFoodAsync(newFood);
            await _unitOfWork.CompleteAsync();
            return new FoodResponse(newFood);
        }
        catch (Exception exception)
        {
            return new FoodResponse($"An error has ocurred: {exception.Message}");
        }
    }

    public async Task<FoodResponse> UpdateFoodAsync(int foodId, Food updatedFood)
    {
        var existingFood = await _foodRepository.GetFoodByFoodIdAsync(foodId);
        if (existingFood == null)
            return new FoodResponse("We are sorry, but food does not exists.");
        
        existingFood.CloneFood(updatedFood);
        
        try
        {
            _foodRepository.UpdateFood(existingFood);
            await _unitOfWork.CompleteAsync();
            return new FoodResponse(existingFood);
        }
        catch (Exception exception)
        {
            return new FoodResponse($"An error has ocurred: {exception.Message}");
        }
    }

    public async Task<FoodResponse> DeleteFoodAsync(int foodId)
    {
        var existingFood = await _foodRepository.GetFoodByFoodIdAsync(foodId);
        if (existingFood == null)
            return new FoodResponse("We are sorry, but food does not exists.");
        try
        {
            _foodRepository.RemoveFood(existingFood);
            await _unitOfWork.CompleteAsync();
            return new FoodResponse(existingFood);
        }
        catch (Exception exception)
        {
            return new FoodResponse($"An error has ocurred: {exception.Message}");
        }
    }
}