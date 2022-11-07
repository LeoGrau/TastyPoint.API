using System.Runtime.CompilerServices;

namespace TastyPoint.API.TastyPoint.Domain.Models;

public class Food
{
    public long FoodId { get; set; }
    public String? FoodName { get; set; }
    public String? PhotoUrl { get; set; }

    public Food(long foodId, string? foodName, string? photoUrl)
    {
        FoodId = foodId;
        FoodName = foodName;
        PhotoUrl = photoUrl;
    }

    public void CloneFood(Food food)
    {
        FoodId = food.FoodId;
        FoodName = food.FoodName;
        PhotoUrl = food.PhotoUrl;
    }
}