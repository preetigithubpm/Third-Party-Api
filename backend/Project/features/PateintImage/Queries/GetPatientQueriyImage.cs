using MediatR;
using Microsoft.IdentityModel.Tokens;
using task29August.Models;
using task29August.RequestModel;

namespace task29August.features.Patients.Queries
{
    public class GetPatientQueriyImage : IRequest<List<GetAllModel1>>
    {
        public class GetPatientQueriyImageHandler : IRequestHandler<GetPatientQueriyImage, List<GetAllModel1>>
        {
            private readonly sdirectdbContext db;
            public GetPatientQueriyImageHandler(sdirectdbContext db)
            {
                this.db = db;
            }

            public async Task<List<GetAllModel1>> Handle(GetPatientQueriyImage request, CancellationToken cancellationToken)
            {
                var data = (from p in db.PatientTables
                            where p.IsDeleted == false && p.IsActive == true
                            orderby p.PatientId descending

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
                return data;
            }
        }
    }
}
