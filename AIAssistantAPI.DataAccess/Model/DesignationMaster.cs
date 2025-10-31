using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIAssistantAPI.DataAccess.Model
{
    public class DesignationMaster
    {
        public decimal DesigId { get; set; }

        public string Designation { get; set; } = null!;

        public bool Active { get; set; }

        public string? DeptCode { get; set; }

        public string? DesigTypeCode { get; set; }

        public decimal? Rate { get; set; }

        public bool? IsCostRelated { get; set; }

        public bool? IsErpsystemRelated { get; set; }

        public bool? IsVisaProfession { get; set; }

        public string? Remarks { get; set; }

        public string? ListOrder { get; set; }

        public string? LogDet { get; set; }

        public int? HrDesigCode { get; set; }

        public string? HrDesig { get; set; }

        public string? DesignationAr { get; set; }

        public string? EmployeeGroup { get; set; }

        public string? DesigCatCode { get; set; }
    }
}
