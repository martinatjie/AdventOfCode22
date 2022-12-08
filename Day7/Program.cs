using Day7;

var terminalInput = File.ReadLines(@"Terminal.txt");

var activeDirectory = new ElfDirectory();

var mainDirectory = new ElfDirectory();
mainDirectory.Id = 0;
mainDirectory.DirectoryName = "Root";
var directoryTree = new List<ElfDirectory>();

var previousDirectory = new ElfDirectory();

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
            totalLevelCount -= 1;
            var nextDirectoryName = string.Concat(line.Skip(5).Take(line.Length - 5));
            Console.WriteLine($"..........Changing directory from {activeDirectory.DirectoryName} to {nextDirectoryName}");

            previousDirectory = activeDirectory;

            //change the active directory when done
            var subDirectories = activeDirectory.DirectSubDirectories;
            var foundDirectory = subDirectories.Where(d => d.DirectoryName.Equals(nextDirectoryName)).ToList();
            activeDirectory = foundDirectory.First();

        }
        else
        {
            totalLevelCount+= 1;
            //buggy
            //activeDirectory = activeDirectory.Equals(previousDirectory) ? mainDirectory : previousDirectory;
            activeDirectory = previousDirectory;
            Console.WriteLine($"..........Moving back from {previousDirectory.DirectoryName} to {activeDirectory.DirectoryName}");
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

//find all directories below the threshold regardless of where they are in the hierarchy
//now find their sum

var sizes = new List<int>();
sizes = GetSizesBelowThreshold(mainDirectory, sizes);

var sum = sizes.Sum();

Console.WriteLine($"sum of all directories below threshold: {sum}");

Console.ReadLine();

List<int> GetSizesBelowThreshold(ElfDirectory parentDirectory, List<int> childDirectorySizes)
{
    if (childDirectorySizes == null)
    {
        childDirectorySizes = new List<int>();
    }

    foreach (var childDirectory in parentDirectory.DirectSubDirectories.Where(d => d.BelowThreshold.Equals(true)))
    {
        childDirectorySizes.Add(childDirectory.Size);
        GetSizesBelowThreshold(childDirectory, childDirectorySizes);
    }
    return childDirectorySizes;
}