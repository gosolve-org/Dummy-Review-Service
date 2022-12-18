using AutoMapper;
using GoSolve.Tools.Api.ExtensionMethods;

namespace GoSolve.Dummy.Review.Api.Business.MappingProfiles;

public class DtoMappingProfiles : Profile
{
    public DtoMappingProfiles()
    {
        CreateMap<Models.Review, Data.Models.Review>().ReverseMap();
        this.CreateJsonPatchMap<Models.Review, Data.Models.Review>();
    }
}
