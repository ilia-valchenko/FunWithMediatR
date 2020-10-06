using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FunWithMediatR.DataAccessLayer.Repositories.Interfaces;
using FunWithMediatR.Domain.Entities;
using FunWithMediatR.Services.Services.Interfaces;

namespace FunWithMediatR.Services.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository repository;

        public PersonService(IPersonRepository personRepository)
        {
            this.repository = personRepository;
        }

        public async Task<Person> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            return await repository.GetAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<Person>> GetAsync(CancellationToken cancellationToken)
        {
            return await repository.GetAsync(cancellationToken);
        }

        public async Task<IEnumerable<Person>> GetAsync(string firstName, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException($"The argument '{nameof(firstName)}' is null or whitespace.");
            }

            return await repository.GetAsync(firstName, cancellationToken);
        }
    }
}