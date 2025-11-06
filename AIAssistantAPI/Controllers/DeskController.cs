using AIAssistantAPI.Common.Dtos;
using AIAssistantAPI.DataAccess.Model;
using AIAssistantAPI.Service.Interface;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AIAssistantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DeskController : ControllerBase
    {
        private readonly IDeskService _DeskService;
        private readonly JwtSettings _jwtSetting;
        private readonly IConfiguration _config;

        public DeskController(IDeskService DeskService, JwtSettings jwtSetting, IConfiguration config)
        {
            _DeskService = DeskService;
            _jwtSetting = jwtSetting;
            _config = config;
        }

        [HttpGet("GetAIProvider")]
        [Authorize]
        public IActionResult GetAIProvider()
        {
            var result = _DeskService.GetAIProvider();
            return Ok(new { Message = "Success", Data = result });
        }

        [HttpGet("GetAIModel")]
        [Authorize]
        public IActionResult GetAIModel()
        {
            var result = _DeskService.GetAIModel();
            return Ok(new { Message = "Success", Data = result });
        }

        [HttpGet("GetAIDivisions")]
        [Authorize]
        public IActionResult GetAIDivisions()
        {
            var result = _DeskService.GetAIDivisions();
            return Ok(new { Message = "Success", Data = result });
        }

        [HttpGet("GetAIDivisionsSystemPrompt/{divisionName}")]
        [Authorize]
        public IActionResult GetAIDivisionsSystemPrompt(string divisionName)
        {
            var result = _DeskService.GetAIDivisionsSystemPrompt(divisionName);
            return Ok(new { Message = "Success", Data = result });
        }

        [HttpGet("GetAIFields/{divisionName}")]
        [Authorize]
        public IActionResult GetAIFields(string divisionName)
        {
            var result = _DeskService.GetAIFields(divisionName);
            return Ok(new { Message = "Success", Data = result });
        }

        [HttpGet("ExecuteSafeQuery")]
        [Authorize]
        public ActionResult ExecuteSafeQuery(string? sqlQuery, int? limit, int? page, string? sortBy, string? sortOrder)
        {
            string userUniqueId = "";

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                var userIds = User.FindFirst("UserID")?.Value;
                if (userIds == null)
                    return Unauthorized(new { message = "User not authenticated" });
                else
                    userUniqueId = userIds;
            }
            else
            {
                userUniqueId = userId;
            }

            var result = _DeskService.ExecuteSafeQuery(userUniqueId, sqlQuery, limit, page, sortBy, sortOrder);

            return Ok(new
            {
                Message = "Success",
                Data = result.Data,
                Total = result.Total,
                TotalPages = result.TotalPages
            });
        }

        [HttpPost("SaveAIMessageLog")]
        [Authorize]
        public IActionResult SaveAIMessageLog([FromBody] AIMessageLogDto request)
        {
            string userUniqueId = "";
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                var userIds = User.FindFirst("UserID")?.Value;
                if (userIds == null)
                {
                    return Ok(new { Message = "User not authenticated", IsError = true });
                }
                else
                {
                    userUniqueId = userIds;
                }
            }
            else
            {
                userUniqueId = userId;
            }

            // ✅ Basic input validation
            if (request == null)
               return BadRequest(new { Message = "Request body is empty", IsError = true });

            if (request.ConversationId == Guid.Empty)
               return BadRequest(new { Message = "Conversation ID is required", IsError = true });

            if (string.IsNullOrEmpty(request.Role))
               return BadRequest(new { Message = "Role cannot be null or empty", IsError = true });

            if (string.IsNullOrEmpty(request.Content))
               return BadRequest(new { Message = "Content cannot be null or empty", IsError = true });

            // ✅ Attach user info (optional)
            request.AppUserHash = userUniqueId;

            bool result = _DeskService.SaveAIMessageLog(request);
            return Ok(new { Message = result ? "Success" : "Failed to save approval", IsError = !result });
        }


        [HttpGet("me")]
        [Authorize]
        public IActionResult GetCurrentUser()
        {
            string userUniqueId = "";
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                var userIds = User.FindFirst("UserID")?.Value;
                if (userIds == null)
                {
                    return Unauthorized(new { message = "User not authenticated" });
                }
                else
                {
                    userUniqueId = userIds;
                }
            }
            else
            {
                userUniqueId = userId;
            }
            var result = _DeskService.GetUserData(userUniqueId);
            return Ok(result);
        }

        [HttpPost("sso-refresh-token")]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequest refreshTokenRequest)
        {
            try
            {
                var key = _jwtSetting.Key;
                var issuer = _jwtSetting.Issuer;
                var audience = _jwtSetting.Audience;
                var secret = _config["Jwt:Secret"];

                ClaimsPrincipal principal;

                try
                {
                    principal = TokenHelper.TokenHelper.GetPrincipalFromToken(refreshTokenRequest.RefreshToken, key);
                }
                catch
                {
                    return Unauthorized(new { message = "Invalid or expired refresh token." });
                }

                var userId = principal.FindFirst("UserID")?.Value;
                if (string.IsNullOrEmpty(userId))
                    return Unauthorized(new { message = "Invalid token claims." });

                var user = _DeskService.GetUserDataById(userId);
                if (user == null)
                    return Unauthorized(new { message = "User not found." });

                // Create claims for new access token
                var claims = new List<Claim>
                {
                    new Claim("UserID", user.UserID.ToString()),
                    new Claim("UserName", user.UserName),
                    new Claim("Email", user.Email ?? ""),
                    new Claim("RoleID", user.RoleID.ToString()),
                    new Claim("CompanyID", user.CompanyID.ToString()),
                    new Claim("CoCode", user.CoCode ?? ""),
                    new Claim("DeptCode", user.DeptCode ?? ""),
                    new Claim("CurrentCoCode", user.CurrentCoCode ?? user.CoCode ?? ""),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var keys = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

                // Create new access token (shorter expiration)
                var accessTokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddHours(1), // 1 hour for access token
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials(keys, SecurityAlgorithms.HmacSha256Signature)
                };

                var newAccessTokenJwt = tokenHandler.CreateToken(accessTokenDescriptor);
                var newAccessToken = tokenHandler.WriteToken(newAccessTokenJwt);

                // Create new refresh token (longer expiration)
                var refreshTokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddDays(7), // 7 days for refresh token
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials(keys, SecurityAlgorithms.HmacSha256Signature)
                };

                var newRefreshTokenJwt = tokenHandler.CreateToken(refreshTokenDescriptor);
                var newRefreshToken = tokenHandler.WriteToken(newRefreshTokenJwt);

                // Return both tokens
                return Ok(new TokenResponse
                {
                    AccessToken = newAccessToken,
                    RefreshToken = newRefreshToken,
                    ExpiresIn = 3600, // 1 hour in seconds
                    TokenType = "Bearer"
                });
            }
            catch (Exception ex)
            {
                // Log the exception here if you have logging configured
                return StatusCode(500, new { message = "An error occurred while refreshing the token." });
            }
        }

    }

    public class RefreshTokenRequest
    {
        public string RefreshToken { get; set; } = string.Empty;
    }
    public class TokenResponse
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public int ExpiresIn { get; set; }
        public string TokenType { get; set; } = "Bearer";
    }
}
