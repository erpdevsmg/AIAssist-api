using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIAssistantAPI.DataAccess.Model
{
    public class Company
    {
        public string CoCode { get; set; } = null!;

        public string? CoName { get; set; }

        public string CoShort { get; set; } = null!;

        public string? CoDisplayName { get; set; }

        public string? CoAddress1 { get; set; }

        public string? CoAddress2 { get; set; }

        public string? Pobox { get; set; }

        public string? CoCity { get; set; }

        public string? CoCountry { get; set; }

        public string? CoTel1 { get; set; }

        public string? CoTel2 { get; set; }

        public string? CoFax { get; set; }

        public string? CoEmail { get; set; }

        public string? CoWebsite { get; set; }

        public string? Datapath { get; set; }

        public string? DataFile1 { get; set; }

        public string? Remarks { get; set; }

        public string? ValidCheck { get; set; }

        public byte[]? Logo { get; set; }

        public string? CurrencyCode { get; set; }

        public string? CurrencyName { get; set; }

        public string? CurrencyCoin { get; set; }

        public byte[]? Logo2 { get; set; }

        public string? Poprefix { get; set; }

        public string? EmpBadgePrefix { get; set; }

        public decimal? EnqGeneratorId { get; set; }

        public string? PayrollExportPath { get; set; }

        public string? RequisitionAttachmentPath { get; set; }

        public string? PoattachmentPath { get; set; }

        public string? HrattachmentPath { get; set; }

        public string? CommonAttachmentPath1 { get; set; }

        public bool? IsNavSync { get; set; }

        public bool? AllowSameItemsInReq { get; set; }

        public string? Printer1 { get; set; }

        public string? PrinterCheque { get; set; }

        public decimal? TsBackDataEntryLimitDays { get; set; }

        public decimal? LgPoapproverId { get; set; }

        public decimal? CpPoapproverId { get; set; }

        public string? EmpRecCurFinYear { get; set; }

        public bool? IsOutlookAlert { get; set; }

        public string? SmtpalertFromMailId { get; set; }

        public string? SmtpalertFromMailPwd { get; set; }

        public string? SmtpalertFromMailDisplayName { get; set; }

        public decimal? TaxRate { get; set; }

        public decimal? AirTicketItemId { get; set; }

        public string? TsDefaultTimings { get; set; }

        public string? WpsexportPath { get; set; }

        public bool? IsFtp { get; set; }

        public string? FtpServername { get; set; }

        public string? FtpUserName { get; set; }

        public string? FtpPwd { get; set; }

        public byte[]? MPwd { get; set; }

        public string? TaxRegNo { get; set; }

        public bool? IsTaxReady { get; set; }

        public string? HrPayslipSendAlertIds { get; set; }

        public string? AcMailAlert { get; set; }

        public string? EqHireMailAlert { get; set; }

        public decimal? BidLabourRate { get; set; }

        public decimal? MarineSalaryExchRateUsd { get; set; }

        public bool? IsDashboardActivate { get; set; }

        public string? AdvToSuppliersAcntCode { get; set; }

        public string? BankChargeAcntCode { get; set; }

        public string? ExchDiffAcntCode { get; set; }

        public string? ChequePayableAcntCode { get; set; }

        public string? TenantId { get; set; }

        public string? ApplicationId { get; set; }

        public string? ClientSecretVal { get; set; }

        public string? MailObjectId { get; set; }

        public bool? SalesAndRecIsValidateInvoiceOnReceipt { get; set; }

        public string? IntegrationType { get; set; }

        public string? BcTenantId { get; set; }

        public string? BcApplicationId { get; set; }

        public string? BcClientSecretVal { get; set; }

        public string? BcSandBoxName { get; set; }

        public string? ZatcaInvoicePath { get; set; }

        public string? BudgetNameDefault { get; set; }
    }
}
