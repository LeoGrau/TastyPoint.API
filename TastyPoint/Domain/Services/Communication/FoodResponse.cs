using TastyPoint.API.Shared.Domain.Services.Communication;
using TastyPoint.API.TastyPoint.Domain.Models;

namespace TastyPoint.API.TastyPoint.Domain.Services.Communication;

public class FoodResponse: BaseResponse<Food>
{
    public FoodResponse(Food resource) : base(resource)
    {
    }

    public FoodResponse(string message) : base(message)
    {
    }
}