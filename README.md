# UrlCombine
The UrlCombine is a [Nuget Package](https://www.nuget.org/packages/UrlCombine) to conveniently combine your base Url and relative url.
This library treats the slashes between the base and relative paths to ensure a valid url.

``` csharp
  using UrlCombine;
```

**There are 3 ways to use the library:**

## Static Method
The static method is used with UrlCombine helper class.
It doesn't matter if the baseUrl and relativePath end/start with a slash or not, The Combine() method takes care of that:

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

## Multiple relative paths in runtime
There's also a UrlCombine.Combine overload (alongside Uri and String extension methods) that takes a param string[] as input:

``` csharp
  var fullUrl = new Uri("www.foo.com.br/").Combine("bar", "zeta");
  // fullUrl = new Uri("www.foo.com.br/bar/zeta")
```

## Why not Uri(Uri base, string relative)?
Well, It does more than just validate the slashes. It strips the relative path of the base Uri if it doesn't end with a slash and if the relative path doesn't start with one:
``` csharp
  var uriBase = new Uri("http://www.foo.com/relative");
  var relative = "/other/url";
  
  var uri = new Uri(uriBase, relative);
  // uri.ToString() = "http://www.foo.com/other/url"
```
