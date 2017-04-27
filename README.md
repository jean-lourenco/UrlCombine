# UrlCombine
The UrlCombine is a [Nuget Package](https://www.nuget.org/packages/UrlCombine/1.0.0) to conveniently combine your base Url and relative url.
This library treats the slashes between the base and relative paths to ensure a valid url.

``` csharp
  using UrlCombine;
```

**There are 3 ways to use the library:**

## Static Method
The static method is used with UrlCombine helper class:

``` csharp
  var fullUrl = UrlCombine.Combine("www.foo.com.br/", "/bar/zeta");
  // fullUrl = "www.foo.com.br/bar/zeta"
```

## String Extension
The string extesion is used with the CombineUrl method:

``` csharp
  var fullUrl = "www.foo.com.br/".CombineUrl("/bar/zeta");
  // fullUrl = "www.foo.com.br/bar/zeta"
```

## Uri Extension
The Uri extension is used with the Combine method:

``` csharp
  var fullUrl = new Uri("www.foo.com.br/").Combine("/bar/zeta");
  // fullUrl = new Uri("www.foo.com.br/bar/zeta")
```

## Why not Uri(Uri base, string relative)?
Well, It does more than just validating the slashes. It strips the relative path of the base Uri if it doesn't end with a slash and if the relative path doesn't start with one:
``` csharp
  var uriBase = new Uri("http://www.foo.com/relative");
  var relative = "/other/url";
  
  var uri = new Uri(uriBase, relative);
  // uri.ToString() = "http://www.foo.com/other/url"
```

## License
The MIT License (MIT)

Copyright 2017 Jean Lourenço

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
