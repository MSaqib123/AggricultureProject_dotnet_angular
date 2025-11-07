// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.IdentityModel.Tokens;
// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Claims;
// using System.Text;
// using AutoMapper;
// using WeightAggregationApi.Models.DTOs;
// using WeightAggregationApi.Models.Responses;
// using Microsoft.AspNetCore.Identity;
// using System.Threading.Tasks;

// namespace WeightAggregationApi.Controllers.v1;

// [ApiVersion("1.0")]
// [Route("api/v{version:apiVersion}/[controller]")]
// [ApiController]
// public class AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration, IMapper mapper) : ControllerBase
// {
//     [HttpPost("register")]
//     public async Task<ApiResponse<string>> Register([FromBody] RegisterDto dto)
//     {
//         var user = mapper.Map<ApplicationUser>(dto);
//         var result = await userManager.CreateAsync(user, dto.Password);
//         if (result.Succeeded)
//         {
//             await userManager.AddClaimAsync(user, new Claim("tenant_id", Guid.NewGuid().ToString()));
//             // Email confirmation token: var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
//             // Send email
//             return new ApiResponse<string>(true, "Registered successfully");
//         }
//         return new ApiResponse<string>(false, default, "Registration failed", [.. result.Errors.Select(e => e.Description)]);
//     }

//     [HttpPost("login")]
//     public async Task<ApiResponse<string>> Login([FromBody] LoginDto dto)
//     {
//         var result = await signInManager.PasswordSignInAsync(dto.Email, dto.Password, false, false);
//         if (result.Succeeded)
//         {
//             var user = await userManager.FindByEmailAsync(dto.Email);
//             var token = GenerateJwt(user!);
//             return new ApiResponse<string>(true, token);
//         }
//         return new ApiResponse<string>(false, default, "Invalid credentials");
//     }

//     private string GenerateJwt(ApplicationUser user)
//     {
//         var claims = new List<Claim>
//         {
//             new(JwtRegisteredClaimNames.Sub, user.UserName!),
//             new("tenant_id", user.TenantId.ToString())
//         };
//         var roles = userManager.GetRolesAsync(user).Result;
//         claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

//         var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
//         var token = new JwtSecurityToken(
//             issuer: configuration["Jwt:Issuer"],
//             audience: configuration["Jwt:Audience"],
//             claims: claims,
//             expires: DateTime.UtcNow.AddHours(1),
//             signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha512) // Advanced security
//         );

//         return new JwtSecurityTokenHandler().WriteToken(token);
//     }

//     // Add [HttpPost("refresh"), [HttpPost("forgot-password"), etc.
//     // Profile picture: [HttpPost("profile/picture"), Authorize, FromForm IFormFile file
//     // Upload to Azure Blob or wwwroot, update user.ProfilePictureUrl
// }