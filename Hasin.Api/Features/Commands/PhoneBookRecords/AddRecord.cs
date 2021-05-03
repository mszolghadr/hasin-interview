using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Hasin.Api.DTOs.Requests.PhoneBookRecords;
using Hasin.Core.Entities;
using Hasin.Infrastructure;
using Hasin.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Hasin.Api.Features.Commands.PhoneBookRecords.AddPhoneBook
{
    public class AddRecord : BaseAsyncEndpoint
       .WithRequest<AddPhoneBookrecordRequest>
       .WithResponse<PhoneBookRecord>
    {
        private readonly IPhoneBookRecordRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public AddRecord(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.PhoneBookRecordRepository;
        }
        [HttpPost("/Records")]
        [SwaggerOperation(
            Summary = "Creates a new PhoneBookRecord",
            Description = "Creates a new phonebook record",
            OperationId = "Record.Create",
            Tags = new[] { "Phonebook Records" })
        ]
        public override async Task<ActionResult<PhoneBookRecord>> HandleAsync(
            [FromBody] AddPhoneBookrecordRequest request,
            CancellationToken cancellationToken = default)
        {
            // var record = _mapper.Map<PhoneBookRecord>(request);
            PhoneBookRecord record = new() { Name = request.Name, PhoneNumber = request.PhoneNumber };
            _repository.Add(record);
            record.UpdateTags(request.TagIds);

            await _unitOfWork.CommitAsync(cancellationToken);
            return Ok(record);
        }
    }
}
