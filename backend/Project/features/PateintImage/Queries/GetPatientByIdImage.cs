using MediatR;
using task29August.Models;
using task29August.RequestModel;

namespace task29August.features.Patients.Queries
{
    public class GetPatientByIdImage : IRequest<List<GetAllModel1>>
    {
        public int Id { get; set; }
        public class GetPatientByIdImageHandler : IRequestHandler<GetPatientByIdImage, List<GetAllModel1>>
        {
            private readonly sdirectdbContext db;
            public GetPatientByIdImageHandler(sdirectdbContext _db)
            {
                db = _db;
            }
            public async Task<List<GetAllModel1>> Handle(GetPatientByIdImage request, CancellationToken cancellationToken)
            {
                GetAllModel1 model = new GetAllModel1();
                var obj = (from p in db.PatientTables
                           where p.PatientId == request.Id && p.IsActive == true && p.IsDeleted == false
                           select new GetAllModel1
                           {
                               PatientId = p.PatientId,
                               PatientName = p.PatientName,
                               Address = p.Address,
                               Email = p.Email,
                               Dob = p.Dob,
                               PhoneNo = p.PhoneNo,
                               ImagePath = p.ImagePath,
                               IsActive = p.IsActive,
                               IsDeleted = p.IsDeleted,

                           }).ToList();
                return obj;

            }
        }
    }
}
