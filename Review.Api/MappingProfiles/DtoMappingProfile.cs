using AutoMapper;
using GoSolve.HttpClients.Dummy.Review.Contracts;
using GoSolve.Tools.Api.ExtensionMethods;
using GoSolve.Tools.Common.ExtensionMethods;

namespace GoSolve.Dummy.Review.Api.MappingProfiles;

public class DtoMappingProfile : Profile
{
    public DtoMappingProfile()
    {
        CreateMap<Business.Models.Review, ReviewResponse>();
        CreateMap<ReviewPostRequest, Business.Models.Review>();
        CreateMap<ReviewPutRequest, Business.Models.Review>();
        this.CreateJsonPatchMap<ReviewPatchRequest, Business.Models.Review>();
    }
}
