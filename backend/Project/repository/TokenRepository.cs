using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using task29August.Models;
using task29August.RequestModel;
using task29August.ResponseModel;

namespace task29August.repository
{
    public class TokenRepository : ItokenRepostory
    {
        private readonly sdirectdbContext _context;
        private readonly IConfiguration _config;
        public TokenRepository(sdirectdbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public string generateOtp()
        {
            Random random = new Random();
            int otp = random.Next(100000, 999999);
            return otp.ToString();
        }

        public string GenerateToken(UserModel model)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var role = (from rolemap in _context.RolemappingPrashant4s
                        join u in _context.Loginvalidate2s on rolemap.Id equals u.Id
                        join rl in _context.Rolemaster21s on rolemap.RoleId equals rl.RoleId
                        where u.Name == model.Name
                        select new { rolemap, rl }).ToList();


            var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,model.Name ),
                        };
            if (role != null)
            {
                foreach (var u in role)
                {
                    claims.Add(new Claim(ClaimTypes.Role, u.rl.RoleName));
                }
            }
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Issuer"],
            claims.ToArray(),
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public Response LoginCredentials(UserModel model)
        {
            Response response = new Response();
            var obj = _context.Loginvalidate2s.Where(i => i.Name == model.Name && i.Password == i.Password).FirstOrDefault();
            if (obj != null)
            {
                response.ResponseMessage = "User Valid";
                response.ResponseCode = 200;
                response.Token = GenerateToken(model);
                response.Id = obj.Id;
                return response;
            }
            else
            {
                response.ResponseMessage = "User Not Valid";
                response.ResponseCode = 400;
                return response;
            }
        }
        public Response AddUser(AddUserModel model)
        {
            Response response = new Response();
            Loginvalidate2 userObj = new Loginvalidate2();
            RolemappingPrashant4 mapObj = new RolemappingPrashant4();
            Rolemaster21 roleObj = new Rolemaster21();
            var obj = _context.Loginvalidate2s.Where(i => i.Name == model.Name).ToList();
            if (obj.Count > 0)
            {
                response.ResponseMessage = "User Already Exists";
                response.ResponseCode = 400;
                return response;
            }
            userObj.Name = model.Name;
            userObj.Password = model.Password;
            roleObj.RoleId = model.RoleId;
            _context.Loginvalidate2s.Add(userObj);
            _context.SaveChanges();
            mapObj.Id = userObj.Id;
            mapObj.RoleId = roleObj.RoleId;
            _context.RolemappingPrashant4s.Add(mapObj);
            _context.SaveChanges();
            response.ResponseMessage = "User Added";
            response.ResponseCode = 200;
            return response;
        }
        public GetByIdModel GetByIdProfile(int id)
        {
            var obj = (from l in _context.Loginvalidate2s
                       join r in _context.RolemappingPrashant4s on l.Id equals r.Id
                       join rl in _context.Rolemaster21s on r.RoleId equals rl.RoleId
                       where l.Id == id
                       select new GetByIdModel
                       {
                           Name = l.Name,
                           Email = l.Email,
                           RoleName = rl.RoleName,
                       }).FirstOrDefault();
            return obj;

        }

    }

}
