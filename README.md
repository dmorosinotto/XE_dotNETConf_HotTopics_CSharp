# XE_dotNETConf_HotTopics_CSharp11

XE dotNETConf HotTopics - C# 11 - Session 18-11-2022

Added [samples](CSharp11) to demonstrate new features of C# 11 for my [XE](https://www.xedotnet.org/) online session about [.NET Conf 2022 HotTopics](https://www.xedotnet.org/eventi/net-conf-2022-hot-topics/) to try it you must install [.NET 7](https://dotnet.microsoft.com/download) + open a terminal in VSCode and run **dotnet watch** - you can test every single example modifing [Program.cs](CSharp11/Program.cs) for "live" esample you can check diff from files `XXX_init.cs -> XXX_mid.cs -> XXX_ok.cs` inside the single _EXn_ folder.

# XE_dotNETConf_HotTopics_CSharp10

XE dotNETConf HotTopics - C# 10 - Session 12-11-2021

Added a .NET Interactive [notebook](CSharp10.dib) to demonstrate new features of C# 10 for my [XE](https://www.xedotnet.org/) online session about [dotNETConf 2021 HotTopics](https://www.xedotnet.org/eventi/dotnet-conf-2021-hot-topics/) to try it you must install [.NET 6](https://dotnet.microsoft.com/download) + **.NET Interactive** [extension for VSCode](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.dotnet-interactive-vscode)

# XE_dotNETConf_HotTopics_CSharp9

XE dotNETConf HotTopics - C# 9 - Session 13-11-2020

This repo contains some [slides](slides.pdf) and all the DEMO for my [XE](https://www.xedotnet.org/) online session about [dotNETConf 2020 HotTopics](https://www.xedotnet.org/eventi/xe-online-meeting-novembre/) where I talk about [C# 9](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9)

## Initial setup project

I used latest [official release](https://dotnet.microsoft.com/download/dotnet/5.0) of **.NET 5** and create a simple [Console App](https://docs.microsoft.com/it-it/dotnet/core/tools/dotnet-new) for easy startup:

```bash
dotnet new console -n csharp9 -o csharp9
cd csharp9
dotnet run
```

I also edited the default [csharp9.csproj](csharp9.csproj) file to specify the C# Languauge 9

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net5.0</TargetFramework>
    <LangVersion>9.0</LangVersion>
    <Nullable>enable</Nullable>
 </PropertyGroup>

</Project>
```

## Try it

To try my project sample simply open [VSCode](https://code.visualstudio.com) and install [C# Extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) when promted

Than in the integrated Terminal simply run `dotnet watch run` to execute the code, and follow istruction in the comment to run/test all my sample one-by-one to learn the new C# 9 features:

-   [Top Level Program](Program.cs) + basic [Class](Sample0.cs)
-   [Init Only Properties](Sample1.cs)
-   Manual [Immutable](Sample2.cs) class
-   [Record](Sample3.cs) + with-expression
-   [Positional Record](Sample4.cs) + destructuring and inheritance
-   [Target Type new-Expression](Sample5.cs)
-   Enhanced [Pattern Match](Sample6.cs)

---

### References

If you need more details about C#9 take a look at:

-   C# 9 Realese [notes](https://devblogs.microsoft.com/dotnet/c-9-0-on-the-record/)
-   Official C#9 What's new [docs](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9)
-   dotNETConf 2020 What's new in C# 9 [video](https://youtu.be/x3kWzPKoRXc)
-   Great @MadsTorgersen talk about Future of C# 9+ [video](https://usergroup.tv/videos/the-future-of-c/)
-   [Article](https://www.strathweb.com/2020/10/beautiful-and-compact-web-apis-with-c-9-net-5-0-and-asp-net-core/) about _"minimal" CRUD Web API_ using new C# 9 featues

If you need more details about C#10 take a look at:

-   Official C# 10 What's new [docs](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10)
-   C# 10 .NET 6 Improvment new features [video](https://youtu.be/y8xcUrEidpc)

If you need more details about C#11 take a look at:

-   Official C# 11 What's new [docs](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-11/)
-   Great @MadsTorgersen talk about Future of C# 11 [video](https://youtu.be/1K44Nu9_7U8)
-   Tutorial about implementing [static virtual interface](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/static-virtual-interface-members)
-   Docs about [INumber<T>](https://learn.microsoft.com/en-us/dotnet/standard/generics/math)
