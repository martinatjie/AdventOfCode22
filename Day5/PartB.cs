using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class PartB
    {
        public List<char> crate1 { get; set; } = new List<char>();
        public List<char> crate2 { get; set; } = new List<char>();
        public List<char> crate3 { get; set; } = new List<char>();
        public List<char> crate4 { get; set; } = new List<char>();
        public List<char> crate5 { get; set; } = new List<char>();
        public List<char> crate6 { get; set; } = new List<char>();
        public List<char> crate7 { get; set; } = new List<char>();
        public List<char> crate8 { get; set; } = new List<char>();
        public List<char> crate9 { get; set; } = new List<char>();

        public string GetTopCrates()
        {

            //Sample

            /*crate1.Add('Z');
            crate1.Add('N');

            crate2.Add('M');
            crate2.Add('C');
            crate2.Add('D');

            crate3.Add('P');*/

            //end of sample

            crate1.Add('D');
            crate1.Add('B');
            crate1.Add('J');
            crate1.Add('V');

            crate2.Add('P');
            crate2.Add('V');
            crate2.Add('B');
            crate2.Add('W');
            crate2.Add('R');
            crate2.Add('D');
            crate2.Add('F');

            crate3.Add('R');
            crate3.Add('G');
            crate3.Add('F');
            crate3.Add('L');
            crate3.Add('D');
            crate3.Add('C');
            crate3.Add('W');
            crate3.Add('Q');

            crate4.Add('W');
            crate4.Add('J');
            crate4.Add('P');
            crate4.Add('M');
            crate4.Add('L');
            crate4.Add('N');
            crate4.Add('D');
            crate4.Add('B');

            crate5.Add('H');
            crate5.Add('N');
            crate5.Add('B');
            crate5.Add('P');
            crate5.Add('C');
            crate5.Add('S');
            crate5.Add('Q');

            crate6.Add('R');
            crate6.Add('D');
            crate6.Add('B');
            crate6.Add('S');
            crate6.Add('N');
            crate6.Add('G');

            crate7.Add('Z');
            crate7.Add('B');
            crate7.Add('P');
            crate7.Add('M');
            crate7.Add('Q');
            crate7.Add('F');
            crate7.Add('S');
            crate7.Add('H');

            crate8.Add('W');
            crate8.Add('L');
            crate8.Add('F');

            crate9.Add('S');
            crate9.Add('V');
            crate9.Add('F');
            crate9.Add('M');
            crate9.Add('R');

            var instructions = File.ReadLines(@"MoveInstructions.txt");
            var itemsToCopy = new List<char>();

            foreach (var line in instructions)
            {
                var moveHowMany = 0;
                var origin = 0;
                var destination = 0;

                var lineInstructions = line.Replace("move ", "");
                lineInstructions = lineInstructions.Replace(" from ", ",");
                lineInstructions = lineInstructions.Replace(" to ", ",");

                var lineArray = lineInstructions.Split(",");

                moveHowMany = int.Parse(lineArray[0]);
                origin = int.Parse(lineArray[1]);
                destination = int.Parse(lineArray[2]);

                crate1.Reverse();
                crate2.Reverse();
                crate3.Reverse();
                crate4.Reverse();
                crate5.Reverse();
                crate6.Reverse();
                crate7.Reverse();
                crate8.Reverse();
                crate9.Reverse();

                var crate1ChunkToMove = new List<char>();
                var crate2ChunkToMove = new List<char>();
                var crate3ChunkToMove = new List<char>();
                var crate4ChunkToMove = new List<char>();
                var crate5ChunkToMove = new List<char>();
                var crate6ChunkToMove = new List<char>();
                var crate7ChunkToMove = new List<char>();
                var crate8ChunkToMove = new List<char>();
                var crate9ChunkToMove = new List<char>();

                foreach (var member in crate1)
                {
                    crate1ChunkToMove.Add(member);
                }

                foreach (var member in crate2)
                {
                    crate2ChunkToMove.Add(member);
                }

                foreach (var member in crate3)
                {
                    crate3ChunkToMove.Add(member);
                }

                foreach (var member in crate4)
                {
                    crate4ChunkToMove.Add(member);
                }

                foreach (var member in crate5)
                {
                    crate5ChunkToMove.Add(member);
                }

                foreach (var member in crate6)
                {
                    crate6ChunkToMove.Add(member);
                }

                foreach (var member in crate7)
                {
                    crate7ChunkToMove.Add(member);
                }

                foreach (var member in crate8)
                {
                    crate8ChunkToMove.Add(member);
                }

                foreach (var member in crate9)
                {
                    crate9ChunkToMove.Add(member);
                }

                var crateCount = 0;

                switch (origin)
                {
                    case 1:
                        crateCount = crate1.Count();
                        crate1.RemoveRange(0, moveHowMany);
                        crate1ChunkToMove.RemoveRange(moveHowMany, crateCount - moveHowMany);
                        itemsToCopy = crate1ChunkToMove;
                        break;
                    case 2:
                        crateCount = crate2.Count();
                        crate2.RemoveRange(0, moveHowMany);
                        crate2ChunkToMove.RemoveRange(moveHowMany, crateCount - moveHowMany);
                        itemsToCopy = crate2ChunkToMove;
                        break;
                    case 3:
                        crateCount = crate3.Count();
                        crate3.RemoveRange(0, moveHowMany);
                        crate3ChunkToMove.RemoveRange(moveHowMany, crateCount - moveHowMany);
                        itemsToCopy = crate3ChunkToMove;
                        break;
                    case 4:
                        crateCount = crate4.Count();
                        crate4.RemoveRange(0, moveHowMany);
                        crate4ChunkToMove.RemoveRange(moveHowMany, crateCount - moveHowMany);
                        itemsToCopy = crate4ChunkToMove;
                        break;
                    case 5:
                        crateCount = crate5.Count();
                        crate5.RemoveRange(0, moveHowMany);
                        crate5ChunkToMove.RemoveRange(moveHowMany, crateCount - moveHowMany);
                        itemsToCopy = crate5ChunkToMove;
                        break;
                    case 6:
                        crateCount = crate6.Count();
                        crate6.RemoveRange(0, moveHowMany);
                        crate6ChunkToMove.RemoveRange(moveHowMany, crateCount - moveHowMany);
                        itemsToCopy = crate6ChunkToMove;
                        break;
                    case 7:
                        crateCount = crate7.Count();
                        crate7.RemoveRange(0, moveHowMany);
                        crate7ChunkToMove.RemoveRange(moveHowMany, crateCount - moveHowMany);
                        itemsToCopy = crate7ChunkToMove;
                        break;
                    case 8:
                        crateCount = crate8.Count();
                        crate8.RemoveRange(0, moveHowMany);
                        crate8ChunkToMove.RemoveRange(moveHowMany, crateCount - moveHowMany);
                        itemsToCopy = crate8ChunkToMove;
                        break;
                    case 9:
                        crateCount = crate9.Count();
                        crate9.RemoveRange(0, moveHowMany);
                        crate9ChunkToMove.RemoveRange(moveHowMany, crateCount - moveHowMany);
                        itemsToCopy = crate9ChunkToMove;
                        break;
                    default:
                        // code block
                        break;
                }


                switch (destination)
                {
                    case 1:
                        itemsToCopy.Reverse();
                        crate1.Reverse();
                        crate1.AddRange(itemsToCopy);
                        break;
                    case 2:
                        itemsToCopy.Reverse();
                        crate2.Reverse();
                        crate2.AddRange(itemsToCopy);
                        break;
                    case 3:
                        itemsToCopy.Reverse();
                        crate3.Reverse();
                        crate3.AddRange(itemsToCopy);
                        break;
                    case 4:
                        itemsToCopy.Reverse();
                        crate4.Reverse();
                        crate4.AddRange(itemsToCopy);
                        break;
                    case 5:
                        itemsToCopy.Reverse();
                        crate5.Reverse();
                        crate5.AddRange(itemsToCopy);
                        break;
                    case 6:
                        itemsToCopy.Reverse();
                        crate6.Reverse();
                        crate6.AddRange(itemsToCopy);
                        break;
                    case 7:
                        itemsToCopy.Reverse();
                        crate7.Reverse();
                        crate7.AddRange(itemsToCopy);
                        break;
                    case 8:
                        itemsToCopy.Reverse();
                        crate8.Reverse();
                        crate8.AddRange(itemsToCopy);
                        break;
                    case 9:
                        itemsToCopy.Reverse();
                        crate9.Reverse();
                        crate9.AddRange(itemsToCopy);
                        break;
                    default:
                        // code block
                        break;
                }
                
            }

            return $"{crate1.Last()}{crate2.Last()}{crate3.Last()}{crate4.Last()}{crate5.Last()}{crate6.Last()}{crate7.Last()}{crate8.Last()}{crate9.Last()}";
            //return $"{crate1.Last()}{crate2.Last()}{crate3.Last()}";

        }

        //Console.WriteLine($"Final top crates: {crate1.Pop()}{crate2.Pop()}{crate3.Pop()}{crate4.Pop()}{crate5.Pop()}{crate6.Pop()}{crate7.Pop()}{crate8.Pop()}{crate9.Pop()}");
        //Console.WriteLine($"Final top crates: {crate1.Pop()}{crate2.Pop()}{crate3.Pop()}");

    }
}
