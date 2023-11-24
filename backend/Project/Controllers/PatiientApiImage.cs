using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task29August.features.Cart;
using task29August.features.Patients.Command;
using task29August.features.Patients.Queries;
using task29August.repository;
using task29August.RequestModel;
using task29August.Stripe;

namespace task29August.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class PatiientApiImage : ControllerBase
    {
        private readonly IEmailService _iemail;
        private readonly ICount _cfount;
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        public PatiientApiImage(IEmailService iemail, ICount cfount)
        {
            _iemail = iemail;
            _cfount = cfount;
        }

        [HttpGet]
        [Route("GetAllImage")]
        public async Task<IActionResult> GetAllPatient()
        {
            return Ok(await Mediator.Send(new GetPatientQueriyImage()));
        }
        [HttpGet]
        [Route("getcart")]
        public async Task<IActionResult> getcart(int id1)
        {
            return Ok(await Mediator.Send(new GetByIdCartQuery { uId = id1 }));
        }
        [HttpPost]
        [Route("AddPatientImage")]
        public async Task<IActionResult> PostPatient([FromForm] AddImagePatient model)
        {
            return Ok(await Mediator.Send(new AddPatientCommandPateint { model = model }));
        }
        [HttpPut]
        [Route("UpdatePatientImage")]
        public async Task<IActionResult> UpdatePatient([FromForm] UpdateStudentModel model)
        {
            return Ok(await Mediator.Send(new UpdatePatientCommandImage { model = model }));
        }
        [HttpDelete]
        [Route("DeletePatientImage")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            return Ok(await Mediator.Send(new DeletePatientCommandImage { Id = id }));
        }
        [HttpGet]
        [Route("GetByIdImage")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetPatientByIdImage { Id = id }));
        }

    }
}
