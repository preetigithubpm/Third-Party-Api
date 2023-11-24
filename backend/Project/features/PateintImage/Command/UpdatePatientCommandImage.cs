using MediatR;
using Microsoft.Data.SqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Data;
using task29August.Models;
using task29August.RequestModel;
using task29August.ResponseModel;
using task29August.Stripe;

namespace task29August.features.Patients.Command
{
    public class UpdatePatientCommandImage : IRequest<Response1>
    {
        public UpdateStudentModel model { get; set; }
        public class UpdatePatientCommandImageHandler : IRequestHandler<UpdatePatientCommandImage, Response1>
        {
            private readonly sdirectdbContext db;
            private IWebHostEnvironment _environment;
            public UpdatePatientCommandImageHandler(sdirectdbContext _db, IWebHostEnvironment environment)
            {
                db = _db;
                _environment = environment;
            }
            public async Task<Response1> Handle(UpdatePatientCommandImage request, CancellationToken cancellationToken)
            {
                Response1 res = new Response1();
                var obj = db.PatientTables.Where(i => i.PatientId == request.model.PatientId).FirstOrDefault();
                if (obj != null)
                {
                    if (request.model.image != null)
                    {
                        if (!Directory.Exists(_environment.WebRootPath + "\\Image"))
                        {
                            Directory.CreateDirectory(_environment.WebRootPath + "\\Image\\");
                        }
                        string val = DateTime.Now.ToString("yyyyMMddHHmmss");
                        using (FileStream filestream = File.Create(_environment.WebRootPath + "\\Image\\" + val + request.model.image.FileName))
                        {
                            request.model.image.CopyTo(filestream);
                            filestream.Flush();

                            obj.PatientId = request.model.PatientId;
                            obj.PatientName = request.model.PatientName;
                            obj.Email = request.model.Email;
                            obj.Address = request.model.Address;
                            obj.PhoneNo = request.model.PhoneNo;
                            obj.Dob = request.model.Doa;
                            //obj.ImagePath = "\\Image\\" + val + request.model.image.FileName;
                            obj.IsActive = true;
                            obj.IsDeleted = false;
                        }
                    }
                    else
                    {
                        obj.PatientId = request.model.PatientId;
                        obj.PatientName = request.model.PatientName;
                        obj.Email = request.model.Email;
                        obj.Address = request.model.Address;
                    }
                    db.SaveChanges();
                    res.ResponseMessage = "Successfully Updated";
                    res.ResponseCode = 200;
                    return res;
                }
                res.ResponseMessage = "Not Found";
                res.ResponseCode = 400;
                return res;



            }
        }
    }
}
