using AutoMapper;
using GoSolve.Clients.Dummy.Review.Contracts.Requests;
using GoSolve.Clients.Dummy.Review.Contracts.Responses;
using GoSolve.Tools.Api.ExtensionMethods;
using GoSolve.Tools.Common.ExtensionMethods;

namespace GoSolve.Dummy.Review.Api.MappingProfiles;

public class DtoMappingProfile : Profile
{
    public DtoMappingProfile()
    {
        CreateMap<ReviewResponse, ReviewPatchRequest>();
    }
}
