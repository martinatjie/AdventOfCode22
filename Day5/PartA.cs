internal class PartA
{
    public PartA()
    {
    }

    internal string GetTopCrates()
    {

        //---------------------SETUP-------------------------------//

        Stack<char> crate1 = new Stack<char>();
        Stack<char> crate2 = new Stack<char>();
        Stack<char> crate3 = new Stack<char>();
        Stack<char> crate4 = new Stack<char>();
        Stack<char> crate5 = new Stack<char>();
        Stack<char> crate6 = new Stack<char>();
        Stack<char> crate7 = new Stack<char>();
        Stack<char> crate8 = new Stack<char>();
        Stack<char> crate9 = new Stack<char>();


        //Sample

        crate1.Push('Z');
        crate1.Push('N');

        crate2.Push('M');
        crate2.Push('C');
        crate2.Push('D');

        crate3.Push('P');

        //end of sample

        crate1.Push('D');
        crate1.Push('B');
        crate1.Push('J');
        crate1.Push('V');

        crate2.Push('P');
        crate2.Push('V');
        crate2.Push('B');
        crate2.Push('W');
        crate2.Push('R');
        crate2.Push('D');
        crate2.Push('F');

        crate3.Push('R');
        crate3.Push('G');
        crate3.Push('F');
        crate3.Push('L');
        crate3.Push('D');
        crate3.Push('C');
        crate3.Push('W');
        crate3.Push('Q');

        crate4.Push('W');
        crate4.Push('J');
        crate4.Push('P');
        crate4.Push('M');
        crate4.Push('L');
        crate4.Push('N');
        crate4.Push('D');
        crate4.Push('B');

        crate5.Push('H');
        crate5.Push('N');
        crate5.Push('B');
        crate5.Push('P');
        crate5.Push('C');
        crate5.Push('S');
        crate5.Push('Q');

        crate6.Push('R');
        crate6.Push('D');
        crate6.Push('B');
        crate6.Push('S');
        crate6.Push('N');
        crate6.Push('G');

        crate7.Push('Z');
        crate7.Push('B');
        crate7.Push('P');
        crate7.Push('M');
        crate7.Push('Q');
        crate7.Push('F');
        crate7.Push('S');
        crate7.Push('H');

        crate8.Push('W');
        crate8.Push('L');
        crate8.Push('F');

        crate9.Push('S');
        crate9.Push('V');
        crate9.Push('F');
        crate9.Push('M');
        crate9.Push('R');

        //--------------------END OF SETUP--------------------------------//

        char poppedCharacter = '.';
        var instructions = File.ReadLines(@"MoveInstructions.txt");

        foreach (var line in instructions)
        {
            var performActionHowManyTimes = 0;
            var origin = 0;
            var destination = 0;

            var lineInstructions = line.Replace("move ", "");
            lineInstructions = lineInstructions.Replace(" from ", ",");
            lineInstructions = lineInstructions.Replace(" to ", ",");

            var lineArray = lineInstructions.Split(",");

            performActionHowManyTimes = int.Parse(lineArray[0]);
            origin = int.Parse(lineArray[1]);
            destination = int.Parse(lineArray[2]);

            for (var a = 1; a <= performActionHowManyTimes; a++)
            {
                switch (origin)
                {
                    case 1:
                        poppedCharacter = crate1.Pop();
                        break;
                    case 2:
                        poppedCharacter = crate2.Pop();
                        break;
                    case 3:
                        poppedCharacter = crate3.Pop();
                        break;
                    case 4:
                        poppedCharacter = crate4.Pop();
                        break;
                    case 5:
                        poppedCharacter = crate5.Pop();
                        break;
                    case 6:
                        poppedCharacter = crate6.Pop();
                        break;
                    case 7:
                        poppedCharacter = crate7.Pop();
                        break;
                    case 8:
                        poppedCharacter = crate8.Pop();
                        break;
                    case 9:
                        poppedCharacter = crate9.Pop();
                        break;
                    default:
                        // code block
                        break;
                }

                switch (destination)
                {
                    case 1:
                        crate1.Push(poppedCharacter);
                        break;
                    case 2:
                        crate2.Push(poppedCharacter);
                        break;
                    case 3:
                        crate3.Push(poppedCharacter);
                        break;
                    case 4:
                        crate4.Push(poppedCharacter);
                        break;
                    case 5:
                        crate5.Push(poppedCharacter);
                        break;
                    case 6:
                        crate6.Push(poppedCharacter);
                        break;
                    case 7:
                        crate7.Push(poppedCharacter);
                        break;
                    case 8:
                        crate8.Push(poppedCharacter);
                        break;
                    case 9:
                        crate9.Push(poppedCharacter);
                        break;
                    default:
                        // code block
                        break;
                }
            }

        }

        return $"{crate1.Pop()}{crate2.Pop()}{crate3.Pop()}{crate4.Pop()}{crate5.Pop()}{crate6.Pop()}{crate7.Pop()}{crate8.Pop()}{crate9.Pop()}";
        //Console.WriteLine($"Final top crates: {crate1.Pop()}{crate2.Pop()}{crate3.Pop()}");

    }
}