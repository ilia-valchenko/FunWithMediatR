using System;
using MediatR;

namespace FunWithMediatR.Services.Queries.V1.Person
{
    public class GetPersonByIdQuery : IRequest<Domain.Entities.Person>
    {
        public Guid Id { get; }

        public GetPersonByIdQuery(Guid id)
        {
            this.Id = id;
        }
    }
}