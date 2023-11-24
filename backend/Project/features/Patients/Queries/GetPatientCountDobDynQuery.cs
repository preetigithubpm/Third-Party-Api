using MediatR;
using Microsoft.IdentityModel.Tokens;
using task29August.Models;
using task29August.RequestModel;

namespace task29August.features.Patients.Queries
{
    public class GetPatientCountDobDynQuery : IRequest<List<GetCountDobChartModel1>>
    {
        public class GetPatientCountDobDynQueryHandler : IRequestHandler<GetPatientCountDobDynQuery, List<GetCountDobChartModel1>>
        {
            private readonly sdirectdbContext db;
            public GetPatientCountDobDynQueryHandler(sdirectdbContext db)
            {
                this.db = db;
            }

            public async Task<List<GetCountDobChartModel1>> Handle(GetPatientCountDobDynQuery request, CancellationToken cancellationToken)
            {
                var data = (from p in db.PatientCounts1
                            select new GetCountDobChartModel1
                            {

                                Count = p.PatientCount,
                                Dob = p.Dob,

                            }).ToList();
                return data;
            }
        }
    }
}
