using AutoMapper;
using GoSolve.HttpClients.Dummy.Review.Contracts;

namespace GoSolve.Dummy.Review.Api.Business.MappingProfiles;

public class DtoMappingProfiles : Profile
{
    public DtoMappingProfiles()
    {
        CreateMap<Models.Review, ReviewResponse>();
        CreateMap<ReviewRequest, Models.Review>();
    }
}
