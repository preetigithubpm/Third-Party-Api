using MediatR;
using task29August.Models;
using task29August.RequestModel;
using task29August.ResponseModel;

namespace task29August.features.Patients.Command
{
    public class DeletePatientCommandImage : IRequest<Response>
    {
        public int Id { get; set; }
        public class DeletePatientCommandImageHandler : IRequestHandler<DeletePatientCommandImage, Response>
        {
            private readonly sdirectdbContext db;
            public DeletePatientCommandImageHandler(sdirectdbContext _db)
            {
                db = _db;
            }
            public async Task<Response> Handle(DeletePatientCommandImage request, CancellationToken cancellationToken)
            {
                Response res = new Response();
                var obj = db.PatientTables.FirstOrDefault(i => i.PatientId == request.Id);
                if (obj != null)
                {
                    obj.IsActive = false;
                    obj.IsDeleted = true;
                    db.Update(obj);
                    db.SaveChanges();
                    res.ResponseMessage = "Deleted Successfully";
                    res.ResponseCode = 200;
                    return res;
                }
                else
                {
                    res.ResponseMessage = "Not Found";
                    res.ResponseCode = 400;
                    return res;
                }
            }
        }
    }
}
