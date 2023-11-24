using MediatR;
using Microsoft.IdentityModel.Tokens;
using task29August.Models;
using task29August.RequestModel;

namespace task29August.features.Patients.Queries
{
    public class GetPatientQueriy : IRequest<List<GetAllModel>>
    {
        public class GetPatientCommandHandler : IRequestHandler<GetPatientQueriy, List<GetAllModel>>
        {
            private readonly sdirectdbContext db;
            public GetPatientCommandHandler(sdirectdbContext db)
            {
                this.db = db;
            }

            public async Task<List<GetAllModel>> Handle(GetPatientQueriy request, CancellationToken cancellationToken)
            {
                var data = (from p in db.PatientInformations
                            where p.IsDeleted == false && p.IsActive == true
                            orderby p.PatientId descending

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
                return data;
            }
        }
    }
}
