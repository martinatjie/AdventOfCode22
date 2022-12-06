
//read the file, 4 characters at a time
var characters = File.ReadAllText(@"Characters.txt");

var take = 14;
var skip = 0;
var distinct = false;
var characterPosition = 0;

while (!distinct)
{
    var chosenCharacters = characters.Skip(skip).Take(take);
    var distinctCount = chosenCharacters.Distinct().Count();

    if (distinctCount != take)
    {
        //not all are distinct, move on and take next characters
        skip = skip + 1;
    }
    else
    {
        //all characters are distinct
        characterPosition = skip + take;

        distinct = true;
    }
}

Console.WriteLine(characterPosition);

Console.ReadLine();
