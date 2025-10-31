using AIAssistantAPI.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIAssistantAPI.Service.Interface
{
    public interface IDeskService
    {
        UserDto GetUserData(string userid);
        UserMastDto GetUserDataById(string userid);
        List<AIProviderDto> GetAIProvider();
        List<AIModelDto> GetAIModel();
        List<AIDivisionDto> GetAIDivisions();
        AIDivisionPromptDto GetAIDivisionsSystemPrompt(string divisionName);
        List<AIFieldDto> GetAIFields(string divisionName);
    }
}
