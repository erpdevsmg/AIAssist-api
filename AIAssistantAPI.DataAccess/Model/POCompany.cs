using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIAssistantAPI.DataAccess.Model
{
    public class POCompany
    {
        public string CoCode { get; set; } = null!;

        public string? CoName { get; set; }

        public bool? IsIcvrelated { get; set; }

        public string? PostingCoCode { get; set; }

        public string? Remarks { get; set; }

        public string? ListOrder { get; set; }

        public string? LogDet { get; set; }

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

        public byte[]? Logo { get; set; }

        public byte[]? Logo2 { get; set; }

        public string? CurrencyCode { get; set; }

        public string? CurrencyName { get; set; }

        public string? CurrencyCoin { get; set; }

        public string? PrinterCheque { get; set; }

        public bool? IsNavSync { get; set; }

        public bool? IsTaxReady { get; set; }

        public string? TaxRegNo { get; set; }

        public string? Poprefix { get; set; }

        public string? VendorPrefix { get; set; }

        public string? CustomerPrefix { get; set; }

        public decimal? MarineSalaryExchRateUsd { get; set; }

        public string? ExchDiffAcntCode { get; set; }

        public string? BankChargeAcntCode { get; set; }

        public string? AdvToSuppliersAcntCode { get; set; }

        public string? ChequePayableAcntCode { get; set; }

        public string? ExpReportCashSuppId { get; set; }

        public string? CoShort { get; set; }

        public string? AcMailAlert { get; set; }

        public string? BcCompanyName { get; set; }

        public string? BcCompanyId { get; set; }

        public decimal? EnqGeneratorId { get; set; }

        public string? HrPayslipSendAlertIds { get; set; }

        public string? SmtpalertFromMailId { get; set; }

        public string? ContractSignatory { get; set; }

        public decimal? ContrApproverId { get; set; }

        public string? ActCommunicationApproverId { get; set; }

        public string? ActNavigationalApproverId { get; set; }

        public string? ActElectricalApproverId { get; set; }

        public string? ActItApproverId { get; set; }

        public string? ActCrewingApproverId { get; set; }

        public string? ActQhseApproverId { get; set; }

        public string? ZatcaStreetName { get; set; }

        public string? ZatcaStreenNameAddl { get; set; }

        public string? ZatcaBuildingNo { get; set; }

        public string? ZatcaPlotNo { get; set; }

        public string? ZatcaSubEntity { get; set; }

        public string? ZatcaSubDivision { get; set; }

        public string? ZatcaTaxRegName { get; set; }

        public string? ZatcaRegistrationNumber { get; set; }

        public string? ZatcaCsr { get; set; }

        public string? ZatcaPrivateKey { get; set; }

        public string? ZatcaPublicKey { get; set; }

        public string? ZatcaSecretKey { get; set; }

        public string? MasterCoCode { get; set; }

        public bool? IsMajorCompany { get; set; }

        public bool? IsInterCompany { get; set; }

        public bool? IsPocompany { get; set; }

        public bool? IsInvCompany { get; set; }
    }
}
