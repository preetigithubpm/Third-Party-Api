using task29August.RequestModel;
using task29August.ResponseModel;

namespace task29August.repository
{
    public interface ITwoStep
    {
        public ResponseModel.Response SendOtpToEmails(string Email, string Otp);
        public ResponseOtp registeruser(AddUserModel register);
        public ResponseOtp verifyotp(OtpModel otp);



    }
}
