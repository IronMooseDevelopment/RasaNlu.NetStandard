using BreweryDbStandard.Models;
using Refit;
using System.Threading.Tasks;

namespace BreweryDbStandard
{

    public interface IBreweryDbApi
    {
        [Get("/v2/search")]
        Task<BreweryDbResponse> Search(string key, [AliasAs("q")] string query, SearchParams searchParams);
    }
}
