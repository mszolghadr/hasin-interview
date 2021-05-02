using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Hasin.Core.Entities;
using Hasin.Infrastructure;
using Hasin.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Hasin.Api.EndPoints.Tags
{
    public class AddTag : BaseAsyncEndpoint
       .WithRequest<AddTagRequest>
       .WithResponse<TagResponse>
    {
        private readonly ITagRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddTag(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = unitOfWork.TagRepository;
        }
        
        [HttpPost("/tags")]
        [SwaggerOperation(
            Summary = "Creates a new Tag",
            Description = "Creates a new Phonebook Tag",
            OperationId = "Tag.Create",
            Tags = new[] { "Tags" })
        ]
        public override async Task<ActionResult<TagResponse>> HandleAsync(
            [FromBody] AddTagRequest request,
            CancellationToken cancellationToken = default)
        {
            Tag record = new() { Label = request.Label };
            _repository.Add(record);

            await _unitOfWork.CommitAsync(cancellationToken);
            return Ok(_mapper.Map<TagResponse>(record));
        }
    }
}
