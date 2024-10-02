using AutoMapper;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Shared.DataTransferObjects;
using Shared.Models;

namespace Shared;

public class AutoMapperProfile: Profile
{
    public AutoMapperProfile()
    {
        // CreateMap<Book, BookDto>().ReverseMap();
        CreateMap<Author, AuthorDto>()
            .ForMember(dest => dest.Dob, opt => 
                opt.MapFrom(src => src.DOB.ToString("yyyy-MM-d")))
            .ReverseMap()
            .ForMember(dest => dest.DOB, opt => opt.MapFrom(src => DateOnly.Parse(src.Dob)));
    }
    
}