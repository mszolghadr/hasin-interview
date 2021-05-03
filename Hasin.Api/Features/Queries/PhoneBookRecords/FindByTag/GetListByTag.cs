using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Hasin.Api.Features.Queries.PhoneBookRecords.GetList;
using Hasin.Core.Entities;
using Hasin.Infrastructure;
using Hasin.Infrastructure.Data;
using Hasin.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Hasin.Api.Features.Queries.PhoneBookRecords.FindByTag
{
    public class GetListByTag : BaseAsyncEndpoint
       .WithRequest<FindRecordByTagRequest>
       .WithResponse<PaginatedList<PhoneBookRecordListResult>>
    {
        private readonly IPhoneBookRecordRepository _repository;
        private readonly IMapper _mapper;

        public GetListByTag(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _mapper = mapper;
            _repository = unitOfWork.PhoneBookRecordRepository;
        }

        [HttpGet("/records/bytag/{tagId:int}")]
        [SwaggerOperation(
            Summary = "Get PhoneBookRecord List By Tag Id",
            Description = "This list is paginated",
            OperationId = "Record.GetByTag",
            Tags = new[] { "Phonebook Records" })
        ]
        public override async Task<ActionResult<PaginatedList<PhoneBookRecordListResult>>> HandleAsync(
            [FromQuery] FindRecordByTagRequest request,
            CancellationToken cancellationToken = default)
        {
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }
            if (request.PageNumber == 0)
            {
                request.PageNumber = 1;
            }
            
            var list = await PaginatedList<PhoneBookRecord>.CreateAsync(_repository.FindByTag(request.TagId), request.PageNumber, request.PageSize);
            var result = new PaginatedList<PhoneBookRecordListResult>(
                _mapper.Map<List<PhoneBookRecordListResult>>(list.Items),
                list.TotalCount,
                list.CurrentPage,
                list.PageSize
            );

            return Ok(result);
        }
    }
}
