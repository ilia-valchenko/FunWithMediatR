using System;
using System.Threading;
using System.Threading.Tasks;
using FunWithMediatR.Services.Queries.V1.Person;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FunWithMediatR.Api.Controllers
{
    public class PersonController : BaseController
    {
        public PersonController(IMediator mediator) : base(mediator)
        {
        }

        ///// <summary>
        ///// Gets all available persons.
        ///// </summary>
        //[HttpGet]
        //public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        //{
        //    var query = new GetAllPersonsQuery();
        //    var result = await mediator.Send(query, cancellationToken);

        //    return Ok(result);
        //}

        /// <summary>
        /// Gets a person by using provided person's identifier.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetPersonByIdQuery(id);
            var result = await mediator.Send(query, cancellationToken);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// Gets all persons whos first names are equal to the provided first name.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAsync(string firstName, CancellationToken cancellationToken)
        {
            var query = new GetPersonsByFirstNameQuery(firstName);
            var result = await mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}