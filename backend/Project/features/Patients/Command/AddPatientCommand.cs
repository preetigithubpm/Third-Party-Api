
using MediatR;
using System.Data;
using task29August.repository;
using task29August.RequestModel;
using Microsoft.Data.SqlClient;

using task29August.ResponseModel;

namespace task29August.features.Patients.Command
{
    public class AddPatientCommand : IRequest<Response>
    {
        public PostPatientModel model { get; set; }

        public class AddPatientCommandHandler : IRequestHandler<AddPatientCommand, Response>
        {
            private readonly IEmailService _iemail;
            private readonly IConfiguration _configuration;

            public AddPatientCommandHandler(IEmailService email, IConfiguration configuration)
            {
                _iemail = email;
                _configuration = configuration;
            }

            public async Task<Response> Handle(AddPatientCommand request, CancellationToken cancellationToken)
            {
                Response res = new Response();

                string constr = _configuration.GetConnectionString("AppConnectionString");
                using SqlConnection con = new SqlConnection(constr);
                con.Open();

                using SqlCommand cmd = new SqlCommand("AddPatientProcedureInfortmatioon", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Assume that request.model.Dob is a DateTime in UTC format.
                DateTime dobUtc = (DateTime)request.model.Dob;

                // Define the Indian Standard Time zone
                TimeZoneInfo istTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

                // Convert the UTC DateTime to IST
                DateTime dobIst = TimeZoneInfo.ConvertTimeFromUtc(dobUtc, istTimeZone);

                cmd.Parameters.Add("@PatientName", SqlDbType.VarChar).Value = request.model.PatientName;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = request.model.Address;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = request.model.Email;
                cmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = dobIst;
                cmd.Parameters.Add("@PhoneNo", SqlDbType.VarChar).Value = request.model.PhoneNo;
                int iReturn = cmd.ExecuteNonQuery();

                if (iReturn > 0)
                {
                    // Assuming you have an instance of your email service (IEmailService), you can send the email:
                    var message = new Message(new string[] { request.model.Email }, "Test", request.model.PatientName + " Successfully Added");
                    _iemail.SendEmail(message);

                    res.ResponseMessage = "Added";
                    res.ResponseCode = 200;
                }
                else
                {
                    res.ResponseMessage = "Not Found";
                    res.ResponseCode = 400;
                }

                return res;
            }
        }
    }
}

