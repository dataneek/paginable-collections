PaginableCollections
====================

[![Build status](https://ci.appveyor.com/api/projects/status/8hedo7ja62gaq022?svg=true)](https://ci.appveyor.com/project/neekgreen/paginablecollections)
[![NuGet](https://img.shields.io/nuget/v/paginablecollections.svg)](https://www.nuget.org/packages/paginablecollections) 
[![NuGet](https://img.shields.io/nuget/dt/paginablecollections.svg)](https://www.nuget.org/packages/paginablecollections) 
[![CodeFactor](https://www.codefactor.io/repository/github/neekgreen/paginable-collections/badge)](https://www.codefactor.io/repository/github/neekgreen/paginablecollections)

A light weight pagination framework for .NET and .NET Core.

[![something](https://img.shields.io/badge/.NET-4.5-blue.svg)](https://img.shields.io/badge/.NET-4.5-blue.svg)
[![something](https://img.shields.io/badge/.netstandard-1.3-blue.svg)](https://img.shields.io/badge/.netstandard-1.3-blue.svg)
[![something](https://img.shields.io/badge/.netstandard-2.0-blue.svg)](https://img.shields.io/badge/.netstandard-1.3-blue.svg)

### Installing PaginableCollections

You should install [PaginableCollections with NuGet](https://www.nuget.org/packages/paginablecollections):

    Install-Package PaginableCollections
    
This command will download and install PaginableCollections. Let me know if you have questions!


## TD;DR

```csharp

var numbers = new int[] { 2, 4, 5, 1, 6, 8, 2, 0, 4, 3, 4, 1, 5, 9, 7, 0, 2, 4, 8, 9 };

var pageNumber = 2;
var itemCountPerPage = 6;

var paginable = numbers.ToPaginable(pageNumber, itemCountPerPage);

foreach(var t in paginable)
{
    Console.WriteLine($"{t.ItemNumber}, {t.Item}");
}

//output
1, 2
2, 0
3, 4
4, 3
5, 4 
6, 1
