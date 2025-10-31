using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIAssistantAPI.Common.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string RoleID { get; set; }

        public string BadgeNo { get; set; }
        public string Designation { get; set; }
        public string CoCode { get; set; }
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
        public string UserID { get; set; }
        public string CoName { get; set; }
        
    }
    public class UserMastDto
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string RoleID { get; set; }
        public string CompanyID { get; set; }
        public string CoCode { get; set; }
        public string DeptCode { get; set; }
        public string CurrentCoCode { get; set; }

    }
}
