using System;
using System.Threading;
using System.Threading.Tasks;
using FunWithMediatR.Services.Services.Interfaces;
using MediatR;

namespace FunWithMediatR.Services.Queries.V1.Person
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, Domain.Entities.Person>
    {
        private readonly IPersonService service;

        public GetPersonByIdHandler(IPersonService service)
        {
            this.service = service;
        }

        public async Task<Domain.Entities.Person> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return await service.GetAsync(request.Id, cancellationToken);
        }
    }
}