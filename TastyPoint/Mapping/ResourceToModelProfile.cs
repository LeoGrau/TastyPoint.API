using AutoMapper;
using TastyPoint.API.TastyPoint.Domain.Models;
using TastyPoint.API.TastyPoint.Resources.ShowResources;

namespace TastyPoint.API.TastyPoint.Mapping;

public class ResourceToModelProfile: Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<FoodResource, Food>();
    }
}