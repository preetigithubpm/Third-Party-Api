using MediatR;
using task29August.Models;
using task29August.RequestModel;

namespace task29August.features.Patients.Queries
{
    public class GetPatientById : IRequest<List<GetAllModel>>
    {
        public int Id { get; set; }
        public class GetPatientByIdHandler : IRequestHandler<GetPatientById, List<GetAllModel>>
        {
            private readonly sdirectdbContext db;
            public GetPatientByIdHandler(sdirectdbContext _db)
            {
                db = _db;
            }
            public async Task<List<GetAllModel>> Handle(GetPatientById request, CancellationToken cancellationToken)
            {
                GetAllModel model = new GetAllModel();
                var obj = (from p in db.PatientInformations
                           where p.PatientId == request.Id
                           select new GetAllModel
                           {
                               PatientId = p.PatientId,
                               PatientName = p.PatientName,
                               Address = p.Address,
                               Email = p.Email,
                               Dob = p.Dob,
                               PhoneNo = p.PhoneNo,
                               IsActive = p.IsActive,
                               IsDeleted = p.IsDeleted,

                           }).ToList();
                return obj;

            }
        }
    }
}
