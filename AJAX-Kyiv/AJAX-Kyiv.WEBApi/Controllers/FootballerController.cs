using System.Threading.Tasks;
using Footballers.Application.Footballers.Queries.GetFootballerList;
using Footballers.Application.Footballers.Queries.GetFootballerDetails;
using Footballers.Application.Footballers.Commands.CreateFootballer;
using Footballers.Application.Footballers.Commands.UpdateFootballer;
using Footballers.Application.Footballers.Commands.DeleteFootballer;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using AJAX_Kyiv.WEBApi.Models;


namespace AJAX_Kyiv.WEBApi.Controllers
{
    [Route("api/[controller]")]
    public class FootballerController : BaseController
    {
        private readonly IMapper _mapper;

        public FootballerController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<FootballerListVm>> GetAll()
        {
            var query = new GetFootballerListQuery
            {
                UserId = UserId,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}]")]
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

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateFootballerDto createFootballerDto) 
        {
            var command = _mapper.Map<CreateFootballerCommand>(createFootballerDto);
            command.UserId = UserId;
            var footballerId = await Mediator.Send(command);
            return Ok(footballerId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateFootballerDto updateFootballerDto)
        {
            var command = _mapper.Map<UpdateFootballerCommand>(updateFootballerDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete ("{id}")]
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
