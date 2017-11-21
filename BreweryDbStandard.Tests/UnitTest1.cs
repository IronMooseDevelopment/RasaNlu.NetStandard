using BreweryDbStandard.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace BreweryDbStandard.Tests
{
    [TestClass]
    public class UnitTest1
    {

        BreweryDB breweryDbApi;

        const string key = "cb3c812ce7937e5b778a5bb72bd224b8";

        [TestInitialize]
        public void Initialize()
        {
            breweryDbApi = new BreweryDB();
        }

        [TestMethod]
        public async Task BasicSearchAsync()
        {
            var result = await breweryDbApi.Search(key, "Nitro");

            Assert.AreEqual("success", result.Status);
            Assert.IsTrue(result.NumberOfPages >= 1);
            Assert.AreEqual(1, result.CurrentPage);
        }


        [TestMethod]
        public async Task SearchWithSomeParamsAsync()
        {
            var searchParams = new SearchParams()
            {
                Type = SearchTypes.BEER,
                WithBreweries = true
            };

            var result = await breweryDbApi.Search(key, "Nitro", searchParams);

            Assert.AreEqual("success", result.Status);
            Assert.IsTrue(result.NumberOfPages >= 1);
            Assert.AreEqual(1, result.CurrentPage);

            foreach (var item in result.Data)
            {
                Assert.IsNotNull(item.Breweries);
            }
        }

        [TestMethod]
        public async Task BeerTypeSearchAsync()
        {
            var searchParams = new SearchParams()
            {
                Type = SearchTypes.BEER
            };

            var result = await breweryDbApi.Search(key, "Nitro", searchParams);

            Assert.AreEqual("success", result.Status);
            Assert.IsTrue(result.NumberOfPages >= 1);
            Assert.AreEqual(1, result.CurrentPage);
            
            foreach (var item in result.Data)
            {
                Assert.AreEqual(SearchTypes.BEER.Value, item.Type);
            }
        }

        [TestMethod]
        public async Task BreweryTypeSearchAsync()
        {
            var searchParams = new SearchParams()
            {
                Type = SearchTypes.BREWERY
            };

            var result = await breweryDbApi.Search(key, "Lakefront", searchParams);

            Assert.AreEqual("success", result.Status);
            Assert.IsTrue(result.NumberOfPages >= 1);
            Assert.AreEqual(1, result.CurrentPage);

            foreach (var item in result.Data)
            {
                Assert.AreEqual(SearchTypes.BREWERY.Value, item.Type);
            }
        }
    }
}
