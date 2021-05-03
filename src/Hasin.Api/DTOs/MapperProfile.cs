using System.Linq;
using AutoMapper;
using Hasin.Api.DTOs.Requests.PhoneBookRecords;
using Hasin.Api.DTOs.Responses.PhoneBookRecords;
using Hasin.Api.DTOs.Responses.Tags;
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

            CreateMap<AddPhoneBookrecordRequest, PhoneBookRecord>();
            #endregion
        }
    }
}