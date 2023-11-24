using MediatR;
using Microsoft.Data.SqlClient;
using System.Data;
using task29August.Models;
using task29August.RequestModel;
using task29August.ResponseModel;

namespace task29August.features.Patients.Command
{
    public class UpdatePatientCommand : IRequest<Response>
    {
        public UpdatePatientModel model { get; set; }
        public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, Response>
        {
            private readonly sdirectdbContext db;
            public UpdatePatientCommandHandler(sdirectdbContext _db)
            {
                db = _db;
            }
            public async Task<Response> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
            {
                Response res = new Response();
                var builder = WebApplication.CreateBuilder();
                string constr = builder.Configuration.GetConnectionString("AppConnectionString");
                SqlConnection con = new SqlConnection(constr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UpdatePatientProcedureinformation", con);
                cmd.CommandType = CommandType.StoredProcedure;
                DateTime dobUtc = (DateTime)request.model.Dob;

                // Define the Indian Standard Time zone
                TimeZoneInfo istTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

                // Convert the UTC DateTime to IST
                DateTime dobIst = TimeZoneInfo.ConvertTimeFromUtc(dobUtc, istTimeZone);
                cmd.Parameters.Add("@PatientId", SqlDbType.Int).Value = request.model.PatientId;
                cmd.Parameters.Add("@PatientName", SqlDbType.VarChar).Value = request.model.PatientName;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = request.model.Email;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = request.model.Address;
                cmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = dobIst;
                cmd.Parameters.Add("@PhoneNo", SqlDbType.VarChar).Value = request.model.PhoneNo;
                int iReturn = cmd.ExecuteNonQuery();
                if (iReturn > 0)
                {
                    res.ResponseMessage = "Updated";
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
