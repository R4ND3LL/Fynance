<div align="center">

![Fynance](https://raw.githubusercontent.com/felipeoriani/Fynance/master/logo.png)

</div>

<div align="center">

[![Build Status](https://img.shields.io/github/workflow/status/felipeoriani/Fynance/Build)](https://img.shields.io/github/workflow/status/felipeoriani/Fynance/Build)
[![NuGet](https://img.shields.io/nuget/v/fynance.svg)](https://www.nuget.org/packages/Fynance)
[![GitHub Stars](https://img.shields.io/github/stars/felipeoriani/fynance.svg)](https://github.com/felipeoriani/fynance/stargazers)
[![GitHub Issues](https://img.shields.io/github/issues/felipeoriani/fynance.svg)](https://github.com/felipeoriani/fynance/issues)
[![Apache License](https://img.shields.io/github/license/felipeoriani/fynance.svg)](LICENSE)

</div>

Fynance is a handy wrapper to get stock market quotes written in .Net Standard. It is currently support the Yahoo Finance but it can be extended to other APIs.

## Installation - Nuget Package

This is available on [nuget package](https://www.nuget.org/packages/Fynance).

```
Install-Package Fynance
```

To update the package to the last version use the following nuget statement:

```
Update-Package Fynance
``` 

## Features

- Get Security Info
- Get Quotes 
- Get Events
  - Get Dividends
  - Get Splits

### Samples

First you have to add the `Fynance` namespace to make the types available on your code:

```
using Fynance;
```

The *Fynance* implements a fluent interface to read data from a stock market api. Given it, a instance of `Ticker` is a representation of a security on the stock market. Then you can make an instance of `Ticker` and use all the methods to configure what you want to have until call the `Get` method. There is a `async` version of this method called `GetAsync`. The following code is a sample of use:

```
var result = await Ticker.Build()
                         .SetSymbol("MSFT")
                         .SetPeriod(Period.OneMonth)
                         .SetInterval(Interval.OneDay)
                         .GetAsync();
```

The `Build` method instance the `Ticker` object and all these `Set` methods configure what information you want to get from the available APIs.

To the the * events* as we call *dividends* or *splits* you can use `SetDividends` and `SetEvents` to define it:
```
var result = await Ticker.Build()
                         .SetSymbol("MSFT")
                         .SetPeriod(Period.OneMonth)
                         .SetInterval(Interval.OneDay)
                         .SetDividends(true)
                         .SetEvents(true)
                         .GetAsync();
```

### Issue Reports

If you find any issue, please report them using the [GitHub issue tracker](https://github.com/felipeoriani/Fynance/issues). Would be great if you provide a sample of code or a repository with a sample project.

### Licenses

This software is distributed under the terms of the *Apache License 2.0*. Please, read the [LICENSE](https://github.com/felipeoriani/Fynance/blob/master/LICENSE) file available on this repository.

### Credits

This project is a collab of [@FelipeOriani](https://github.com/felipeoriani/) and [@EduVencovsky](https://github.com/eduvencovsky/).

Many thanks for the [Newtonsoft.Json](https://www.newtonsoft.com/json) packaged used as a dependency of this project.
