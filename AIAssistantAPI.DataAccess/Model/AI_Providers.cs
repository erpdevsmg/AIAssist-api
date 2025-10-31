using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIAssistantAPI.DataAccess.Model
{
   public class AI_Providers
    {
        public string? AI_Provider { get; set; }
        public string? AI_URL { get; set; }
        public string? AI_API_KEY { get; set; }
        public bool? Active { get; set; }
        public string? Remarks { get; set; }
    }
}
