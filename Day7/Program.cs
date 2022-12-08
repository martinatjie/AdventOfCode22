using Day7;

var terminalInput = File.ReadLines(@"TerminalSample.txt");

var activeDirectory = new ElfDirectory();

var mainDirectory = new ElfDirectory();
mainDirectory.Id = 0;
mainDirectory.DirectoryName = "Root";
var directoryTree = new List<ElfDirectory>();

var previousDirectory = mainDirectory;

var totalLevelCount = 1;


foreach (var line in terminalInput)
{
    Console.WriteLine($"executing {line}");

    if (line.Equals("$ cd /"))
    {
        activeDirectory = mainDirectory;
    }
    else if (line.Equals("$ ls")) {
        //start adding sub-files and folders to the directory
        Console.WriteLine($"..........Listing directory {activeDirectory.Id} - {activeDirectory.DirectoryName}");
    }
    else if (line.Contains("dir"))
    {
        //add that directory name to the current directory's list of subdirectories
        var newSubdirectory = new ElfDirectory();
        string directoryName = string.Concat(line.Skip(4).Take(line.Length - 4));
        newSubdirectory.DirectoryName = directoryName;

        activeDirectory.DirectSubDirectories.Add(newSubdirectory);

        Console.WriteLine($"..........Added {newSubdirectory.DirectoryName} to listing of {activeDirectory.DirectoryName}");
    }
    else if (line.Contains("cd"))
    {
        if (!line.Equals("$ cd ..")){
            //totalLevelCount -= 1;
            var nextDirectoryName = string.Concat(line.Skip(5).Take(line.Length - 5));
            Console.WriteLine($"..........Changing directory from {activeDirectory.DirectoryName} to {nextDirectoryName}");

            previousDirectory = activeDirectory;

            //change the active directory when done
            activeDirectory = activeDirectory.DirectSubDirectories.Where(n => n.DirectoryName.Equals(nextDirectoryName)).First();

        }
        else
        {
            totalLevelCount+= 1;
            activeDirectory = activeDirectory.Equals(previousDirectory) ? mainDirectory : previousDirectory;
            Console.WriteLine($"..........Moving back from {previousDirectory} to {activeDirectory}");
        }
    }
    else
    {
        //add file to file listing of active directory
        var fileToAdd = line.Split(" ");
        var fileSize = int.Parse(fileToAdd[0]);

        //size logic
        //sums of nested files plus sums of totals of subdirectories

        var file = new ElfFile { FileName = fileToAdd[1], Size = fileSize };
        activeDirectory.DirectFiles.Add(file);

        Console.WriteLine($"..........Adding file {fileToAdd[1]} of size {fileSize}. Size of all sub directories is {activeDirectory.SubDirectoryTotal}. Directory {activeDirectory.DirectoryName} size is now {activeDirectory.Size}");
    }
}

Console.WriteLine($"Main directory size = {mainDirectory.Size} and the sum of all files below the threshold is {mainDirectory.BelowThresholdTotal}");

//find all directories below the threshold regardless of where they are in the hierarchy
//now find their sum

int sum = CalculateSumRecursively(mainDirectory);

Console.ReadLine();

[Obsolete("not returning the right value at present")]
int CalculateSumRecursively(ElfDirectory parentDirectory, int sum = 0)
{
    foreach (var childDirectory in parentDirectory.DirectSubDirectories.Where(d => d.BelowThreshold.Equals(true)))
    {
        if (childDirectory.BelowThreshold.Equals(true))
        {
            sum += childDirectory.Size;
            return sum += CalculateSumRecursively(childDirectory, sum);
        }
    }
    return sum;
}