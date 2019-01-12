using System;
using Minesweeper;
using System.Collections.Generic;

namespace RunMineSweeper
{
    class Program
    {
        static int numRows = 5;
        static int numCols = 5;

        static void Main(string[] args)
        {
            Console.WriteLine("Select square by typeing coordinates: ex: 1,3; X to Exit");
            var board = new Board(numRows,numCols);
            board.DisplayBoard();
            var line = Console.ReadLine();

            while (CheckForQuit(line) == false)
            {
                var pickSquare = ReadIndexes(line);
                board.PickSquare(pickSquare[0], pickSquare[1]);

                Console.WriteLine();
                board.DisplayBoard();
                line = Console.ReadLine();
            }
        }

        static bool CheckForQuit(string line)
        {
            if (line.Contains("X") || line.Contains("x"))
                return true;

            if (line.Contains("Q") || line.Contains("q"))
                return true;

            return false;
        }

        static List<int> ReadIndexes(string line)
        {
            try
            {
                var idxs = line.Split(',');

                var x = int.Parse(idxs[0]);
                var y = int.Parse(idxs[1]);
                if (x < numRows && y < numCols)
                {
                    return new List<int> { x, y };
                }
                return new List<int> { 0, 0 };
            }
            catch(Exception e)
            {

            }

            return new List<int> { 0, 0 };
        }
    }
}
