using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AIAssistantAPI.Common.Dtos
{
    public class AIProviderDto
    {
        public string? AI_URL { get; set; }
        public string? AI_API_KEY { get; set; }
    }
    public class AIModelDto
    {
        public string? AI_Model { get; set; }
        public decimal? Temperature { get; set; }
    }
    public class AIDivisionDto
    {
        public string? Division { get; set; }
        public string? SubDivision { get; set; }
    }
    public class AIDivisionPromptDto
    {
        public string? SystemPrompt { get; set; }
        public string? GeneralPrompt { get; set; }
    }
    public class AIFieldDto
    {
        public string? Division { get; set; }
        public string? TName { get; set; }
        public string? FName { get; set; }
        public string? FDatatype { get; set; }
        public string? FieldDesc { get; set; }
    }
}
