//read the file
using Day2;

var blankSpace = " ";

/// <summary>
/// for linux generated files
/// </summary>
var newLine = "\n";

/// <summary>
/// for windows generated files
/// </summary>
//var newLine = "\r\n";

var filePath = @"StrategyGuide.txt";
var strategyGuide = File.ReadAllText(filePath);
var game = new List<GameRound>();
var rounds = strategyGuide.Split(newLine);

//score table
const int rock = 1;
const int paper = 2;
const int scissors = 3;
const int win = 6;
const int loss = 0;
const int draw = 3;

//add properties to objects
foreach(var round in rounds)
{
    //split each line so that we can get the opponent and individual hand
    char[] charsToTrim = { '\r'};
    var roundTrimmed = round.Trim(charsToTrim);
    var hands = Array.ConvertAll(roundTrimmed.Split(blankSpace), Char.Parse);
    //int opponentScore = default;
    int myScore = default;

    myScore = hands[1] == 'X' ? loss : hands[1] == 'Y' ? draw : win;

    //calculate individual scores of opponent
    switch (hands[0])
    {
        case 'A':
            //opponentScore = rock;
            //myScore = hands[1] == 'X' ? rock + draw : hands[1] == 'Y' ? paper + win : scissors + loss;
            myScore = myScore == loss ? myScore + scissors : myScore == draw ? myScore + rock : myScore + paper;
            break;
        case 'B':
            //opponentScore = paper;
            //myScore = hands[1] == 'X' ? rock + loss : hands[1] == 'Y' ? paper + draw : scissors + win;
            myScore = myScore == loss ? myScore + rock : myScore == draw ? myScore + paper : myScore + scissors;
            break;
        case 'C':
            //opponentScore = scissors;
            //myScore = hands[1] == 'X' ? rock + win : hands[1] == 'Y' ? paper + loss : scissors + draw;
            myScore = myScore == loss ? myScore + paper : myScore == draw ? myScore + scissors : myScore + rock;
            break;
        default:
            // code block
            break;
    }

    game.Add(new GameRound { MyScore = myScore});
}

//add up all individual scores, sum of a list
var totalScore = game.Select(gameRound => gameRound.MyScore).Sum();

//spit out the total score
Console.WriteLine($"My total score is: {totalScore}");

Console.WriteLine("Day 2, done and dusted!");
Console.ReadLine();
