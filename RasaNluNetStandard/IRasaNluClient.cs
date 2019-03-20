using System.IO;
using System.Threading.Tasks;
using IronMooseDevelopment.RasaNlu.Models;

namespace IronMooseDevelopment.RasaNlu
{
    public interface IRasaNluClient
    {
        Task<DialogflowParseResponse> ParseAsDialogflow(string parseQuery, string project);

        Task<LuisParseResponse> ParseAsLuis(string parseQuery, string project);

        Task<RasaParseResponse> ParseAsRasa(string parseQuery, string project);

        Task<bool> Train(FileStream trainDataYamlFile, string project);

        Task<RasaStatus> Status();
    }
}
