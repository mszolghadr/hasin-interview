using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Hasin.Core.Entities;
using Hasin.Infrastructure;
using Hasin.Infrastructure.Data;
using Hasin.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Hasin.Api.EndPoints.Tags
{
    public class GetList : BaseAsyncEndpoint
       .WithRequest<TagListRequest>
       .WithResponse<PaginatedList<TagResponse>>
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;
        public GetList(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = unitOfWork.TagRepository;
            _mapper = mapper;
        }

        [HttpGet("/tags")]
        [SwaggerOperation(
            Summary = "Get Tags List",
            Description = "This list is paginated",
            OperationId = "Tag.GatAll",
            Tags = new[] { "Tags" })
        ]
        public async override Task<ActionResult<PaginatedList<TagResponse>>> HandleAsync(
            [FromQuery] TagListRequest request, CancellationToken cancellationToken = default
            )
        {
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }
            if (request.PageNumber == 0)
            {
                request.PageNumber = 1;
            }
            var result = new PaginatedList<Tag>(_repository.GetAll(), request.PageNumber, request.PageSize);
            var response = _mapper.Map<PaginatedList<TagResponse>>(result);

            return Ok(response);
        }
    }
}