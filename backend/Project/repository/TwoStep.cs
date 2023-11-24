using System.Net.Mail;
using System.Net;
using task29August.Models;
using task29August.RequestModel;
using task29August.ResponseModel;

namespace task29August.repository
{
    public class TwoStep : ITwoStep
    {
        public readonly sdirectdbContext _context;
        private readonly IConfiguration _config;
        private readonly IEmailService _iemail;



        public TwoStep(sdirectdbContext context, IConfiguration config, IEmailService iemail)
        {
            _context = context;
            _config = config;
            _iemail = iemail;
        }


        public string generateOtp()
        {
            Random random = new Random();
            int otp = random.Next(100000, 999999);
            return otp.ToString();
        }





        public ResponseModel.Response SendOtpToEmails(string Email, string Otp)
        {
            ResponseModel.Response response = new ResponseModel.Response();
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                var smtpServer = _config["EmailSettings:Host"];
                var smtpPort = int.Parse(_config["EmailSettings:Port"]);
                var smtpUsername = _config["EmailSettings:Email"];
                var smtpPassword = _config["EmailSettings:Password"];

                using (var client = new SmtpClient(smtpServer, smtpPort))
                {
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                    client.EnableSsl = true;

                    var mail = new MailMessage
                    {
                        From = new MailAddress(smtpUsername),
                        Subject = "OTP Verification",
                        Body = $"Your OTP is: {Otp}",
                        IsBodyHtml = false
                    };

                    mail.To.Add(Email);

                    client.Send(mail);

                    response.ResponseMessage = "otp sent to email";

                    return response;
                }
            }
            catch (Exception ex)
            {

                response.ResponseMessage = $"Failed to send OTP email. Error: {ex.Message ?? "Unknown error"}";

                return response;
            }
        }
        public ResponseOtp registeruser(AddUserModel register)
        {
            Loginvalidate2 user = new Loginvalidate2();
            RolemappingPrashant4 rolemap = new RolemappingPrashant4();
            Rolemaster21 role = new Rolemaster21();
            ResponseOtp response = new ResponseOtp();

            var userobj = _context.Loginvalidate2s.Where(i => i.Name == register.Name).ToList();
            if (userobj.Count > 0)
            {
                response.ResponseMessage = "Already";
                response.ResponseCode = 'E';

                return response;
            }

            string otp = generateOtp();

            ResponseModel.Response otpResponse = SendOtpToEmails(register.Email, otp);

            if (otpResponse.ResponseMessage == "otp not sent to email")
            {
                response.ResponseMessage = "OTP not sent.";
                response.ResponseCode = 'A';


            }
            else
            {
                user.Name = register.Name;
                //user.Email = register.Email;
                user.Password = register.Password;
                role.RoleId = register.RoleId;
                user.Otp = otp;

                _context.Loginvalidate2s.Add(user);
                _context.SaveChanges();
                rolemap.Id = user.Id;
                rolemap.RoleId = role.RoleId;
                _context.RolemappingPrashant4s.Add(rolemap);
                _context.SaveChanges();

                response.ResponseMessage = $"Otp Send to: {user.Email}";
                response.ResponseCode = 'D';
            }

            return response;
        }
        public ResponseOtp verifyotp(OtpModel otp)
        {
            Loginvalidate2 user = new Loginvalidate2();
            ResponseOtp response = new ResponseOtp();

            var userobj = _context.Loginvalidate2s.Where(u => u.Otp == otp.otp).FirstOrDefault();


            try
            {
                userobj.IsAuthenticate = true;

                _context.SaveChanges();

                response.Verified = true;
                var message = new Message(new string[] { userobj.Email }, "Test", "Successfully verified");

                _iemail.SendEmail(message);
                response.ResponseMessage = $"otp send to: {string.Join(", ", message.To)}";
                return response;
            }
            catch (Exception ex)
            {
                response.Verified = false;
                return response;
            }


        }
    }

}

