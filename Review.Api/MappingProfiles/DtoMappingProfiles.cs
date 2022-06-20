using AutoMapper;
using GoSolve.HttpClients.Dummy.Review.Contracts;

namespace GoSolve.Dummy.Review.Api.MappingProfiles;

public class DtoMappingProfiles : Profile
{
    public DtoMappingProfiles()
    {
        CreateMap<Business.Models.Review, ReviewResponse>();
        CreateMap<ReviewRequest, Business.Models.Review>();
    }
}
