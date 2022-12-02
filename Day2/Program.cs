//read the file
using Day2;

var blankSpace = " ";

/// <summary>
/// for linux generated files
/// </summary>
//var blankLine = "\n\n";
var newLine = "\n";

/// <summary>
/// for windows generated files
/// </summary>
//var blankLine = "\r\n\r\n";
//var newLine = "\r\n";

var filePath = @"StrategyGuide.txt";
var strategyGuide = File.ReadAllText(filePath);
var game = new List<GameRound>();
var rounds = strategyGuide.Split(newLine);

//score table
var rock = 1;
var paper = 2;
var scissors = 3;

//add properties to objects
foreach(var round in rounds)
{
    //split each line so that we can get the opponent and individual hand
    char[] charsToTrim = { '\r'};
    var roundTrimmed = round.Trim(charsToTrim);
    var hands = Array.ConvertAll(roundTrimmed.Split(blankSpace), Char.Parse);
    int opponentScore = default;
    int myScore = default;

    //calculate individual scores of opponent
    switch (hands[0])
    {
        case 'A':
            opponentScore = rock;
            opponentScore = hands[1] == 'Z' ? opponentScore + 6 : hands[1] == 'X' ? opponentScore + 3 : opponentScore;
            break;
        case 'B':
            opponentScore = paper;
            opponentScore = hands[1] == 'X' ? opponentScore + 6 : hands[1] == 'Y' ? opponentScore + 3 : opponentScore;
            break;
        case 'C':
            opponentScore = scissors;
            opponentScore = hands[1] == 'Y' ? opponentScore + 6 : hands[1] == 'Z' ? opponentScore + 3 : opponentScore;
            break;
        default:
            // code block
            break;
    }

    //calculate my individual scores
    switch (hands[1])
    {
        case 'X':
            myScore = rock;
            myScore = hands[0] == 'C' ? myScore + 6 : hands[0] == 'A' ? myScore + 3 : myScore;
            break;
        case 'Y':
            myScore = paper;
            myScore = hands[0] == 'A' ? myScore + 6 : hands[0] == 'B' ? myScore + 3 : myScore;
            break;
        case 'Z':
            myScore = scissors;
            myScore = hands[0] == 'B' ? myScore + 6 : hands[0] == 'C' ? myScore + 3 : myScore;
            break;
        default:
            // code block
            break;
    }

    //add winning scores
    //0 loss, 3 draw, 6 win
    //var myWinningScore = opponentScore == myScore ? myScore + 3 : opponentScore > myScore ? myScore : myScore + 6;
    //var opponentWinningScore = opponentScore == myScore ? opponentScore + 3 : opponentScore < myScore ? opponentScore : opponentScore + 6;

    //B beats X
    //A beats Z
    //C beats Y
    //Y beats A
    //X beats C
    //Z beats B

    game.Add(new GameRound { OpponentHand = hands[0], MyHand = hands[1], OpponentScore = opponentScore, MyScore = myScore});
}

//add up all individual scores, sum of a list
var totalScore = game.Select(gameRound => gameRound.MyScore).Sum();

//spit out the total score
Console.WriteLine($"My total score is: {totalScore}");

Console.WriteLine("Day 2, done and dusted!");
Console.ReadLine();
