using BreweryDbStandard.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using System.Configuration;

namespace BreweryDbStandard.Tests
{
    [TestClass]
    public class UnitTest1
    {

        BreweryDB breweryDbApi;

        [TestInitialize]
        public void Initialize()
        {
            breweryDbApi = new BreweryDB(GetSecret("BreweryDbApiKey"));
        }

        [TestMethod]
        public async Task BasicSearchAsync()
        {
            var result = await breweryDbApi.Search("Nitro");

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

            var result = await breweryDbApi.Search("Nitro", searchParams);

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

            var result = await breweryDbApi.Search("Nitro", searchParams);

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

            var result = await breweryDbApi.Search("Lakefront", searchParams);

            Assert.AreEqual("success", result.Status);
            Assert.IsTrue(result.NumberOfPages >= 1);
            Assert.AreEqual(1, result.CurrentPage);

            foreach (var item in result.Data)
            {
                Assert.AreEqual(SearchTypes.BREWERY.Value, item.Type);
            }
        }

        private string GetSecret(string key)
        {
            var value = "";

            try
            {
                value = Properties.Settings.Default[key].ToString();

                if (value != null)
                {
                    Console.WriteLine("Using config variable");
                    return value;
                }
            }
            catch (Exception e) { }

            try
            {
                value = Environment.GetEnvironmentVariable(key);

                if (value != null)
                {
                    Console.WriteLine("Using environment variable");
                    return value;
                }
            }
            catch (Exception e) { }

            throw new Exception("Key " + key + " not found");
        }
    }
}
