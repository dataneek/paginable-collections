//#addin nuget:?package=Cake.AppVeyor

var target = Argument("Target", "Default");

// Configuration - The build configuration (Debug/Release) to use.
// 1. If command line parameter parameter passed, use that.
// 2. Otherwise if an Environment variable exists, use that.
var configuration = "Release";
   // HasArgument("Configuration") ? Argument("Configuration") :
    //EnvironmentVariable("Configuration") != null ? EnvironmentVariable("BuildNumber") : "Release";


var buildNumber =
    HasArgument("BuildNumber") ? Argument<int>("BuildNumber") :
    AppVeyor.IsRunningOnAppVeyor ? AppVeyor.Environment.Build.Number :
    EnvironmentVariable("BuildNumber") != null ? int.Parse(EnvironmentVariable("BuildNumber")) : 1;

var artifactsDirectory = Directory("./artifacts");

Task("Clean")
    .Does(() =>
    {
        CleanDirectory(artifactsDirectory);
    });

Task("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
    {
        DotNetCoreRestore();
    });

Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
    {
        var projects = GetFiles("./**/*.csproj");
        foreach(var project in projects)
        {
            DotNetCoreBuild(
                project.GetDirectory().FullPath,
                new DotNetCoreBuildSettings()
                {
                    Configuration = configuration
                });
        }
    });

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
    {
        var projects = GetFiles("./tests/**/*.csproj");
        foreach(var project in projects)
        {
            DotNetCoreTest(
                project.FullPath,
                new DotNetCoreTestSettings()
                {
                    Configuration = configuration,
                    NoBuild = true
                });
        }
    });

Task("Pack")
    .IsDependentOn("Test")
    .Does(() =>
    {
		var projects = GetFiles("./src/**/*.csproj");
        foreach (var project in projects)
        {
            DotNetCorePack(
                project.GetDirectory().FullPath,
                new DotNetCorePackSettings()
                {
                    Configuration = configuration,
                    OutputDirectory = artifactsDirectory,
                });
        }
    });


Task("Default")
    .IsDependentOn("Pack");



RunTarget(target);