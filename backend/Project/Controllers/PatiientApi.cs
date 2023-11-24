using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task29August.features.Cart;
using task29August.features.Patients.Command;
using task29August.features.Patients.Queries;
using task29August.repository;
using task29August.RequestModel;

namespace task29August.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Libra")]
    public class PatiientApi : ControllerBase
    {
        private readonly IEmailService _iemail;
        private readonly ICount _cfount;
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        public PatiientApi(IEmailService iemail, ICount cfount)
        {
            _iemail = iemail;
            _cfount = cfount;
        }


        [HttpGet]
        [Route("GetAllPatient")]
        public async Task<IActionResult> GetAllPatient()
        {
            return Ok(await Mediator.Send(new GetPatientQueriy()));
        }

        [HttpGet]
        [Route("GetAllPatientCount")]
        public async Task<IActionResult> GetAllPatientCount()
        {
            return Ok(await Mediator.Send(new GetPatientCountDobQuery()));
        }
        [HttpGet]
        [Route("GetAllPatientCountDynamically")]
        public async Task<IActionResult> GetAllPatientCount1()
        {
            return Ok(await Mediator.Send(new GetPatientCountDobDynQuery()));
        }

        [HttpPost]
        [Route("PostPatient")]
        public async Task<IActionResult> PostPatient(PostPatientModel model)
        {
            return Ok(await Mediator.Send(new AddPatientCommand { model = model }));
        }

        [HttpPost]
        [Route("addpaydetails")]
        public async Task<IActionResult> addpaydetails(AddPayDetailCommand model)
        {
            return Ok(await Mediator.Send(model));
        }

        [HttpPost]
        [Route("addToCart")]
        public async Task<IActionResult> addToCart(AddCartCommand model)
        {
            return Ok(await Mediator.Send(model));
        }

        [HttpPut]
        [Route("UpdatePatient")]
        public async Task<IActionResult> UpdatePatient(UpdatePatientModel model)
        {
            return Ok(await Mediator.Send(new UpdatePatientCommand { model = model }));
        }

        [HttpDelete]
        [Route("DeletePatient")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            return Ok(await Mediator.Send(new DeletePatientImageCommand { Id = id }));
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetPatientById { Id = id }));
        }
        [HttpGet]
        [Route("GetCount")]
        public IActionResult getCopunt()
        {
            var obj = _cfount.getPatientCount();
            return Ok(obj);
        }
    }
}
