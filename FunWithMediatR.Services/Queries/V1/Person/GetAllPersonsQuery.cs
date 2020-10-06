using System.Collections.Generic;
using MediatR;

namespace FunWithMediatR.Services.Queries.V1.Person
{
    public class GetAllPersonsQuery : IRequest<IEnumerable<Domain.Entities.Person>>
    {
    }
}