using BreweryDbStandard.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BreweryDbStandard
{
    // Partially generated with https://quicktype.io

    public partial class BreweryDbResponse
    {
        [JsonProperty("currentPage")]
        public long CurrentPage { get; set; }

        [JsonProperty("data")]
        public List<Beer> Data { get; set; }

        [JsonProperty("numberOfPages")]
        public long NumberOfPages { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("totalResults")]
        public long TotalResults { get; set; }
    }

    public partial class Beer
    {
        [JsonProperty("abv")]
        public string Abv { get; set; }

        [JsonProperty("available")]
        public Available Available { get; set; }

        [JsonProperty("availableId")]
        public long? AvailableId { get; set; }

        [JsonProperty("breweries")]
        public List<Brewery> Breweries { get; set; }

        [JsonProperty("createDate")]
        public string CreateDate { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("glass")]
        public Category Glass { get; set; }

        [JsonProperty("glasswareId")]
        public long? GlasswareId { get; set; }

        [JsonProperty("ibu")]
        public string Ibu { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("isOrganic")]
        public string IsOrganic { get; set; }

        [JsonProperty("labels")]
        public Labels Labels { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nameDisplay")]
        public string NameDisplay { get; set; }

        [JsonProperty("originalGravity")]
        public string OriginalGravity { get; set; }

        [JsonProperty("servingTemperature")]
        public string ServingTemperature { get; set; }

        [JsonProperty("servingTemperatureDisplay")]
        public string ServingTemperatureDisplay { get; set; }

        [JsonProperty("srm")]
        public Srm Srm { get; set; }

        [JsonProperty("srmId")]
        public long? SrmId { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("statusDisplay")]
        public string StatusDisplay { get; set; }

        [JsonProperty("style")]
        public Style Style { get; set; }

        [JsonProperty("styleId")]
        public long StyleId { get; set; }

        [JsonProperty("type")]
        public SearchTypes Type { get; set; }

        [JsonProperty("updateDate")]
        public string UpdateDate { get; set; }
    }

    public partial class Style
    {
        [JsonProperty("abvMax")]
        public string AbvMax { get; set; }

        [JsonProperty("abvMin")]
        public string AbvMin { get; set; }

        [JsonProperty("category")]
        public Category Category { get; set; }

        [JsonProperty("categoryId")]
        public long CategoryId { get; set; }

        [JsonProperty("createDate")]
        public string CreateDate { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("fgMax")]
        public string FgMax { get; set; }

        [JsonProperty("fgMin")]
        public string FgMin { get; set; }

        [JsonProperty("ibuMax")]
        public string IbuMax { get; set; }

        [JsonProperty("ibuMin")]
        public string IbuMin { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ogMax")]
        public string OgMax { get; set; }

        [JsonProperty("ogMin")]
        public string OgMin { get; set; }

        [JsonProperty("shortName")]
        public string ShortName { get; set; }

        [JsonProperty("srmMax")]
        public string SrmMax { get; set; }

        [JsonProperty("srmMin")]
        public string SrmMin { get; set; }

        [JsonProperty("updateDate")]
        public string UpdateDate { get; set; }
    }

    public partial class Srm
    {
        [JsonProperty("hex")]
        public string Hex { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Labels
    {
        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("large")]
        public string Large { get; set; }

        [JsonProperty("medium")]
        public string Medium { get; set; }
    }

    public partial class Category
    {
        [JsonProperty("createDate")]
        public string CreateDate { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Brewery
    {
        [JsonProperty("brandClassification")]
        public string BrandClassification { get; set; }

        [JsonProperty("createDate")]
        public string CreateDate { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("established")]
        public string Established { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("images")]
        public Images Images { get; set; }

        [JsonProperty("isMassOwned")]
        public string IsMassOwned { get; set; }

        [JsonProperty("isOrganic")]
        public string IsOrganic { get; set; }

        [JsonProperty("locations")]
        public List<Location> Locations { get; set; }

        [JsonProperty("mailingListUrl")]
        public string MailingListUrl { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nameShortDisplay")]
        public string NameShortDisplay { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("statusDisplay")]
        public string StatusDisplay { get; set; }

        [JsonProperty("updateDate")]
        public string UpdateDate { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }
    }

    public enum Status
    {
        VERIFIED,
        NEW_UNVERIFIED,
        UPDATE_PENDING,
        DELETE_PENDING,
        DELETED
    }

    public partial class Location
    {
        [JsonProperty("country")]
        public Country Country { get; set; }

        [JsonProperty("countryIsoCode")]
        public string CountryIsoCode { get; set; }

        [JsonProperty("createDate")]
        public string CreateDate { get; set; }

        [JsonProperty("extendedAddress")]
        public string ExtendedAddress { get; set; }

        [JsonProperty("hoursOfOperation")]
        public string HoursOfOperation { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("inPlanning")]
        public string InPlanning { get; set; }

        [JsonProperty("isClosed")]
        public string IsClosed { get; set; }

        [JsonProperty("isPrimary")]
        public string IsPrimary { get; set; }

        [JsonProperty("latitude")]
        public double? Latitude { get; set; }

        [JsonProperty("locality")]
        public string Locality { get; set; }

        [JsonProperty("locationType")]
        public string LocationType { get; set; }

        [JsonProperty("locationTypeDisplay")]
        public string LocationTypeDisplay { get; set; }

        [JsonProperty("longitude")]
        public double? Longitude { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("openToPublic")]
        public string OpenToPublic { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("statusDisplay")]
        public string StatusDisplay { get; set; }

        [JsonProperty("streetAddress")]
        public string StreetAddress { get; set; }

        [JsonProperty("updateDate")]
        public string UpdateDate { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("yearOpened")]
        public string YearOpened { get; set; }
    }

    public partial class Country
    {
        [JsonProperty("createDate")]
        public string CreateDate { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("isoCode")]
        public string IsoCode { get; set; }

        [JsonProperty("isoThree")]
        public string IsoThree { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("numberCode")]
        public long NumberCode { get; set; }
    }

    public partial class Images
    {
        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("large")]
        public string Large { get; set; }

        [JsonProperty("medium")]
        public string Medium { get; set; }

        [JsonProperty("squareLarge")]
        public string SquareLarge { get; set; }

        [JsonProperty("squareMedium")]
        public string SquareMedium { get; set; }
    }

    public partial class Available
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}