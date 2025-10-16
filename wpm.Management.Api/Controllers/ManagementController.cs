using Microsoft.AspNetCore.Mvc;
using Wpm.Management.ApplicationService;
using Wpm.SharedKernal;

namespace wpm.Management.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagementController(ManagementApplicationService managementApplicationService,
                                      ICommandHandler<SetWeightCommand> commandHandler) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatPetCommand request)
        {
            await managementApplicationService.Handle(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] SetWeightCommand request)
        {
            await commandHandler.Handle(request);
            return Ok();
        }
    }
}
