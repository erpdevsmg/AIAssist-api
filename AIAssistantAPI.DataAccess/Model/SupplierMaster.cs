using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIAssistantAPI.DataAccess.Model
{
    public class SupplierMaster
    {
        public decimal SupplierId { get; set; }

        public string? SupplierCode { get; set; }

        public string? SuppName { get; set; }

        public string? SuppSearchName { get; set; }

        public bool? Active { get; set; }

        public bool? IsBlockPayment { get; set; }

        public string? SuppType { get; set; }

        public string? BeneficiaryName { get; set; }

        public string? Address1 { get; set; }

        public string? Address2 { get; set; }

        public string? Pobox { get; set; }

        public string? Street { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }

        public string? ContactPerson { get; set; }

        public string? ContactPerson2 { get; set; }

        public string? ContactMobile { get; set; }

        public string? ContactMobile2 { get; set; }

        public string? TelOffice { get; set; }

        public string? TelOffice2 { get; set; }

        public string? TelRes { get; set; }

        public string? FaxOffice { get; set; }

        public string? FaxWareHouse { get; set; }

        public string? TelExt { get; set; }

        public string? Email { get; set; }

        public string? HomePage { get; set; }

        public string? PaymentMethodCode { get; set; }

        public string? PaymentTermsCode { get; set; }

        public string? CurrencyCode { get; set; }

        public string? RegionCode { get; set; }

        public string? GenBusinessPostingGroupCode { get; set; }

        public string? VendorPostingGroupCode { get; set; }

        public string? AppointBasis { get; set; }

        public string? Business1 { get; set; }

        public string? Business2 { get; set; }

        public string? Business3 { get; set; }

        public string? PerformanceStatus { get; set; }

        public string? ApprovalCode { get; set; }

        public string? SuppOldCode { get; set; }

        public bool? IsLaborSupplier { get; set; }

        public bool? IsCashMiscellaneous { get; set; }

        public bool? IsDocAttached { get; set; }

        public bool? IsSoaReq { get; set; }

        public DateTime? IntroduceDate { get; set; }

        public string? SuppClassCode { get; set; }

        public string? CriticalityRate { get; set; }

        public DateTime? EvaluationDate { get; set; }

        public string? EvaluatedBy { get; set; }

        public string? EvaluationRemarks { get; set; }

        public bool? IsBlockPurchase { get; set; }

        public bool? IsLogistics { get; set; }

        public bool? IsSubContractor { get; set; }

        public bool? IsServiceSupplier { get; set; }

        public bool? IsAirTicketSupplier { get; set; }

        public string? IntroducedBy { get; set; }

        public bool? IsUnPreferred { get; set; }

        public string? UnPreferReason { get; set; }

        public DateTime? UnPreferDate { get; set; }

        public string? UnPreferBy { get; set; }

        public bool? IsDoNotSendMail { get; set; }

        public string? VatregNo { get; set; }

        public bool? IsVatregRequired { get; set; }

        public string? VatbusGroupCode { get; set; }

        public bool? IsIcvCertified { get; set; }

        public decimal? IcvScore { get; set; }

        public DateTime? IcvCertifyDt { get; set; }

        public string? IcvRemarks { get; set; }

        public string? SuppNameAr { get; set; }

        public string? Address1Ar { get; set; }

        public string? Address2Ar { get; set; }

        public string? PoboxAr { get; set; }

        public string? CityAr { get; set; }

        public string? CountryAr { get; set; }

        public string? SupplierStatus { get; set; }

        public bool? IsAllowMultiJobsPo { get; set; }

        public string? TradeLicNo { get; set; }

        public DateTime? TradeLicExpiryDt { get; set; }

        public DateTime? IcvExpiryDt { get; set; }

        public DateTime? VatExpiryDt { get; set; }

        public decimal? RemindBeforeDays { get; set; }

        public string? ResponsibleAccGroup { get; set; }

        public string? ResponsibleExpGroup { get; set; }

        public string? ResponsiblePurGroup { get; set; }

        public string? CoCode { get; set; }

        public string? ApprovalStatus { get; set; }

        public string? OnWhoseDesk { get; set; }

        public string? ApprovedBy { get; set; }

        public DateTime? ApprovedDt { get; set; }

        public string? ApproverRemarks { get; set; }

        public string? Remarks { get; set; }

        public string? MacName { get; set; }

        public string? LogDetAdd { get; set; }

        public string? LogDet { get; set; }

        public bool? IsActivateRegistration { get; set; }

        public string? SuppGroupCode { get; set; }

        public string? ReqdInfoStatus { get; set; }

        public string? ReqdInfoRemarks { get; set; }

        public bool? IsReqdInfoReminder { get; set; }

        public bool? IsPoOnWorkCompletion { get; set; }

        public string? SupPreparedBy { get; set; }

        public DateTime? SupPreparedDt { get; set; }

        public DateTime? SupForwardedDt { get; set; }

        public string? SupForwardedFrom { get; set; }

        public bool? SupIsApproved { get; set; }

        public string? BusinessDealItems { get; set; }

        public string? SupChangeTrackingRemarks { get; set; }

        public bool? IsNewSupplier { get; set; }

        public string? ApprovalGroupCode { get; set; }
    }
}
