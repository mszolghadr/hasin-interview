using AutoMapper;
using Hasin.Api.EndPoints.Tags;
using Hasin.Api.Features.Queries.PhoneBookRecords.GetList;
using Hasin.Core.Entities;

namespace Hasin.Api.DTOs
{
    class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Tag, TagResponse>();

            CreateMap<PhoneBookRecord, PhoneBookRecordListResult>();
        }
    }
}