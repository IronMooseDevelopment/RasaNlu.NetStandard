using BreweryDbStandard.Attributes;

namespace BreweryDbStandard.Models
{
    public class SearchParams
    {
        public int? PageNumber { get; set; } = null;

        public SearchTypes Type { get; set; } = SearchTypes.ALL;

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
}
