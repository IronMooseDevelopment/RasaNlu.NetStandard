# BreweryDbStandard

![](https://cswendrowski.visualstudio.com/_apis/public/build/definitions/ec071271-3590-43d2-b089-e62d4b125c9a/5/badge)
[![NuGet](https://img.shields.io/nuget/v/BreweryDbStandard.svg)](https://www.nuget.org/packages/BreweryDbStandard)

## Usage

### Create a Client

```csharp
var breweryDbClient = new BreweryDB("YOUR API KEY");
```

### Basic Search

```csharp
var result = await breweryDbClient.Search("Nitro Stout");

foreach (var beer in result.Data)
{
    Console.WriteLine(beer.Name);
}
```

### Search with Parameters

```csharp
var searchParams = new SearchParams()
{
    Type = SearchTypes.BEER,
    WithBreweries = true
};

var result = await breweryDbClient.Search("Nitro Stout", searchParams);

foreach (var beer in result.Data)
{
    Console.WriteLine(beer.Name);
}
```

#### A Note on Premium Features

BreweryDB has a collection of premium-only queries and data, documented [here](http://www.brewerydb.com/developers/docs-endpoint/search_index). All `SearchParams` that are premium-only have been annotated `[Premium]`. This library does nothing with this metadata, but it is useful for your reference.

## Roadmap

- [x] Minimal .NET Standard Version
- [x] Swap to HttpClient
- [x] Basic Search Functionality
- [x] Search Parameters
- [x] `[Premium]` Annotation
- [ ] Expand to other API calls


## License
MIT License

Copyright (c) 2017 Cody Swendrowski

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
