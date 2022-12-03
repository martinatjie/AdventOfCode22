//read file line by line
using System.Collections;
using System.Linq;

//create a reference for letters a-z and A-Z and their priorities

var priority = 1;
//Hashtable priorities = new Hashtable();
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

var sumOfPrioritizedLetters = 0;

foreach (string line in File.ReadLines(@"RucksackContent.txt"))
{
    //count number of characters in line and check for evenness
    var characterCount = line.Length;
    var evenCheck = characterCount % 2;
    if (evenCheck == 0)
    {
        var chunkSize = characterCount / 2;
        //if character count is even, split into two substrings
        //var lineChunks = line.Split(null, chunkSize);

        //split characters into an array
        //char[] firstChunk = lineChunks[0].ToArray();
       // char[] secondChunk = lineChunks[0].ToArray();

        var firstChunk = line.Substring(0, chunkSize).ToArray();
        var secondChunk = line.Substring(chunkSize, chunkSize).ToArray();

        //now compare the two sets of arrays and return the char that is the same in both sets
        char commonCharacter = firstChunk.Intersect(secondChunk).First();

        //select the number in the priority reference where the recorded character equals the character in the reference and add it to the sum
        var selectedPriority = priorities.Where(p => p.Value.Equals(commonCharacter)).First().Key;
        sumOfPrioritizedLetters = sumOfPrioritizedLetters + selectedPriority;
    }
    else
    {
        Console.WriteLine($"{line} is not even. Cannot perform action.");
    }

}

//now return the sum
Console.WriteLine(sumOfPrioritizedLetters);

Console.WriteLine("Day 3, done and dusted!");
Console.ReadLine();