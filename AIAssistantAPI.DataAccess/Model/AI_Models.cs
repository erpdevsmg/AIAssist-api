using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIAssistantAPI.DataAccess.Model
{
   public class AI_Models
    {
        public string? AI_Model { get; set; }
        public string? AI_ModelDesc { get; set; }
        public decimal? Temperature { get; set; }
        public string? Remarks { get; set; }
        public bool? Active { get; set; }
    }
}
