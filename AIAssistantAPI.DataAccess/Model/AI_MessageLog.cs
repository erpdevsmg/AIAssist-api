using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIAssistantAPI.DataAccess.Model
{
   public class AI_MessageLog
    {
        public Guid MessageId { get; set; }
        public Guid ConversationId { get; set; }
        public int? TurnIndex { get; set; }
        public string? Role { get; set; }
        public string? Content { get; set; }
        public DateTime? CreatedUtc { get; set; }
        public string? Model { get; set; }
        public decimal? Temperature { get; set; }
        public int? LatencyMs { get; set; }
        public int? TokensPrompt { get; set; }
        public int? TokensCompletion { get; set; }
        public int? TokensTotal { get; set; }
        public string? TaskType { get; set; }
        public string? AppUserHash { get; set; }
        public string? OrgId { get; set; }
        public string? ToolCallsJson { get; set; }
        public bool? ResponseOk { get; set; }
        public string? ErrorType { get; set; }
        public string? DerivedJson { get; set; }
    }
}
