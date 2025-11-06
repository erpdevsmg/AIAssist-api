using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using AIAssistantAPI.Common.Dtos;
using AIAssistantAPI.Common.Permission;
using AIAssistantAPI.DataAccess;
using AIAssistantAPI.DataAccess.Model;
using AIAssistantAPI.Service.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AIAssistantAPI.Service.Service
{
    public class DeskService : IDeskService
    {
        private LocalDBContext context;
        private readonly JwtSettings _jwtSetting;
        private readonly EnvironmentData _configuration;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IConfiguration _config;
        public DeskService(LocalDBContext context, JwtSettings jwtSetting, EnvironmentData configuration, IDateTimeProvider dateTimeProvider, IConfiguration config)
        {
            this.context = context;
            _jwtSetting = jwtSetting;
            _configuration = configuration;
            _dateTimeProvider = dateTimeProvider;
            _config = config;
        }
        private IDbConnection CreateConnection()
      => new SqlConnection(_config.GetConnectionString("DefaultConnection"));

        public UserDto GetUserData(string userid)
        {
            UserDto dto = new UserDto();
            //var userData = context.UserMasts.FirstOrDefault(x => x.UserId == userid && x.UserType == "INTERVIEW");
            var userData = context.UserMast.FirstOrDefault(x => x.UserId == userid);
            if (userData != null)
            {

                dto.Id = Convert.ToString(userData.Id);
                dto.UserName = userData.UserName;
                dto.UserID = userData.UserId;
                dto.Email = userData.Email;
                dto.RoleID = userData.RoleId;
                dto.BadgeNo = userData.Badge;
                dto.DeptCode = userData.DeptCode;
                var coNameData = context.POCompany.FirstOrDefault(x => x.CoCode == userData.CoCode);
                if (coNameData != null)
                {
                    dto.CoName = coNameData.CoName;
                }
                var desigData = context.DesignationMaster.FirstOrDefault(x => x.DesigId == userData.DesigId);
                if (desigData != null)
                {
                    dto.Designation = desigData.Designation;
                }
                var deptMastData = context.DeptMast.FirstOrDefault(x => x.DeptCode == userData.DeptCode);
                if (deptMastData != null)
                {
                    dto.DeptName = deptMastData.DeptName;

                }
            }
            return dto;
        }

        public UserMastDto GetUserDataById(string userid)
        {
            UserMastDto data = new UserMastDto();
            var userData = context.UserMast.FirstOrDefault(x => x.UserId == userid);
            if (userData != null)
            {
                data.UserName = userData.UserName;
                data.UserID = userData.UserId;
                data.Email = userData.Email;
                data.RoleID = userData.RoleId;
                data.CompanyID = userData.CoCode;
                data.CoCode = userData.CoCode;
                data.DeptCode = userData.DeptCode;
                data.CurrentCoCode = userData.CoCode;
                return data;
            }
            return null;
        }

        public List<AIProviderDto> GetAIProvider()
        {
            var result = context.AI_Provider.Where(x => x.Active == true).OrderBy(x => x.AI_URL).ToList();
            List<AIProviderDto> list = new List<AIProviderDto>();
            if (result != null && result.Any())
            {
                foreach (var item in result)
                {
                    var dto = new AIProviderDto();
                    dto.AI_URL = item.AI_URL;
                    dto.AI_API_KEY = item.AI_API_KEY;
                    list.Add(dto);
                }
            }
            return list;
        }

        public List<AIModelDto> GetAIModel()
        {
            var result = context.AI_Models.Where(x => x.Active == true).OrderBy(x => x.AI_Model).ToList();
            List<AIModelDto> list = new List<AIModelDto>();
            if (result != null && result.Any())
            {
                foreach (var item in result)
                {
                    var dto = new AIModelDto();
                    dto.AI_Model = item.AI_Model;
                    dto.Temperature = item.Temperature;
                    list.Add(dto);
                }
            }
            return list;
        }

        public List<AIDivisionDto> GetAIDivisions()
        {
            var result = context.AI_Divisions.ToList();
            List<AIDivisionDto> list = new List<AIDivisionDto>();
            if (result != null && result.Any())
            {
                foreach (var item in result)
                {
                    var dto = new AIDivisionDto();
                    dto.Division = item.Division;
                    dto.SubDivision = item.SubDivision;
                    list.Add(dto);
                }
            }
            return list;
        }

        public AIDivisionPromptDto GetAIDivisionsSystemPrompt(string divisionName)
        {
            var result = context.AI_Divisions
                .FirstOrDefault(x => x.Division == divisionName);

            if (result == null)
                return null;

            return new AIDivisionPromptDto
            {
                SystemPrompt = result.SystemPrompt ?? "",
                GeneralPrompt = result.GeneralPrompt ?? ""
            };
        }

        public List<AIFieldDto> GetAIFields(string divisionName)
        {
            var result = context.AI_Fields
                .Where(x => x.Division == divisionName)
                .ToList();

            List<AIFieldDto> list = new List<AIFieldDto>();
            if (result != null && result.Any())
            {
                foreach (var item in result)
                {
                    var dto = new AIFieldDto
                    {
                        Division = item.Division,
                        TName = item.TName,
                        FName = item.FName,
                        FDatatype = item.FDatatype,
                        FieldDesc = item.FieldDesc
                    };
                    list.Add(dto);
                }
            }

            return list;
        }

        public (List<dynamic> Data, int Total, int TotalPages) ExecuteSafeQuery(
    string userUniqueId,
    string? sqlQuery,
    int? limit,
    int? page,
    string? sortBy,
    string? sortOrder)
        {
            int total = 0;
            int totalPages = 0;
            List<dynamic> result = new();

            if (string.IsNullOrWhiteSpace(sqlQuery))
                return (result, total, totalPages);

            using var connection = CreateConnection();

            try
            {
                // --- Count total rows (if possible) ---
                var countSql = $"SELECT COUNT(1) FROM ({sqlQuery}) AS CountQuery";
                total = connection.ExecuteScalar<int>(countSql);

                if (limit.HasValue && limit.Value > 0)
                    totalPages = (int)Math.Ceiling(total / (double)limit.Value);
            }
            catch
            {
                // COUNT may fail for grouped or aggregated queries — ignore safely
                total = 0;
            }

            // --- Prepare paginated SQL ---
            string paginatedSql = sqlQuery.Trim();

            // Add ORDER BY (explicit or fallback)
            if (!string.IsNullOrEmpty(sortBy))
            {
                sortOrder = string.IsNullOrEmpty(sortOrder) ? "ASC" : sortOrder.ToUpper();
                paginatedSql += $" ORDER BY {sortBy} {sortOrder}";
            }
            else
            {
                // --- Handle DISTINCT fallback ordering ---
                if (sqlQuery.TrimStart().StartsWith("SELECT DISTINCT", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        // Try to extract first column from DISTINCT clause
                        var match = Regex.Match(sqlQuery, @"SELECT\s+DISTINCT\s+([\w\.\[\]]+)", RegexOptions.IgnoreCase);
                        if (match.Success)
                        {
                            string firstColumn = match.Groups[1].Value;
                            paginatedSql += $" ORDER BY {firstColumn}";
                        }
                        else
                        {
                            paginatedSql += " ORDER BY (SELECT 1)";
                        }
                    }
                    catch
                    {
                        paginatedSql += " ORDER BY (SELECT 1)";
                    }
                }
                else
                {
                    // Fallback to a dummy ORDER for pagination
                    paginatedSql += " ORDER BY (SELECT 1)";
                }
            }

            // --- Apply pagination ---
            if (limit.HasValue && page.HasValue && limit.Value > 0 && page.Value > 0)
            {
                int skip = (page.Value - 1) * limit.Value;
                paginatedSql += $" OFFSET {skip} ROWS FETCH NEXT {limit.Value} ROWS ONLY";
            }

            try
            {
                result = connection.Query(paginatedSql).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SQL execution error: {ex.Message}");
            }

            return (result, total, totalPages);
        }



        public bool SaveAIMessageLog(AIMessageLogDto data)
        {
            try
            {
                // 🔍 Check if message already exists by MessageId
                var existingMessage = context.AI_MessageLog
                    .FirstOrDefault(x => x.MessageId == data.MessageId);

                if (existingMessage == null)
                {
                    // ✅ INSERT NEW
                    var newLog = new AI_MessageLog
                    {
                        MessageId = data.MessageId == Guid.Empty ? Guid.NewGuid() : data.MessageId,
                        ConversationId = data.ConversationId,
                        TurnIndex = data.TurnIndex,
                        Role = data.Role,
                        Content = data.Content,
                        CreatedUtc = data.CreatedUtc ?? DateTime.UtcNow,
                        Model = data.Model,
                        Temperature = data.Temperature,
                        LatencyMs = data.LatencyMs,
                        TokensPrompt = data.TokensPrompt,
                        TokensCompletion = data.TokensCompletion,
                        TokensTotal = data.TokensTotal,
                        TaskType = data.TaskType,
                        AppUserHash = data.AppUserHash,
                        OrgId = data.OrgId,
                        ToolCallsJson = data.ToolCallsJson,
                        ResponseOk = data.ResponseOk,
                        ErrorType = data.ErrorType,
                        DerivedJson = data.DerivedJson
                    };

                    context.AI_MessageLog.Add(newLog);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    // ✅ UPDATE EXISTING
                    existingMessage.ConversationId = data.ConversationId;
                    existingMessage.TurnIndex = data.TurnIndex;
                    existingMessage.Role = data.Role;
                    existingMessage.Content = data.Content;
                    existingMessage.CreatedUtc = data.CreatedUtc ?? DateTime.UtcNow;
                    existingMessage.Model = data.Model;
                    existingMessage.Temperature = data.Temperature;
                    existingMessage.LatencyMs = data.LatencyMs;
                    existingMessage.TokensPrompt = data.TokensPrompt;
                    existingMessage.TokensCompletion = data.TokensCompletion;
                    existingMessage.TokensTotal = data.TokensTotal;
                    existingMessage.TaskType = data.TaskType;
                    existingMessage.AppUserHash = data.AppUserHash;
                    existingMessage.OrgId = data.OrgId;
                    existingMessage.ToolCallsJson = data.ToolCallsJson;
                    existingMessage.ResponseOk = data.ResponseOk;
                    existingMessage.ErrorType = data.ErrorType;
                    existingMessage.DerivedJson = data.DerivedJson;

                    context.Entry(existingMessage).State = EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }



    }
}
