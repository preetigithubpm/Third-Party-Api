using MediatR;
using Microsoft.Data.SqlClient;
using System.Data;
using task29August.Models;
using task29August.RequestModel;
using task29August.ResponseModel;

namespace task29August.features.Cart
{
    public class AddPayDetailCommand : DetailModel, IRequest<Response1>
    {

        public class AddPayDetailCommandHandler : IRequestHandler<AddPayDetailCommand, Response1>
        {
            private readonly repository.IEmailService _iemail;
            private readonly IConfiguration _configuration;
            private IWebHostEnvironment _environment;
            private readonly sdirectdbContext _db;

            public AddPayDetailCommandHandler(repository.IEmailService email, IConfiguration configuration, IWebHostEnvironment environment, sdirectdbContext db)
            {
                _iemail = email;
                _configuration = configuration;
                _environment = environment;
                _db = db;
            }

            public async Task<Response1> Handle(AddPayDetailCommand request, CancellationToken cancellationToken)
            {
                Response1 res = new Response1();
                string constr = _configuration.GetConnectionString("AppConnectionString");
                using SqlConnection con = new SqlConnection(constr);
                con.Open();

                using SqlCommand cmd = new SqlCommand("AddDetailPayment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                DateTime startDateUtc = (DateTime)request.startDate;
                DateTime endDateUtc = (DateTime)request.endDate;

                // Define the Indian Standard Time zone
                TimeZoneInfo istTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

                // Convert the UTC DateTime to IST
                DateTime startIst = TimeZoneInfo.ConvertTimeFromUtc(startDateUtc, istTimeZone);
                DateTime endDateIst = TimeZoneInfo.ConvertTimeFromUtc(endDateUtc, istTimeZone);
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = request.Name;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = request.Address;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = request.Email;
                cmd.Parameters.Add("@Number", SqlDbType.VarChar).Value = request.Number;
                cmd.Parameters.Add("@uid", SqlDbType.Int).Value = request.uid;
                cmd.Parameters.Add("@startdate", SqlDbType.DateTime).Value = startIst;
                cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = endDateIst;
                int iReturn = cmd.ExecuteNonQuery();

                if (iReturn > 0)
                {
                    // Assuming you have an instance of your email service (IEmailService), you can send the email:
                    var message = new Message(new string[] { request.Email }, "order sucessfully", request.Name + " wait for your product");
                    _iemail.SendEmail(message);

                    res.ResponseMessage = "Information Added";
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


