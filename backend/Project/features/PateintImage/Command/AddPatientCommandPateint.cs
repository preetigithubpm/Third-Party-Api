
using MediatR;
using System.Data;
using task29August.repository;
using task29August.RequestModel;
using Microsoft.Data.SqlClient;

using task29August.ResponseModel;
using task29August.Models;

namespace task29August.features.Patients.Command
{
    public class AddPatientCommandPateint : IRequest<Response>
    {
        public AddImagePatient model { get; set; }

        public class AddPatientCommandPateintHandler : IRequestHandler<AddPatientCommandPateint, Response>
        {
            private readonly IEmailService _iemail;
            private readonly IConfiguration _configuration;
            private IWebHostEnvironment _environment;
            private readonly sdirectdbContext _db;

            public AddPatientCommandPateintHandler(IEmailService email, IConfiguration configuration, IWebHostEnvironment environment, sdirectdbContext db)
            {
                _iemail = email;
                _configuration = configuration;
                _environment = environment;
                _db = db;
            }

            public async Task<Response> Handle(AddPatientCommandPateint request, CancellationToken cancellationToken)
            {
                Response res = new Response();
                try
                {
                    
                    if (!Directory.Exists(_environment.WebRootPath + "\\Image"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Image\\");
                    }
                    string val = DateTime.Now.ToString("yyyyMMddHHmmss");
                    using (FileStream filestream = System.IO.File.Create(_environment.WebRootPath + "\\Image\\" + val + request.model.image.FileName))
                    {
                        request.model.image.CopyTo(filestream);
                        filestream.Flush();
                        PatientTable patient = new PatientTable()
                        {
                            PatientName = request.model.PatientName,
                            Email = request.model.Email,
                            Address = request.model.Address,
                            Dob = request.model.Dob,
                            PhoneNo = request.model.PhoneNo,
                            IsActive = true,
                            IsDeleted = false,
                            ImagePath = "\\Image\\" + val + request.model.image.FileName
                        };


                        var message = new Message(new string[] { request.model.Email }, "Test", "Successfully Added");
                        _iemail.SendEmail(message);


                        _db.PatientTables.Add(patient);

                        _db.SaveChanges();
                        Console.WriteLine("OTP sent successfully.");
                        res.ResponseMessage = "Added";
                        res.ResponseCode = 200;
                        return res;
                    }
                }
                catch (Exception ex) 
                {
                    res.ResponseMessage = ex.Message;
                    return res;


                }
            }
        }
    }
}

