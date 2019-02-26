using AutoMapper;
using DatingApp.API.Models.Dtos;
using DatingApp.API.Models.Entity;
using System;
using System.Linq;

namespace DatingApp.API.Models.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(
                    dest => dest.PhotoUrl, 
                    opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain.ToLower() == "true").Url)
                )
                .ForMember(
                    dest => dest.Age,
                    opt => opt.ResolveUsing(d => d.DateOfBirth.ExtGetAge()) 
                );
            CreateMap<User, UserForDetailedDto>()
                .ForMember(
                    dest => dest.PhotoUrl, 
                    opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain.ToLower() == "true").Url)
                )
                .ForMember(
                    dest => dest.Age,
                    opt => opt.ResolveUsing(d => d.DateOfBirth.ExtGetAge()) 
                );
            CreateMap<Photo, PhotosForDetaildDto>();
        }
    }
}