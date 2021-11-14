using System.Diagnostics;

string directory = @"C:\Users\RB\Documents\Books\The C# Player's Guide\Solutions\5thEdition\";

foreach (var solutionFile in Directory.EnumerateFiles(directory, "*.sln", SearchOption.AllDirectories))
    File.WriteAllLines(solutionFile, UpgradeSolutionFileText(solutionFile, File.ReadAllLines(solutionFile)));

foreach (var projectFile in Directory.EnumerateFiles(directory, "*.csproj", SearchOption.AllDirectories))
    File.WriteAllLines(projectFile, UpgradeProjectFileText(File.ReadAllLines(projectFile)));


string[] UpgradeSolutionFileText(string file, string[] lines)
{
    bool foundComment = false;
    bool foundVersion = false;
    for (int index = 0; index < lines.Length; index++)
    {
        string line = lines[index];
        if (line == "# Visual Studio Version 16")
        {
            lines[index] = "# Visual Studio Version 17";
            foundComment = true;
        }
        if (line.StartsWith("VisualStudioVersion"))
        {
            lines[index] = "VisualStudioVersion = 17.0.31903.59";
            foundVersion = true;
        }
    }

    Debug.Assert(foundComment);
    Debug.Assert(foundVersion);

    return lines;
}

string[] UpgradeProjectFileText(string[] lines)
{
    bool foundFrameworkVersion = false;
    for (int index = 0; index < lines.Length; index++)
    {
        string line = lines[index];
        if (line == "    <TargetFramework>net5.0</TargetFramework>")
        {
            lines[index] = "    <TargetFramework>net6.0</TargetFramework>\r\n" +
                           "    <ImplicitUsings>enable</ImplicitUsings>\r\n" +
                           "    <Nullable>enable</Nullable>";
            foundFrameworkVersion = true;
        }
    }

    Debug.Assert(foundFrameworkVersion);

    return lines;
}