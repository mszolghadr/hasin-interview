using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Hasin.Api.DTOs.Requests.PhoneBookRecords;
using Hasin.Core.Entities;
using Hasin.Infrastructure;
using Hasin.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Hasin.Api.Features.Commands.PhoneBookRecords.UpdatePhoneBook
{
    public class UpdateRecord : BaseAsyncEndpoint
       .WithRequest<UpdatePhoneBookrecordRequest>
       .WithResponse<PhoneBookRecord>
    {
        private readonly IPhoneBookRecordRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateRecord(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = unitOfWork.PhoneBookRecordRepository;
        }
        [HttpPut("/Records/{id}")]
        [SwaggerOperation(
            Summary = "Updates a PhoneBookRecord",
            Description = "Updates a phonebook record",
            OperationId = "Record.Update",
            Tags = new[] { "Phonebook Records" })
        ]
        [ProducesResponseType(typeof(PhoneBookRecord) ,StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public override async Task<ActionResult<PhoneBookRecord>> HandleAsync(
            [FromRoute] UpdatePhoneBookrecordRequest request,
            CancellationToken cancellationToken = default)
        {
            var record = _repository.Get(request.Id);
            if (record == null)
                return NotFound();
            _mapper.Map(request.Body, record);
            await _repository.UpdateAsync(record, request.Id, cancellationToken);
            record.UpdateTags(request.Body.TagIds);

            await _unitOfWork.CommitAsync(cancellationToken);
            return Ok(record);
        }
    }
}
