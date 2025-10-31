using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIAssistantAPI.DataAccess.Model
{
    public class UserMast
    {
        public decimal Id { get; set; }

        public string? UserId { get; set; }

        public string? UserName { get; set; }

        public bool? IsForcePwdReset { get; set; }

        public string? SecLevel { get; set; }

        public string? RoleId { get; set; }

        public decimal? DesigId { get; set; }

        public bool? Active { get; set; }

        public bool? IsBlockLogin { get; set; }

        public string? DeptCode { get; set; }

        public string? CoCode { get; set; }

        public string? Badge { get; set; }

        public DateTime? ActiveDt { get; set; }

        public string? Email { get; set; }

        public string? Telephone { get; set; }

        public string? Remarks { get; set; }

        public bool? MaterialArrivalAlert { get; set; }

        public bool? VendorCreationAlert { get; set; }

        public bool? IsPurchaser { get; set; }

        public bool? IsExpeditor { get; set; }

        public bool? IsStoreUser { get; set; }

        public bool? IsJobUser { get; set; }

        public bool? IsAllJobAccess { get; set; }

        public string? JobType { get; set; }

        public bool? ItemCreationAlert { get; set; }

        public string? MacName { get; set; }

        public string? LogDet { get; set; }

        public string? DivisionCode { get; set; }

        public string? SignatoryLevel { get; set; }

        public string? SignatoryOrder { get; set; }

        public string? Password { get; set; }

        public bool? IsClientCreationAlert { get; set; }

        public bool? IsJobCreationAlert { get; set; }

        public bool? IsEstimator { get; set; }

        public string? MailPwd { get; set; }

        public string? DefaultModuleName { get; set; }

        public DateTime? InactiveDt { get; set; }

        public bool? IsBalancedPurchaser { get; set; }

        public byte[]? Pwd { get; set; }

        public byte[]? Pwd1 { get; set; }

        public byte[]? Pwd2 { get; set; }

        public byte[]? Pwd3 { get; set; }

        public DateTime? PwdChangeDate { get; set; }

        public bool? IsWinLogin { get; set; }

        public string? WinLoginName { get; set; }

        public byte[]? SignOfficial { get; set; }

        public byte[]? SignAccounts { get; set; }

        public bool? IsHrevaluator { get; set; }

        public bool? IsSalesResponsible { get; set; }

        public bool? IsNoPoforwardAlert { get; set; }

        public DateTime? LoginAttemptDt { get; set; }

        public int? LoginAttemptCnt { get; set; }

        public string? UserJobNo { get; set; }

        public string? UserType { get; set; }
    }
}
