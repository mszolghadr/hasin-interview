using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Hasin.Api.DTOs.Requests.PhoneBookRecords;
using Hasin.Infrastructure;
using Hasin.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Hasin.Api.Features.Commands.PhoneBookRecords.RemovePhoneBook
{
    public class DeleteRecord : BaseAsyncEndpoint
       .WithRequest<DeletePhoneBookrecordRequest>
       .WithoutResponse
    {
        private readonly IPhoneBookRecordRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRecord(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.PhoneBookRecordRepository;
        }
        [HttpDelete("/Records/{id}")]
        [SwaggerOperation(
            Summary = "Deletes a PhoneBookRecord",
            Description = "Deletes a phonebook record",
            OperationId = "Record.Delete",
            Tags = new[] { "Phonebook Records" })
        ]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public override async Task<ActionResult> HandleAsync(
            [FromRoute] DeletePhoneBookrecordRequest request,
            CancellationToken cancellationToken = default)
        {
            var record = _repository.Get(request.Id);
            if (record == null)
                return NotFound();
            await _repository.DeleteAsync(request.Id, cancellationToken);

            await _unitOfWork.CommitAsync(cancellationToken);
            return Ok();
        }
    }
}
