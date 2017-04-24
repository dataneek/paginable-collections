#addin nuget:?package=Cake.Incubator
#addin nuget:?package=Cake.AppVeyor



var target = Argument("Target", "Default");

var configuration =
    HasArgument("Configuration") ? Argument<string>("Configuration") : 
	HasEnvironmentVariable("Configuration") ? EnvironmentVariable<string>("Configuration") : "Release";

var buildNumber =
    HasArgument("BuildNumber") ? Argument<int>("BuildNumber") :
    AppVeyor.IsRunningOnAppVeyor ? AppVeyor.Environment.Build.Number :
    HasEnvironmentVariable("BuildNumber") ? EnvironmentVariable<int>("BuildNumber") : 0;


Information(string.Format("Configuration: {0}", configuration));
Information(string.Format("Build Number: {0}", buildNumber));

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
                project.FullPath,
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
                project.FullPath,
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