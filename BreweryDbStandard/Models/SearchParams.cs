using Refit;

namespace BreweryDbStandard.Models
{
    public class SearchParams
    {
        [AliasAs("p")]
        public int? PageNumber { get; set; } = null;

        public SearchTypes? Type { get; set; } = null;

        public bool? WithBreweries { get; set; } = null;

        [Premium]
        public bool? WithSocialAccounts { get; set; } = null;

        [Premium]
        public bool? WithGuilds { get; set; } = null;

        [Premium]
        public bool? WithLocations { get; set; } = null;

        [Premium]
        public bool? WithAlternateNames { get; set; } = null;

        [Premium]
        public bool? WithIngredients { get; set; } = null;

        [Premium]
        public string Status { get; set; } = null;

    }

    public enum SearchTypes
    {
        BREWERY,
        BEER,
        GUILD,
        EVENT
    }
}
