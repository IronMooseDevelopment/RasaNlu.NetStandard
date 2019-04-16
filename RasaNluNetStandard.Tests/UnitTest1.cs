using IronMooseDevelopment.RasaNlu.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Shouldly;
using System;
using System.IO;
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

        [TestMethod]
        public void RasaAsLuisDeserialize()
        {
            var json = "{ \"entity\": \"floor 5 room 507\", \"type\": \"Space\", \"startIndex\": 28, \"endIndex\": 43, \"score\": null }";

            Should.NotThrow(() =>
            {
                var response = JsonConvert.DeserializeObject<LuisEntity>(json);
                response.Score.HasValue.ShouldBeFalse();
            });
        }

        [TestMethod]
        public async Task CanTrain()
        {
            var client = new RasaNluClient("http://localhost:5000");

            using (var fileStream = new FileStream("train.yml", FileMode.Open))
            {
                var success = await client.Train(fileStream, "test");
                success.ShouldBeTrue();
            }
        }

        [TestMethod]
        public async Task CanGetStatus()
        {
            var client = new RasaNluClient("http://localhost:5000");

            var status = await client.Status();

            status.AvailableProjects.ShouldNotBeNull();
        }
        
        [TestMethod]
        public async Task RasaProjectNotFound()
        {
            await Assert.ThrowsExceptionAsync<RasaException>(() => client.ParseAsRasa("some test utterance", "noproject"));
        }
    }
}
