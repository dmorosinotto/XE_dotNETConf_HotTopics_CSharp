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
