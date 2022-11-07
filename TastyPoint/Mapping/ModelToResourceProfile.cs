using AutoMapper;
using TastyPoint.API.TastyPoint.Domain.Models;
using TastyPoint.API.TastyPoint.Resources.ShowResources;

namespace TastyPoint.API.TastyPoint.Mapping;

public class ModelToResourceProfile: Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Food, FoodResource>();
    }
}