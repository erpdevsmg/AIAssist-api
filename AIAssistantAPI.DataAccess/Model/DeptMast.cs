using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIAssistantAPI.DataAccess.Model
{
    public class DeptMast
    {
        public string DeptCode { get; set; } = null!;

        public string DeptName { get; set; } = null!;

        public bool Active { get; set; }

        public string? DivisionCode { get; set; }

        public string? ListOrder { get; set; }

        public string CoCode { get; set; } = null!;

        public string? Remarks { get; set; }

        public bool? IsYardDept { get; set; }

        public string? LogDet { get; set; }

        public decimal? TsBackDataEntryLimitDays { get; set; }

        public decimal? TsBackDataEntryDefaultLimitDays { get; set; }

        public string? HrDept { get; set; }

        public string? EmailAlertIds { get; set; }

        public bool? BalancedReqns { get; set; }

        public string? PayslipSendIds { get; set; }

        public string? PoapproverId { get; set; }

        public string? ProjStoreNo { get; set; }

        public string? IntReqApproverId { get; set; }
    }
}
