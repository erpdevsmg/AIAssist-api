using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIAssistantAPI.DataAccess.Model
{
    public class UserCompany
    {
        public decimal UserAutoId { get; set; }

        public string CoCode { get; set; } = null!;

        public string? LogDet { get; set; }
    }
}
