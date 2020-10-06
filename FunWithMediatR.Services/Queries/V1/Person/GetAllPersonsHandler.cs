using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FunWithMediatR.Services.Services.Interfaces;
using MediatR;

namespace FunWithMediatR.Services.Queries.V1.Person
{
    public class GetAllPersonsHandler : IRequestHandler<GetAllPersonsQuery, IEnumerable<Domain.Entities.Person>>
    {
        private readonly IPersonService service;

        public GetAllPersonsHandler(IPersonService service)
        {
            this.service = service;
        }

        public async Task<IEnumerable<Domain.Entities.Person>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return await service.GetAsync(cancellationToken);
        }
    }
}