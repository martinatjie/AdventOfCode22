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
        public string GetTopCrates()
        {
            var crateLines = File.ReadLines(@"AllCrates.txt");

            //all the crates
            var crates = new List<List<string>>();

            foreach (var line in crateLines)
            {
                var splitLine = line.Split(',').ToList();

                crates.Add(splitLine);
            }

            var instructions = File.ReadLines(@"MoveInstructions.txt");

            foreach (var line in instructions)
            {
                var lineInstructions = line.Replace("move ", "");
                lineInstructions = lineInstructions.Replace(" from ", ",");
                lineInstructions = lineInstructions.Replace(" to ", ",");

                var lineArray = lineInstructions.Split(",");

                var numberOfCrates = int.Parse(lineArray[0]);
                var origin = int.Parse(lineArray[1]);
                var destination = int.Parse(lineArray[2]);

                var selectedOriginLine = crates[origin - 1];
                var destinationLine = crates[destination - 1];

                var numberOfCratesInLine = selectedOriginLine.Count();
                var startIndex = numberOfCratesInLine - numberOfCrates;
                var endIndex = numberOfCratesInLine - 1;

                var cratesToAdd = new List<string>();

                for (var s = startIndex; s <= endIndex; s++)
                {
                    cratesToAdd.Add(selectedOriginLine.ElementAt(s));
                }

                selectedOriginLine.RemoveRange(startIndex, numberOfCrates);
                destinationLine.AddRange(cratesToAdd);
            }
            
            //return the final top crates

            var finalTopCrates = "";

            foreach (var line in crates)
            {
                finalTopCrates += line.Last();
            }

            return finalTopCrates;
        }

    }
}
