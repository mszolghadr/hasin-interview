using AutoMapper;
using Hasin.Api.EndPoints.Tags;
using Hasin.Core.Entities;

namespace Hasin.Api.DTOs
{
    class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Tag, TagResponse>();
        }
    }
}