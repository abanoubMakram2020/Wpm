using Microsoft.AspNetCore.Mvc;
using Wpm.Clinic.ApplicationService.Handlers;
using Wpm.SharedKernal.Command;
using Wpm.SharedKernal.ValueObjects;

namespace wpm.Clinic.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClinicController : ControllerBase
    {
        private readonly ILogger<ClinicController> logger;
        private readonly StartConsultationCommandHandler startConsultationCommanHandler;
        private readonly ICommandHandler<EndConsultationCommand> endConsultationCommandHandler;
        private readonly ICommandHandler<SetDiagnosisCommand> setDiagnosisCommandHandler;
        private readonly ICommandHandler<SetTreatmentCommand> setTreatmentCommandHandler;
        private readonly ICommandHandler<SetWeightCommand> setWeightCommandHandler;
        private readonly ICommandHandler<AdministerDrugCommand> administerDrugCommandHandler;
        private readonly ICommandHandler<RegisterVitalSignsCommand> registerVitalSignsCommandHandler;
        public ClinicController(ILogger<ClinicController> logger,
                                StartConsultationCommandHandler startConsultationCommanHandler,
                                ICommandHandler<RegisterVitalSignsCommand> registerVitalSignsCommandHandler,
                                ICommandHandler<AdministerDrugCommand> administerDrugCommandHandler,
                                ICommandHandler<EndConsultationCommand> endConsultationCommandHandler,
                                ICommandHandler<SetDiagnosisCommand> setDiagnosisCommandHandler,
                                ICommandHandler<SetTreatmentCommand> setTreatmentCommandHandler,
                                ICommandHandler<SetWeightCommand> setWeightCommandHandler)
        {
            this.logger = logger;
            this.startConsultationCommanHandler = startConsultationCommanHandler;
            this.registerVitalSignsCommandHandler = registerVitalSignsCommandHandler;
            this.administerDrugCommandHandler = administerDrugCommandHandler;
            this.endConsultationCommandHandler = endConsultationCommandHandler;
            this.setDiagnosisCommandHandler = setDiagnosisCommandHandler;
            this.setTreatmentCommandHandler = setTreatmentCommandHandler;
            this.setWeightCommandHandler = setWeightCommandHandler;
        }

        [HttpPost]
        public async Task<ActionResult> Post(StartConsultationCommand command)
        {
            try
            {
                var id = await startConsultationCommanHandler.Handle(command);
                return Ok(id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpPost("end")]
        public async Task<ActionResult> Post(EndConsultationCommand command)
        {
            try
            {
                await endConsultationCommandHandler.Handle(command);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpPut("diagnosis")]
        public async Task<ActionResult> Put(SetDiagnosisCommand command)
        {
            try
            {
                await setDiagnosisCommandHandler.Handle(command);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest();
            }
        }
        [HttpPut("treatment")]
        public async Task<ActionResult> Put(SetTreatmentCommand command)
        {
            try
            {
                await setTreatmentCommandHandler.Handle(command);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpPut("weight")]
        public async Task<ActionResult> Put(SetWeightCommand command)
        {
            try
            {
                await setWeightCommandHandler.Handle(command);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpPut("administerDrug")]
        public async Task<ActionResult> Put(AdministerDrugCommand command)
        {
            try
            {
                await administerDrugCommandHandler.Handle(command);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest();
            }
        }


        [HttpPut("registerVitalSigns")]
        public async Task<ActionResult> Put(RegisterVitalSignsCommand command)
        {
            try
            {
                await registerVitalSignsCommandHandler.Handle(command);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest();
            }
        }
    }
}
