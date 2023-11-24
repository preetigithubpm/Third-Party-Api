using task29August.RequestModel;
using task29August.ResponseModel;

namespace task29August.repository
{
    public interface ItokenRepostory
    {
        public string GenerateToken(UserModel model);
        public Response LoginCredentials(UserModel model);
        public Response AddUser(AddUserModel model);
        public GetByIdModel GetByIdProfile(int id); 
    }
}
