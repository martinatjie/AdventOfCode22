using System.Collections;
using System.Linq;

//create a reference for letters a-z and A-Z and their priorities

var priority = 1;
Dictionary<int, char> priorities = new Dictionary<int, char>();

//1-26
for (char c = 'a'; c <= 'z'; c++)
{
    priorities.Add(priority, c);
    priority++;
}

//27-...
for (char c = 'A'; c <= 'Z'; c++)
{
    priorities.Add(priority, c);
    priority++;
}

var sumOfPrioritizedLettersPart1 = 0;
var sumOfPrioritizedLettersPart2 = 0;

//load lines into an in-memory list
var allLines = File.ReadLines(@"RucksackContent.txt");
var lineGroups = allLines.Count() / 3;
var take = 3;

/// <summary>
/// part 2
/// </summary>
for(int i = 0; i < lineGroups; i++)
{
    var skipAmount = i == 0 ? i : i * 3;
    
    //skip i*3, take 3
    var elfGroup = allLines.Skip(skipAmount).Take(take).ToArray();

    //get common priority for the set of 3
    char commonCharacter = elfGroup[0].Intersect(elfGroup[1].Intersect(elfGroup[2])).First();

    //select the number in the priority reference where the recorded character equals the character in the reference and add it to the sum
    var commonPriority = priorities.Where(p => p.Value.Equals(commonCharacter)).First().Key;

    //add this priority to the sum
    sumOfPrioritizedLettersPart2 = sumOfPrioritizedLettersPart2 + commonPriority;
}

/// <summary>
/// part 2
/// </summary>
foreach (string line in allLines)
{
    //count number of characters in line and check for evenness
    var characterCount = line.Length;
    var evenCheck = characterCount % 2;
    if (evenCheck == 0)
    {
        var chunkSize = characterCount / 2;
        //if character count is even, split into two substrings

        var firstChunk = line.Substring(0, chunkSize).ToArray();
        var secondChunk = line.Substring(chunkSize, chunkSize).ToArray();

        //now compare the two sets of arrays and return the char that is the same in both sets
        char commonCharacter = firstChunk.Intersect(secondChunk).First();

        //select the number in the priority reference where the recorded character equals the character in the reference and add it to the sum
        var selectedPriority = priorities.Where(p => p.Value.Equals(commonCharacter)).First().Key;
        sumOfPrioritizedLettersPart1 = sumOfPrioritizedLettersPart1 + selectedPriority;
    }
    else
    {
        Console.WriteLine($"{line} is not even. Cannot perform action.");
    }

}

//now return the sum
Console.WriteLine($"answer part 1: {sumOfPrioritizedLettersPart1}");
Console.WriteLine($"answer part 2: {sumOfPrioritizedLettersPart2}");

Console.WriteLine("Day 3, done and dusted!");
Console.ReadLine();