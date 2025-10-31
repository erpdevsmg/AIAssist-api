using AIAssistantAPI.DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using Microsoft.Extensions.Configuration.Json;
using AIAssistantAPI.Common.Dtos;

namespace AIAssistantAPI.DataAccess
{
    public class LocalDBContext: DbContext
    {
        public LocalDBContext(DbContextOptions<LocalDBContext> options) : base(options) { }

        public DbSet<Company> Company { get; set; }
        public DbSet<UserMast> UserMast { get; set; }
        public DbSet<UserCompany> UserCompany { get; set; }
        public DbSet<POCompany> POCompany { get; set; }
        public DbSet<DeptMast> DeptMast { get; set; }
        public DbSet<DesignationMaster> DesignationMaster { get; set; }
        public DbSet<SupplierMaster> SupplierMaster { get; set; }
        public DbSet<AI_Providers> AI_Provider { get; set; }
        public DbSet<AI_Models> AI_Models { get; set; }
        public DbSet<AI_Divisions> AI_Divisions { get; set; }
        public DbSet<AI_Fields> AI_Fields { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                optionsBuilder.EnableSensitiveDataLogging(true);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("Company");

                entity.Property(e => e.AcMailAlert)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("AC_MailAlert");
                entity.Property(e => e.AdvToSuppliersAcntCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.AirTicketItemId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("AirTicketItemID");
                entity.Property(e => e.ApplicationId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Application_ID");
                entity.Property(e => e.BankChargeAcntCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.BcApplicationId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BC_Application_ID");
                entity.Property(e => e.BcClientSecretVal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BC_Client_Secret_Val");
                entity.Property(e => e.BcSandBoxName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BC_SandBox_Name");
                entity.Property(e => e.BcTenantId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BC_Tenant_ID");
                entity.Property(e => e.BidLabourRate).HasColumnType("numeric(10, 2)");
                entity.Property(e => e.BudgetNameDefault)
                    .HasMaxLength(15)
                    .IsUnicode(false);
                entity.Property(e => e.ChequePayableAcntCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.ClientSecretVal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Client_Secret_Val");
                entity.Property(e => e.CoAddress1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.CoAddress2)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.CoCity)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.CoCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.CoCountry)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.CoDisplayName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.CoEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.CoFax)
                    .HasMaxLength(25)
                    .IsUnicode(false);
                entity.Property(e => e.CoName)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.CoShort)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.CoTel1)
                    .HasMaxLength(25)
                    .IsUnicode(false);
                entity.Property(e => e.CoTel2)
                    .HasMaxLength(25)
                    .IsUnicode(false);
                entity.Property(e => e.CoWebsite)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.CommonAttachmentPath1).HasMaxLength(200);
                entity.Property(e => e.CpPoapproverId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CP_POApproverID");
                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(3)
                    .IsUnicode(false);
                entity.Property(e => e.CurrencyCoin)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.CurrencyName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.DataFile1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.Datapath)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.EmpBadgePrefix).HasMaxLength(1);
                entity.Property(e => e.EmpRecCurFinYear)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("EmpRec_CurFinYear");
                entity.Property(e => e.EnqGeneratorId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("EnqGeneratorID");
                entity.Property(e => e.EqHireMailAlert)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("EqHire_MailAlert");
                entity.Property(e => e.ExchDiffAcntCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.FtpPwd)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FTP_Pwd");
                entity.Property(e => e.FtpServername)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FTP_Servername");
                entity.Property(e => e.FtpUserName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FTP_UserName");
                entity.Property(e => e.HrPayslipSendAlertIds)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("HR_PayslipSendAlertIDs");
                entity.Property(e => e.HrattachmentPath)
                    .HasMaxLength(200)
                    .HasColumnName("HRAttachmentPath");
                entity.Property(e => e.IntegrationType)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.IsFtp).HasColumnName("IsFTP");
                entity.Property(e => e.LgPoapproverId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("LG_POApproverID");
                entity.Property(e => e.Logo).HasColumnType("image");
                entity.Property(e => e.Logo2).HasColumnType("image");
                entity.Property(e => e.MPwd)
                    .HasMaxLength(64)
                    .IsFixedLength()
                    .HasColumnName("mPwd");
                entity.Property(e => e.MailObjectId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Mail_Object_ID");
                entity.Property(e => e.MarineSalaryExchRateUsd)
                    .HasColumnType("numeric(10, 4)")
                    .HasColumnName("MarineSalaryExchRate_USD");
                entity.Property(e => e.PayrollExportPath)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.PoattachmentPath)
                    .HasMaxLength(200)
                    .HasColumnName("POAttachmentPath");
                entity.Property(e => e.Pobox)
                    .HasMaxLength(20)
                    .HasColumnName("POBox");
                entity.Property(e => e.Poprefix)
                    .HasMaxLength(4)
                    .HasColumnName("POPrefix");
                entity.Property(e => e.Printer1)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.PrinterCheque)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Remarks)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.RequisitionAttachmentPath).HasMaxLength(200);
                entity.Property(e => e.SalesAndRecIsValidateInvoiceOnReceipt).HasColumnName("SalesAndRec_IsValidateInvoice_On_Receipt");
                entity.Property(e => e.SmtpalertFromMailDisplayName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SMTPAlertFromMailDisplayName");
                entity.Property(e => e.SmtpalertFromMailId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SMTPAlertFromMailID");
                entity.Property(e => e.SmtpalertFromMailPwd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SMTPAlertFromMailPwd");
                entity.Property(e => e.TaxRate).HasColumnType("numeric(12, 3)");
                entity.Property(e => e.TaxRegNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.TenantId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Tenant_ID");
                entity.Property(e => e.TsBackDataEntryLimitDays)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("TS_BackDataEntryLimitDays");
                entity.Property(e => e.TsDefaultTimings)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TS_DefaultTimings");
                entity.Property(e => e.ValidCheck)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.WpsexportPath)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WPSExportPath");
                entity.Property(e => e.ZatcaInvoicePath)
                    .HasMaxLength(200)
                    .HasColumnName("ZATCA_InvoicePath");
            });

            modelBuilder.Entity<UserMast>(entity =>
            {
                entity.ToTable("UserMast");

                entity.HasIndex(e => e.UserId, "IX_UserMast");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("ID");
                entity.Property(e => e.ActiveDt).HasColumnType("smalldatetime");
                entity.Property(e => e.Badge).HasMaxLength(5);
                entity.Property(e => e.CoCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.DefaultModuleName)
                    .HasMaxLength(60)
                    .IsUnicode(false);
                entity.Property(e => e.DeptCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.DesigId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DesigID");
                entity.Property(e => e.DivisionCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.InactiveDt).HasColumnType("smalldatetime");
                entity.Property(e => e.IsHrevaluator).HasColumnName("IsHREvaluator");
                entity.Property(e => e.IsNoPoforwardAlert).HasColumnName("Is_No_POForwardAlert");
                entity.Property(e => e.JobType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.LogDet)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Log_Det");
                entity.Property(e => e.LoginAttemptDt)
                    .HasColumnType("datetime")
                    .HasColumnName("LoginAttemptDT");
                entity.Property(e => e.MacName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.MailPwd)
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Pwd)
                    .HasMaxLength(64)
                    .IsFixedLength();
                entity.Property(e => e.Pwd1)
                    .HasMaxLength(64)
                    .IsFixedLength();
                entity.Property(e => e.Pwd2)
                    .HasMaxLength(64)
                    .IsFixedLength();
                entity.Property(e => e.Pwd3)
                    .HasMaxLength(64)
                    .IsFixedLength();
                entity.Property(e => e.PwdChangeDate).HasColumnType("smalldatetime");
                entity.Property(e => e.Remarks)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                entity.Property(e => e.RoleId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RoleID");
                entity.Property(e => e.SecLevel)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.SignAccounts).HasColumnType("image");
                entity.Property(e => e.SignOfficial).HasColumnType("image");
                entity.Property(e => e.SignatoryLevel)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.SignatoryOrder)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.Telephone)
                    .HasMaxLength(25)
                    .IsUnicode(false);
                entity.Property(e => e.UserId)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("UserID");
                entity.Property(e => e.UserJobNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.UserType)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.WinLoginName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserCompany>(entity =>
            {
                entity.HasKey(e => new { e.UserAutoId, e.CoCode });

                entity.ToTable("UserCompany");

                entity.HasIndex(e => e.UserAutoId, "IX_UserCompany");

                entity.Property(e => e.UserAutoId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("UserAutoID");
                entity.Property(e => e.CoCode)
                    .HasMaxLength(2)
                    .IsUnicode(false);
                entity.Property(e => e.LogDet)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Log_det");
            });

            modelBuilder.Entity<POCompany>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("POCompany");

                entity.Property(e => e.AcMailAlert)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("AC_MailAlert");
                entity.Property(e => e.ActCommunicationApproverId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Act_Communication_ApproverID");
                entity.Property(e => e.ActCrewingApproverId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Act_Crewing_ApproverID");
                entity.Property(e => e.ActElectricalApproverId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Act_Electrical_ApproverID");
                entity.Property(e => e.ActItApproverId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Act_IT_ApproverID");
                entity.Property(e => e.ActNavigationalApproverId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Act_Navigational_ApproverID");
                entity.Property(e => e.ActQhseApproverId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Act_QHSE_ApproverID");
                entity.Property(e => e.AdvToSuppliersAcntCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.BankChargeAcntCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.BcCompanyId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BC_CompanyID");
                entity.Property(e => e.BcCompanyName)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("BC_CompanyName");
                entity.Property(e => e.ChequePayableAcntCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.CoAddress1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.CoAddress2)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.CoCity)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.CoCode)
                    .HasMaxLength(2)
                    .IsUnicode(false);
                entity.Property(e => e.CoCountry)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.CoEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.CoFax)
                    .HasMaxLength(25)
                    .IsUnicode(false);
                entity.Property(e => e.CoName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.CoShort)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.CoTel1)
                    .HasMaxLength(25)
                    .IsUnicode(false);
                entity.Property(e => e.CoTel2)
                    .HasMaxLength(25)
                    .IsUnicode(false);
                entity.Property(e => e.CoWebsite)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.ContrApproverId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("ContrApproverID");
                entity.Property(e => e.ContractSignatory)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Contract_Signatory");
                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(3)
                    .IsUnicode(false);
                entity.Property(e => e.CurrencyCoin)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.CurrencyName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.CustomerPrefix)
                    .HasMaxLength(4)
                    .IsUnicode(false);
                entity.Property(e => e.EnqGeneratorId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("EnqGeneratorID");
                entity.Property(e => e.ExchDiffAcntCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.ExpReportCashSuppId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ExpReportCashSuppID");
                entity.Property(e => e.HrPayslipSendAlertIds)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("HR_PayslipSendAlertIDs");
                entity.Property(e => e.IsIcvrelated).HasColumnName("IsICVRelated");
                entity.Property(e => e.IsPocompany).HasColumnName("IsPOCompany");
                entity.Property(e => e.ListOrder)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.LogDet)
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.Logo).HasColumnType("image");
                entity.Property(e => e.Logo2).HasColumnType("image");
                entity.Property(e => e.MarineSalaryExchRateUsd)
                    .HasColumnType("numeric(10, 4)")
                    .HasColumnName("MarineSalaryExchRate_USD");
                entity.Property(e => e.MasterCoCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.Pobox)
                    .HasMaxLength(20)
                    .HasColumnName("POBox");
                entity.Property(e => e.Poprefix)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("POPrefix");
                entity.Property(e => e.PostingCoCode)
                    .HasMaxLength(2)
                    .IsUnicode(false);
                entity.Property(e => e.PrinterCheque)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Remarks)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.SmtpalertFromMailId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SMTPAlertFromMailID");
                entity.Property(e => e.TaxRegNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.VendorPrefix)
                    .HasMaxLength(4)
                    .IsUnicode(false);
                entity.Property(e => e.ZatcaBuildingNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Zatca_BuildingNo");
                entity.Property(e => e.ZatcaCsr)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("Zatca_CSR");
                entity.Property(e => e.ZatcaPlotNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Zatca_PlotNo");
                entity.Property(e => e.ZatcaPrivateKey)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Zatca_PrivateKey");
                entity.Property(e => e.ZatcaPublicKey)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("Zatca_PublicKey");
                entity.Property(e => e.ZatcaRegistrationNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Zatca_RegistrationNumber");
                entity.Property(e => e.ZatcaSecretKey)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Zatca_SecretKey");
                entity.Property(e => e.ZatcaStreenNameAddl)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Zatca_StreenNameAddl");
                entity.Property(e => e.ZatcaStreetName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Zatca_StreetName");
                entity.Property(e => e.ZatcaSubDivision)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Zatca_SubDivision");
                entity.Property(e => e.ZatcaSubEntity)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Zatca_SubEntity");
                entity.Property(e => e.ZatcaTaxRegName)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("Zatca_TaxRegName");
            });

            modelBuilder.Entity<DeptMast>(entity =>
            {
                entity.HasKey(e => e.DeptCode);

                entity.ToTable("DeptMast");

                entity.Property(e => e.DeptCode)
                    .HasMaxLength(2)
                    .IsUnicode(false);
                entity.Property(e => e.CoCode)
                    .HasMaxLength(2)
                    .IsUnicode(false);
                entity.Property(e => e.DeptName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.DivisionCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.EmailAlertIds)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("EmailAlertIDs");
                entity.Property(e => e.HrDept)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HR_Dept");
                entity.Property(e => e.IntReqApproverId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IntReqApproverID");
                entity.Property(e => e.ListOrder)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.LogDet)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Log_Det");
                entity.Property(e => e.PayslipSendIds)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PayslipSendIDs");
                entity.Property(e => e.PoapproverId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("POApproverID");
                entity.Property(e => e.ProjStoreNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.Remarks)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.TsBackDataEntryDefaultLimitDays)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("TS_BackDataEntryDefaultLimitDays");
                entity.Property(e => e.TsBackDataEntryLimitDays)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("TS_BackDataEntryLimitDays");
            });

            modelBuilder.Entity<DesignationMaster>(entity =>
            {
                entity.HasKey(e => e.DesigId);

                entity.ToTable("DesignationMaster");

                entity.Property(e => e.DesigId)
                    .ValueGeneratedOnAdd()
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DesigID");
                entity.Property(e => e.DeptCode)
                    .HasMaxLength(2)
                    .IsFixedLength();
                entity.Property(e => e.DesigCatCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.DesigTypeCode)
                    .HasMaxLength(7)
                    .IsUnicode(false);
                entity.Property(e => e.Designation).HasMaxLength(40);
                entity.Property(e => e.DesignationAr)
                    .HasMaxLength(50)
                    .HasColumnName("Designation_AR");
                entity.Property(e => e.EmployeeGroup)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.HrDesig)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("HR_Desig");
                entity.Property(e => e.HrDesigCode).HasColumnName("HR_DesigCode");
                entity.Property(e => e.IsErpsystemRelated).HasColumnName("IsERPSystemRelated");
                entity.Property(e => e.ListOrder)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.LogDet)
                    .HasMaxLength(30)
                    .HasColumnName("Log_Det");
                entity.Property(e => e.Rate).HasColumnType("numeric(10, 3)");
                entity.Property(e => e.Remarks).HasMaxLength(150);
            });

            modelBuilder.Entity<SupplierMaster>(entity =>
            {
                entity.HasKey(e => e.SupplierId);

                entity.ToTable("SupplierMaster");

                entity.HasIndex(e => e.SupplierCode, "IX_SupplierMaster");

                entity.Property(e => e.SupplierId)
                    .ValueGeneratedOnAdd()
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("SupplierID");
                entity.Property(e => e.Address1)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Address1Ar)
                    .HasMaxLength(50)
                    .HasColumnName("Address1_Ar");
                entity.Property(e => e.Address2)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Address2Ar)
                    .HasMaxLength(50)
                    .HasColumnName("Address2_Ar");
                entity.Property(e => e.AppointBasis)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.ApprovalCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.ApprovalGroupCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.ApprovalStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.ApprovedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.ApprovedDt).HasColumnType("smalldatetime");
                entity.Property(e => e.ApproverRemarks)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.BeneficiaryName)
                    .HasMaxLength(60)
                    .IsUnicode(false);
                entity.Property(e => e.Business1)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Business2)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Business3)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.BusinessDealItems)
                    .HasMaxLength(400)
                    .IsUnicode(false);
                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.CityAr)
                    .HasMaxLength(30)
                    .HasColumnName("City_Ar");
                entity.Property(e => e.CoCode)
                    .HasMaxLength(2)
                    .IsUnicode(false);
                entity.Property(e => e.ContactMobile)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.ContactMobile2)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.ContactPerson2)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.CountryAr)
                    .HasMaxLength(50)
                    .HasColumnName("Country_Ar");
                entity.Property(e => e.CriticalityRate)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.EvaluatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.EvaluationDate).HasColumnType("smalldatetime");
                entity.Property(e => e.EvaluationRemarks)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.FaxOffice)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.FaxWareHouse)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.GenBusinessPostingGroupCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.HomePage)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.IcvCertifyDt)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("ICV_CertifyDt");
                entity.Property(e => e.IcvExpiryDt)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("ICV_ExpiryDt");
                entity.Property(e => e.IcvRemarks)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ICV_Remarks");
                entity.Property(e => e.IcvScore)
                    .HasColumnType("numeric(5, 2)")
                    .HasColumnName("ICV_Score");
                entity.Property(e => e.IntroduceDate).HasColumnType("smalldatetime");
                entity.Property(e => e.IntroducedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.IsAllowMultiJobsPo).HasColumnName("IsAllow_MultiJobs_PO");
                entity.Property(e => e.IsIcvCertified).HasColumnName("IsICV_Certified");
                entity.Property(e => e.IsPoOnWorkCompletion).HasColumnName("IsPO_onWorkCompletion");
                entity.Property(e => e.IsSoaReq).HasColumnName("IsSOA_Req");
                entity.Property(e => e.IsVatregRequired).HasColumnName("IsVATRegRequired");
                entity.Property(e => e.LogDet)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Log_Det");
                entity.Property(e => e.LogDetAdd)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Log_DetAdd");
                entity.Property(e => e.MacName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.OnWhoseDesk)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.PaymentMethodCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.PaymentTermsCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.PerformanceStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Pobox)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("POBox");
                entity.Property(e => e.PoboxAr)
                    .HasMaxLength(20)
                    .HasColumnName("POBox_Ar");
                entity.Property(e => e.RegionCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.Remarks)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.RemindBeforeDays).HasColumnType("numeric(10, 0)");
                entity.Property(e => e.ReqdInfoRemarks)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.ReqdInfoStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.ResponsibleAccGroup)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.ResponsibleExpGroup)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.ResponsiblePurGroup)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Street)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.SupChangeTrackingRemarks)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                entity.Property(e => e.SupForwardedDt).HasColumnType("smalldatetime");
                entity.Property(e => e.SupForwardedFrom)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.SupPreparedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.SupPreparedDt).HasColumnType("smalldatetime");
                entity.Property(e => e.SuppClassCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.SuppGroupCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.SuppName)
                    .HasMaxLength(60)
                    .IsUnicode(false);
                entity.Property(e => e.SuppNameAr)
                    .HasMaxLength(60)
                    .HasColumnName("SuppName_Ar");
                entity.Property(e => e.SuppOldCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Supp_OldCode");
                entity.Property(e => e.SuppSearchName)
                    .HasMaxLength(60)
                    .IsUnicode(false);
                entity.Property(e => e.SuppType)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.SupplierCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);
                entity.Property(e => e.SupplierStatus)
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.TelExt)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.TelOffice)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.TelOffice2)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.TelRes)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.TradeLicExpiryDt).HasColumnType("smalldatetime");
                entity.Property(e => e.TradeLicNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.UnPreferBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.UnPreferDate).HasColumnType("smalldatetime");
                entity.Property(e => e.UnPreferReason)
                    .HasMaxLength(150)
                    .IsUnicode(false);
                entity.Property(e => e.VatExpiryDt)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("VAT_ExpiryDt");
                entity.Property(e => e.VatbusGroupCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VATBusGroupCode");
                entity.Property(e => e.VatregNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VATRegNo");
                entity.Property(e => e.VendorPostingGroupCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AI_Providers>(entity =>
            {
                entity.ToTable("AI_Provider");

                entity.HasKey(e => e.AI_Provider);

                entity.Property(e => e.AI_Provider)
                    .HasColumnName("AI_Provider")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsRequired();  

                entity.Property(e => e.AI_URL)
                    .HasColumnName("AI_URL")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsRequired(false);

                entity.Property(e => e.AI_API_KEY)
                    .HasColumnName("AI_API_KEY")
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .IsRequired(false);

                entity.Property(e => e.Active)
                    .HasColumnName("Active")
                    .IsRequired(false);

                entity.Property(e => e.Remarks)
                    .HasColumnName("Remarks")
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .IsRequired(false);
            });

            modelBuilder.Entity<AI_Models>(entity =>
            {
                entity.ToTable("AI_Models");

                entity.HasKey(e => e.AI_Model);

                entity.Property(e => e.AI_Model)
                    .HasColumnName("AI_Model")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.AI_ModelDesc)
                    .HasColumnName("AI_ModelDesc")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsRequired(false);

                entity.Property(e => e.Remarks)
                    .HasColumnName("Remarks")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .IsRequired(false);

                entity.Property(e => e.Active)
                    .HasColumnName("Active")
                    .IsRequired(false);
            });

            modelBuilder.Entity<AI_Divisions>(entity =>
            {
                entity.ToTable("AI_Divisions");

                entity.HasKey(e => e.Division);

                entity.Property(e => e.Division)
                    .HasColumnName("Division")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.SubDivision)
                    .HasColumnName("SubDivision")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsRequired(false);

                entity.Property(e => e.AI_Model)
                    .HasColumnName("AI_Model")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsRequired(false);

                entity.Property(e => e.DivisionDepts)
                    .HasColumnName("DivisionDepts")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsRequired(false);

                entity.Property(e => e.SystemPrompt)
                    .HasColumnName("SystemPrompt")
                    .IsUnicode(true)     
                    .IsRequired(false);

                entity.Property(e => e.GeneralPrompt)
                    .HasColumnName("GeneralPrompt")
                    .IsUnicode(true)     
                    .IsRequired(false);
            });

            modelBuilder.Entity<AI_Fields>(entity =>
            {
                entity.ToTable("AI_Fields");

                entity.HasKey(e => new { e.Division, e.TName, e.FName });

                entity.Property(e => e.Division)
                    .HasColumnName("Division")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.TName)
                    .HasColumnName("TName")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.FName)
                    .HasColumnName("FName")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.FDatatype)
                    .HasColumnName("FDatatype")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsRequired(false);

                entity.Property(e => e.FieldDesc)
                    .HasColumnName("FieldDesc")
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .IsRequired(false);
            });
        }


    }
}
