using AIAssistantAPI.DataAccess;
using AIAssistantAPI.Service.Interface;

namespace AIAssistantAPI.Service
{
    public class UtilityService
    {
        private LocalDBContext _context;
        public UtilityService(LocalDBContext context)
        {
            _context = context;
        }

        public bool IsCompanyAccess(string coCode, decimal secId)
        {
            var userCompanyData = _context.UserCompany.FirstOrDefault(x => x.CoCode == coCode && x.UserAutoId == secId);
            if (userCompanyData != null)
            {
                if (userCompanyData.CoCode != null)
                {
                    return true;
                }

            }
            return false;
        }
    }
}
