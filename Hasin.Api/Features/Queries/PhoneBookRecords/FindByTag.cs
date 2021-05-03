using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Hasin.Api.DTOs.Requests.PhoneBookRecords;
using Hasin.Api.DTOs.Responses.PhoneBookRecords;
using Hasin.Core.Entities;
using Hasin.Infrastructure;
using Hasin.Infrastructure.Data;
using Hasin.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Hasin.Api.Features.Queries.PhoneBookRecords.FindByTag
{
    public class FindByTag : BaseAsyncEndpoint
       .WithRequest<FindRecordByTagRequest>
       .WithResponse<PaginatedList<PhoneBookRecordListResult>>
    {
        private readonly IPhoneBookRecordRepository _repository;
        private readonly IMapper _mapper;

        public FindByTag(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _mapper = mapper;
            _repository = unitOfWork.PhoneBookRecordRepository;
        }

        [HttpGet("/Records/FindByTag/{tagId}")]
        [SwaggerOperation(
            Summary = "Find PhoneBookRecords having this tag",
            Description = "This list is paginated",
            OperationId = "Record.FindByTagId",
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
