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

    }
}
