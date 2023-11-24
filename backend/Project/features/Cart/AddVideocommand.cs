using MediatR;
using Microsoft.Data.SqlClient;
using System.Data;
using task29August.Models;
using task29August.RequestModel;
using task29August.ResponseModel;

namespace task29August.features.Cart
{
    public class AddVideocommand : LocationDetailModel, IRequest<Response1>
    {

        public class AddVideocommandHandler : IRequestHandler<AddVideocommand, Response1>
        {
            private readonly repository.IEmailService _iemail;
            private readonly IConfiguration _configuration;
            private IWebHostEnvironment _environment;
            private readonly sdirectdbContext _db;

            public AddVideocommandHandler(repository.IEmailService email, IConfiguration configuration, IWebHostEnvironment environment, sdirectdbContext db)
            {
                _iemail = email;
                _configuration = configuration;
                _environment = environment;
                _db = db;
            }

            public async Task<Response1> Handle(AddVideocommand request, CancellationToken cancellationToken)
            {
                Response1 res = new Response1();
                string constr = _configuration.GetConnectionString("AppConnectionString");
                using SqlConnection con = new SqlConnection(constr);
                con.Open();

                using SqlCommand cmd = new SqlCommand("AddDetailPayment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = request.Name;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = request.Address;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = request.Email;
                cmd.Parameters.Add("@Number", SqlDbType.VarChar).Value = request.Number;
                int iReturn = cmd.ExecuteNonQuery();

                if (iReturn > 0)
                {
                    // Assuming you have an instance of your email service (IEmailService), you can send the email:
                    var message = new Message(new string[] { request.Email }, "Test", request.Name + " Successfully Added");
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


