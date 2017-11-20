using Refit;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreweryDbStandard
{
    public static class BreweryDbApiFactory
    {
        public static IBreweryDbApi GenerateNewService()
        {
            return RestService.For<IBreweryDbApi>("http://api.brewerydb.com");
        }
    }
}