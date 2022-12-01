using Day1;

//read the file
var filePath = @"ElfFood.txt";
var allFood =  File.ReadAllText(filePath);

/// <summary>
/// for linux generated files
/// </summary>
var blankLine = "\n\n";
var newLine = "\n";

/// <summary>
/// for windows generated files
/// </summary>
//var blankLine = "\r\n\r\n";
//var newLine = "\r\n";

//split the text & sum up the totals
var foodList = allFood.Split(blankLine);
var elvesWithFood = new List<Elf>();

foreach (var elfFood in foodList)
{
    var splitFood = elfFood.Split(newLine);
    try
    {
        var splitFoodCalories = Array.ConvertAll(splitFood, Decimal.Parse);
        var total = splitFoodCalories.Sum();
        elvesWithFood.Add(new Elf { CarriedCaloriesTotal = total });
    }
    catch (Exception ex)
    {
        Console.WriteLine($"{ex.Message}. The start string was: {splitFood.First()}...");
    }
}

//sort by total from high to low
var orderedList = elvesWithFood.OrderByDescending(x => x.CarriedCaloriesTotal).ToList();

//spit out the first value
Console.WriteLine($"total calories carried by the elf with the most food: {orderedList.First().CarriedCaloriesTotal}");

var topThree = orderedList.Take(3).ToList();

Console.WriteLine($"total calories carried by the top 3 elves: {topThree.Select(t => t.CarriedCaloriesTotal).Sum()}");

Console.WriteLine("Day 1, done and dusted!");
Console.ReadLine();