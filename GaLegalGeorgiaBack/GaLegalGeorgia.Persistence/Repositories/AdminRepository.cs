using GaLegalGeorgia.Application;
using GaLegalGeorgia.Application.Contracts.Persistence;
using GaLegalGeorgia.Domain;
using GaLegalGeorgia.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Data.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace GaLegalGeorgia.Persistence.Repositories;
internal class AdminRepository : IAdminRepository
{
    private readonly GaLegalDatabaseContext _context;
    private readonly JwtSettings _jwtSettings;
    public AdminRepository(GaLegalDatabaseContext context, IOptions<JwtSettings> jwtSettings)
    {
        _context = context;
        _jwtSettings = jwtSettings.Value;
    }
    public async Task<AdminModel> GetAdmin()
    {
        var result = await _context.Admins.FirstOrDefaultAsync();
        return result!;
    }


}
