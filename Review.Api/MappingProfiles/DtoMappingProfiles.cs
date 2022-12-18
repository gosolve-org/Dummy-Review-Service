using AutoMapper;
using GoSolve.HttpClients.Dummy.Review.Contracts;
using GoSolve.Tools.Api.ExtensionMethods;

namespace GoSolve.Dummy.Review.Api.MappingProfiles;

public class DtoMappingProfiles : Profile
{
    public DtoMappingProfiles()
    {
        CreateMap<Business.Models.Review, ReviewResponse>();
        CreateMap<ReviewPostRequest, Business.Models.Review>();
        CreateMap<ReviewPutRequest, Business.Models.Review>();
        this.CreateJsonPatchMap<ReviewPatchRequest, Business.Models.Review>();
    }
}
