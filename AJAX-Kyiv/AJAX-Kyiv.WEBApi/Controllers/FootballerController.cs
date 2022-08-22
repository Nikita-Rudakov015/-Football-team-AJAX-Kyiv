using System.Threading.Tasks;
using Footballers.Application.Footballers.Queries.GetFootballerList;
using Footballers.Application.Footballers.Queries.GetFootballerDetails;
using Footballers.Application.Footballers.Commands.CreateFootballer;
using Footballers.Application.Footballers.Commands.UpdateFootballer;
using Footballers.Application.Footballers.Commands.DeleteFootballer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using AutoMapper;
using AJAX_Kyiv.WEBApi.Models;

namespace AJAX_Kyiv.WEBApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Route("/")]
    public class FootballerController : BaseController
    {
        private readonly IMapper _mapper;

        public FootballerController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of footballers
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET/footballer
        /// </remarks>
        /// <returns>Returns FootballerListVm</returns>
        /// <response code="200" >Success</response> 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<FootballerListVm>> GetAll()
        {
            var query = new GetFootballerListQuery
            {
                UserId = UserId,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the footballer by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Get/footballer/8DB15466-562C-4E5C-B191-03B9840FEAF4
        /// </remarks>
        /// <param name="id">Footballer id (guid)</param>
        /// <returns>Returns FootballerDetailsVm</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}/get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<FootballerDetailsVm>> Get(Guid id)
        {
            var query = new GetFootballersDeatailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the footballer
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /footballer
        /// {
        ///     name: "footballer name",
        ///     lastName: "footballer last name",
        ///     number: number,
        ///     position: "position"
        /// }
        /// </remarks>
        /// <param name="createFootballerDto">CreateFootballerDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateFootballerDto createFootballerDto) 
        {
            var command = _mapper.Map<CreateFootballerCommand>(createFootballerDto);
            command.UserId = UserId;
            var footballerId = await Mediator.Send(command);
            return Ok(footballerId);
        }

        /// <summary>
        /// Updates the footballer
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /footballer
        /// {
        ///     name: "update footballer name",
        ///     lastName: "update footballer last name",
        ///     number: update number,
        ///     position: "update position"
        /// }
        /// </remarks>
        /// <param name="updateFootballerDto">UpdateFootballerDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpPut("{id}/update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateFootballerDto updateFootballerDto)
        {
            var command = _mapper.Map<UpdateFootballerCommand>(updateFootballerDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Delete the footballer by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /footballer/E858304E-79A6-4468-85B4-E54377A11A4C
        /// </remarks>
        /// <param name="id">Id of the footballer (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpDelete ("{id}/delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteFootballerCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
