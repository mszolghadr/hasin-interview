using AutoMapper;
using Hasin.Api.EndPoints.Tags;
using Hasin.Api.Features.Commands.PhoneBookRecords.UpdatePhoneBook;
using Hasin.Api.Features.Queries.PhoneBookRecords.GetList;
using Hasin.Core.Entities;

namespace Hasin.Api.DTOs
{
    class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region  tag
            CreateMap<Tag, TagResponse>();
            #endregion

            #region  phonebook
            CreateMap<PhoneBookRecord, PhoneBookRecordListResult>();

            CreateMap<UpdatePhoneBookrecordRequest, PhoneBookRecord>()
                .ForMember(p => p.Id, option => option.Ignore());
            #endregion
        }
    }
}