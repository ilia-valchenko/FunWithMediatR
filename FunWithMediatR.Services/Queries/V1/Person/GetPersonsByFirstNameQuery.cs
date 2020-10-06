using System.Collections.Generic;
using MediatR;

namespace FunWithMediatR.Services.Queries.V1.Person
{
    public class GetPersonsByFirstNameQuery : IRequest<IEnumerable<Domain.Entities.Person>>
    {
        public string FirstName { get; }

        public GetPersonsByFirstNameQuery(string firstName)
        {
            this.FirstName = firstName;
        }
    }
}