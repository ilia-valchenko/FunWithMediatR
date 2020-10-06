using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FunWithMediatR.Domain.Entities;

namespace FunWithMediatR.Services.Services.Interfaces
{
    public interface IPersonService
    {
        Task<Person> GetAsync(Guid id, CancellationToken cancellationToken);

        Task<IEnumerable<Person>> GetAsync(CancellationToken cancellationToken);

        Task<IEnumerable<Person>> GetAsync(string firstName, CancellationToken cancellationToken);
    }
}