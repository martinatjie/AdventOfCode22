using System.Text;

//load lines into an in-memory list
var elfCleanupSpots = File.ReadLines(@"CleanupSpots.txt");
var containCount = 0;

//var sampleString = "1-8,2-6";

foreach (var spot in elfCleanupSpots) {
    bool fullyContains = CompareCleanupSpots(spot);

    if (fullyContains)
    {
        containCount++;
    }
};


Console.WriteLine(containCount);
Console.ReadLine();

static bool CompareCleanupSpots(string input)
{
    var fullyContains = false;
    var splitStrings = input.Split(',', '-');
    var splitNumbers = Array.ConvertAll(splitStrings, int.Parse);

    var aContainsB = (splitNumbers[2] >= splitNumbers[0]) && (splitNumbers[3] <= splitNumbers[1]);
    var bContaisnA = (splitNumbers[0] >= splitNumbers[2]) && (splitNumbers[1] <= splitNumbers[3]);

    //check which range is the highest/longest
    if (aContainsB || bContaisnA) { fullyContains = true; };

    return fullyContains;
}