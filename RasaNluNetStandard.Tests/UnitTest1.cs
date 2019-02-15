using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Threading.Tasks;

namespace IronMooseDevelopment.RasaNlu.Tests
{
    [TestClass]
    public class ClientTests
    {
        RasaNluClient client;

        [TestInitialize]
        public void Initialize()
        {
            client = new RasaNluClient("http://localhost:5000");
        }

        [TestMethod]
        public async Task RasaParse()
        {
            var result = await client.ParseAsRasa("What is the temperature in room 7?", "ama");

            result.Project.ShouldBe("ama");
            result.Entities.ShouldNotBeEmpty();
            result.Intent.ShouldNotBeNull();
        }

        [TestMethod]
        public async Task DialogflowParse()
        {
            var result = await client.ParseAsDialogflow("What is the temperature in room 7?", "ama");

            result.Result.ShouldNotBeNull();
            result.Result.Metadata.ShouldNotBeNull();
            result.Result.Parameters.ShouldNotBeEmpty();
        }

        [TestMethod]
        public async Task LuisParse()
        {
            var result = await client.ParseAsLuis("What is the temperature in room 7?", "ama");

            result.Query.ShouldNotBeNullOrEmpty();
            result.Entities.ShouldNotBeEmpty();
            result.Intents.ShouldNotBeEmpty();
            result.TopScoringIntent.ShouldNotBeNull();
        }
    }
}
