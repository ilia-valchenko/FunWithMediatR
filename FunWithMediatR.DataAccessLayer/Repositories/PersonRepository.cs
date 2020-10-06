using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FunWithMediatR.DataAccessLayer.Repositories.Interfaces;
using FunWithMediatR.Domain.Entities;

namespace FunWithMediatR.DataAccessLayer.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IEnumerable<Person> persons = new[]
        {
            new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Ilya",
                LastName = "Valchanka",
                Age = 25
            },
            new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Ilya",
                LastName = "Maddyson",
                Age = 32
            },
            new Person
            {
                Id = Guid.NewGuid(),
                 FirstName = "John",
                 LastName = "Doe",
                 Age = 30
            }
        };

        public async Task<Person> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => persons.FirstOrDefault(persons => persons.Id == id), cancellationToken);
        }

        public async Task<IEnumerable<Person>> GetAsync(CancellationToken cancellationToken)
        {
            return await Task.Run(() => persons, cancellationToken);
        }

        public async Task<IEnumerable<Person>> GetAsync(string firstName, CancellationToken cancellationToken)
        {
            return await Task.Run(
                () => persons.Where(p => string.Equals(p.FirstName, firstName, StringComparison.OrdinalIgnoreCase)),
                cancellationToken);
        }
    }
}