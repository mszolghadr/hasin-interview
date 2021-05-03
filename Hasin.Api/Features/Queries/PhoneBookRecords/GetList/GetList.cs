using System.Collections.Generic;
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

namespace Hasin.Api.Features.Queries.PhoneBookRecords.GetList
{
    public class GetList : BaseAsyncEndpoint
       .WithRequest<PhoneBookrecordListRequest>
       .WithResponse<PaginatedList<PhoneBookRecordListResult>>
    {
        private readonly IPhoneBookRecordRepository _repository;
        private readonly IMapper _mapper;

        public GetList(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _mapper = mapper;
            _repository = unitOfWork.PhoneBookRecordRepository;
        }
        [HttpGet("/records")]
        [SwaggerOperation(
            Summary = "Get PhoneBookRecord List",
            Description = "This list is paginated",
            OperationId = "Record.GetAll",
            Tags = new[] { "Phonebook Records" })
        ]
        public override async Task<ActionResult<PaginatedList<PhoneBookRecordListResult>>> HandleAsync(
            PhoneBookrecordListRequest request,
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
            var list = await PaginatedList<PhoneBookRecord>.CreateAsync(_repository.GetAll(), request.PageNumber, request.PageSize);
            var result = new PaginatedList<PhoneBookRecordListResult>(
              _mapper.Map<List<PhoneBookRecordListResult>>(list.Items),
              list.TotalCount,
              list.CurrentPage,
              list.PageSize
          );

            return Ok(result);
        }
    }
/*
    public class GetAllEvents
    {
        public class Query : IRequest<List<EventDTO>>
        {
            public Query()
            {
            }
        }

        public class Handler : IRequestHandler<Query, List<EventDTO>>
        {
            private readonly IMapper _mapper;
            private readonly IEventUnitOfWork _unitOfWork;
            private readonly IEventRepository _eventRepository;

            public Handler(IMapper mapper, IEventUnitOfWork unitOfWork)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
                _eventRepository = unitOfWork.EventRepository;
            }

            public async Task<List<EventDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var events = await _eventRepository.GetAllAsync();

                return _mapper.Map<List<EventDTO>>(events);
            }
        }
    }*/
}
