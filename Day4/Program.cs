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
    var splitStrings = input.Split(',', '-');
    var splitNumbers = Array.ConvertAll(splitStrings, int.Parse);

    //create the strings

    var elfRangeA = "";
    var elfRangeB = "";

    for (var a = splitNumbers[0]; a <= splitNumbers[1]; a++)
    {
        elfRangeA = elfRangeA + '.' + a;
    }

    for (var b = splitNumbers[2]; b <= splitNumbers[3]; b++)
    {
        elfRangeB = elfRangeB + '.' + b;
    }

    string[] array = new string[2] { elfRangeA, elfRangeB };

    var fullyContains = array[0].Contains(array[1]) || array[1].Contains(array[0]);
    if (fullyContains)
    {
        Console.WriteLine($"{elfRangeA} \r\n + \r\n {elfRangeB} \r\n\r\n");
    }
    return fullyContains;
}