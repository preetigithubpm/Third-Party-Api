using MediatR;
using Microsoft.IdentityModel.Tokens;
using task29August.Models;
using task29August.RequestModel;

namespace task29August.features.Patients.Queries
{
    public class GetPatientCountDobQuery : IRequest<List<GetCountDobChartModel>>
    {
        public class GetPatientCountDobQueryHandler : IRequestHandler<GetPatientCountDobQuery, List<GetCountDobChartModel>>
        {
            private readonly sdirectdbContext db;
            public GetPatientCountDobQueryHandler(sdirectdbContext db)
            {
                this.db = db;
            }

            public async Task<List<GetCountDobChartModel>> Handle(GetPatientCountDobQuery request, CancellationToken cancellationToken)
            {
                var data = (from p in db.PatientCounts
                            select new GetCountDobChartModel
                            {

                                Count = p.Count,
                                Dob = p.Dob,

                            }).ToList();
                return data;
            }
        }
    }
}
