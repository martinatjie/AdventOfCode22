//Challenge: get the total sum of all directories below a certain size

using Day7;

var terminalInput = File.ReadLines(@"Terminal.txt");
var threshold = 100000;

foreach (var line in terminalInput)
{
    if (line.Equals("$ ls"))
    {
        CommunicationSystemService.BuildListing();
    }
    else if (line.StartsWith("dir"))
    {
        var directoryName = string.Concat(line.Skip(4).Take(line.Length - 4));

        CommunicationSystemService.AddDirectory(directoryName);
    }
    else if (!line.StartsWith("$ cd") && !line.StartsWith("dir"))
    {
        var fileToAdd = line.Split(" ");

        var file = new ElfFile { FileName = fileToAdd[1], Size = int.Parse(fileToAdd[0]) };

        CommunicationSystemService.AddFile(file);
    }
    else if (line.StartsWith("$ cd"))
    {
        if (line.Equals("$ cd /"))
        {
            CommunicationSystemService.NavigateToRoot();
        }
        else if (line.Equals("$ cd .."))
        {
            CommunicationSystemService.NavigateBack();
        }
        else
        {
            var directoryName = string.Concat(line.Skip(5).Take(line.Length - 5));
            CommunicationSystemService.NavigateTo(directoryName);
        }
    }
}

var sizes = CommunicationSystemService.CalculateSumOfDirectorySizesBelowThreshold(threshold);
Console.WriteLine($"sum of all directories below threshold: {sizes}");

var sizeOnDisk = 70000000;

var usedSpace = CommunicationSystemService.GetRootDiskSize();

var spaceNeededForUpdate = 30000000;

var howMuchToDelete = CommunicationSystemService.HowMuchSpaceDoWeNeedToMake(sizeOnDisk, usedSpace, spaceNeededForUpdate);

var smallestEligibleDirectorySize = CommunicationSystemService.FindDirectoryToDelete(howMuchToDelete);

Console.WriteLine($"smallest directory to delete that is closest to the target to run the update: {smallestEligibleDirectorySize}");

Console.ReadLine();
