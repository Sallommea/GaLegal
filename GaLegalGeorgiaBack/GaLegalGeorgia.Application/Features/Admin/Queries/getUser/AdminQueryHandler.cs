using AutoMapper;
using GaLegalGeorgia.Application.Contracts.Persistence;
using GaLegalGeorgia.Domain;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace GaLegalGeorgia.Application.Features.Admin.Queries.getUser
{
    public class AdminQueryHandler : IRequestHandler<AdminQuery, string>
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;
        private readonly JwtSettings _jwtSettings;

        public AdminQueryHandler(IAdminRepository adminRepository, IMapper mapper, IOptions<JwtSettings> jwtSettings)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<string> Handle(AdminQuery request, CancellationToken cancellationToken)
        {

            var admin = await _adminRepository.GetAdmin();

         //   var admin = new AdminModel()
          //  {
           //     AdminId = 1,
            //    PasswordHash = "5c3c0d931d31a694bb4fdc39fc2ec15bb4875f3daba89c3018fe5f5ca96b7d37",
              //  Username = "Salome"
        //    };
            if (!(ComputeSha256Hash(request.Password) == admin.PasswordHash) || !(request.Email == admin.Username))
            {
                throw new Exception("Invalid Data");
            }
       

            return GenerateJwtToken();
        }

        public static string ComputeSha256Hash(string password)
        {
            using SHA256 sha256Hash = SHA256.Create();

            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            var result = builder.ToString();
            return result;
        }

        public string GenerateJwtToken()
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
               issuer: _jwtSettings.Issuer,
               audience: _jwtSettings.Audience,
               claims: claims,
               expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
               signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}
