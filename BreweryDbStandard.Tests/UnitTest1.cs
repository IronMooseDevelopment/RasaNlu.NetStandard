using Microsoft.VisualStudio.TestTools.UnitTesting;
using BreweryDbStandard.Models;
using System.Threading.Tasks;

namespace BreweryDbStandard.Tests
{
    [TestClass]
    public class UnitTest1
    {
        IBreweryDbApi breweryDbApi;

        const string key = "cb3c812ce7937e5b778a5bb72bd224b8";

        [TestInitialize]
        public void Initialize()
        {
            breweryDbApi = BreweryDbApiFactory.GenerateNewService();
        }

        [TestMethod]
        public async Task BasicSearchAsync()
        {
            var result = await breweryDbApi.Search(key, "Nitro", null);

            Assert.AreEqual(result.Status, "success");
            Assert.IsTrue(result.NumberOfPages >= 1);
            Assert.AreEqual(result.CurrentPage, 1);
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

            Assert.AreEqual(result.Status, "success");
            Assert.IsTrue(result.NumberOfPages >= 1);
            Assert.AreEqual(result.CurrentPage, 1);
        }

        [TestMethod]
        public async Task BeerTypeSearchAsync()
        {
            var searchParams = new SearchParams()
            {
                Type = SearchTypes.BEER
            };
            var result = await breweryDbApi.Search(key, "Nitro", searchParams);

            Assert.AreEqual(result.Status, "success");
            Assert.IsTrue(result.NumberOfPages >= 1);
            Assert.AreEqual(result.CurrentPage, 1);
            
            foreach (var item in result.Data)
            {
                Assert.AreEqual(item.Type, SearchTypes.BEER);
            }
        }

        [TestMethod]
        public async Task BreweryTypeSearchAsync()
        {
            var searchParams = new SearchParams()
            {
                Type = SearchTypes.BREWERY
            };
            var result = await breweryDbApi.Search(key, "Nitro", searchParams);

            Assert.AreEqual(result.Status, "success");
            Assert.IsTrue(result.NumberOfPages >= 1);
            Assert.AreEqual(result.CurrentPage, 1);

            foreach (var item in result.Data)
            {
                Assert.AreEqual(item.Type, SearchTypes.BREWERY);
            }
        }
    }
}
