using AutoMapper;
using GoSolve.Clients.Dummy.Review.Contracts.Requests;
using GoSolve.Clients.Dummy.Review.Contracts.Responses;
using GoSolve.Tools.Common.ExtensionMethods;

namespace GoSolve.Dummy.Review.Business.MappingProfiles;

public class DtoMappingProfile : Profile
{
    public DtoMappingProfile()
    {
        CreateMap<Data.Models.Review, ReviewResponse>();
        CreateMap<Data.Models.ReviewAuthorType, ReviewAuthorTypeResponse>();
        CreateMap<ReviewCreationRequest, Data.Models.Review>();
        CreateMap<ReviewUpdateRequest, Data.Models.Review>();
        this.CreateJsonPatchMap<ReviewPatchRequest, Data.Models.Review>();
    }
}
