using System;
using System.Collections.Generic;
using System.Text;

namespace BreweryDbStandard.Models
{
    public class SearchTypes
    {
        public string Value { get; set; }

        private SearchTypes(string value)
        {
            Value = value;
        }

        public static SearchTypes ALL { get { return new SearchTypes("all"); } }

        public static SearchTypes BEER { get { return new SearchTypes("beer"); } }

        public static SearchTypes BREWERY { get { return new SearchTypes("brewery"); } }

        public static SearchTypes GUILD { get { return new SearchTypes("guild"); } }

        public static SearchTypes EVENT { get { return new SearchTypes("event"); } }
    }
}
