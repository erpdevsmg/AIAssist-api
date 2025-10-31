using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIAssistantAPI.DataAccess.Model
{
   public class AI_Divisions
    {
        public string? Division { get; set; }
        public string? SubDivision { get; set; }
        public string? AI_Model { get; set; }
        public string? DivisionDepts { get; set; }
        public string? SystemPrompt { get; set; }
        public string? GeneralPrompt { get; set; }
    }
}
