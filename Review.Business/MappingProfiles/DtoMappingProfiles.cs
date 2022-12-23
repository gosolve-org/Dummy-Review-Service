﻿using AutoMapper;
using GoSolve.Tools.Common.ExtensionMethods;

namespace GoSolve.Dummy.Review.Business.MappingProfiles;

public class DtoMappingProfiles : Profile
{
    public DtoMappingProfiles()
    {
        CreateMap<Models.Review, Data.Models.Review>().ReverseMap();
        this.CreateJsonPatchMap<Models.Review, Data.Models.Review>();
    }
}