using System.Text;

//load lines into an in-memory list
var elfCleanupSpots = File.ReadLines(@"CleanupSpots.txt");
var containCount = 0;
var overlapCount = 0;

//var sampleString = "1-8,2-6";

foreach (var spot in elfCleanupSpots) {

    var splitStrings = spot.Split(',', '-');
    var s = Array.ConvertAll(splitStrings, int.Parse);

    bool fullyContains = FullyContainsOneOrTheOther(s);
    bool overlap = CompareOverlaps(s);

    if (fullyContains)
    {
        containCount++;
    }

    if (overlap)
    {
        overlapCount++;
    }
};


Console.WriteLine($"Contain count: {containCount}, Overlap count: {overlapCount}");
Console.ReadLine();

static bool CompareOverlaps(int[] s)
{
    //conditions
    var ruleA = (s[2] >= s[0] && s[2] <= s[3]) && (s[1] >= s[0] && s[1] <= s[3]) && (s[2] <= s[1]);
    var ruleB = (s[0] >= s[2] && s[0] <= s[1]) && (s[3] >= s[2] && s[3] <= s[1]) && (s[0] <= s[3]);


    if (ruleA || ruleB || FullyContainsOneOrTheOther(s))
    {
        return true;
    }

    return false;
}

static bool FullyContainsOneOrTheOther(int[] splitNumbers)
{
    var aContainsB = (splitNumbers[2] >= splitNumbers[0]) && (splitNumbers[3] <= splitNumbers[1]);
    var bContainsA = (splitNumbers[0] >= splitNumbers[2]) && (splitNumbers[1] <= splitNumbers[3]);

    //check which range is the highest/longest
    if (aContainsB || bContainsA) { 
        return true; 
    }
    else
    {
        return false;
    }
}