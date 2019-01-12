using System;
using System.Collections.Generic;

namespace Minesweeper
{
    public class Board
    {
        private readonly List<Square> squares = new List<Square>();
        private readonly int rows;
        private readonly int cols;
        private readonly string YouLost = "Sorry you Lost!";
        private bool GameLost = false;
        private int maxBombs;

        public Board(int numRows, int numCols)
        {
            rows = numRows;
            cols = numCols;
            maxBombs = (rows * cols) / 5;
            var numBombs = 0;

            Random rnd = new Random();
            for(var x=0; x < numRows; x++)
            {
                for (var y = 0; y < numCols; y++)
                {
                    int mIndex = rnd.Next();
                    var isBomb = AddBomb(x, numBombs, mIndex);
                    if (isBomb)
                        ++numBombs;
                    squares.Add(new Square() { xCoordinate = x, yCoordinate = y, IsBomb = isBomb });
                }
            }
        }

        public bool AddBomb( int row, int numBombs,  int randomIndex)
        {
            if (numBombs == maxBombs)
                return false;

            return randomIndex % rows == 0;

        }

        public List<Square> GetSquares()
        {
            return squares;
        }

        public Square FindSquare(int x, int y)
        {
            foreach( Square sq in squares)
            {
                if (sq.xCoordinate.Equals(x) && sq.yCoordinate.Equals(y))
                {
                    return sq;
                }
            }
            return null;
        }

        public void ShowSquares()
        {
           foreach(Square s in squares)
            {
                Console.Write($"{s.xCoordinate}, {s.yCoordinate}, {s.IsBomb}  ");
            }
            Console.ReadLine();
        }

        public void PickSquare(int row, int col)
        {
            var foundSquare = FindSquare(row, col);
            foundSquare.PickSquare();
            if (foundSquare.IsBomb)
                GameLost = true;

            if (!foundSquare.IsBomb)
            {
                // set value
                var adjacent = FindAdjacentSquares(row, col);
                int numNearBombs = 0;
                foreach(var sq in adjacent)
                {
                    if (sq.IsBomb)
                    {
                        ++numNearBombs;
                    }
                }
                foundSquare.NumBombNeighbors = numNearBombs;
            }
        }

        public List<Square> FindAdjacentSquares(int row, int col)
        {
            var adjacentSquares = new List<Square>();

            var fromRow = row > 0 ? row - 1 : row;
            var fromCol = col > 0 ? col - 1 : col;
            var toRow = row < rows-1 ? row + 1 : row;
            var toCol = col < cols-1 ? col + 1 : col;
            for (var x = fromRow; x <= toRow; x++)
            {
                for (var y = fromCol; y <= toCol; y++)
                {
                    // exclude self
                    if (!(x == row && y == col))
                    {
                        adjacentSquares.Add(FindSquare(x, y));
                    }
                }
            }
            return adjacentSquares;
        }

        private List<Square> AdjacentRow(int row, int col)
        {
            var squares = new List<Square>();
            squares.Add(FindSquare(row, col-1));
            squares.Add(FindSquare(row, col));
            squares.Add(FindSquare(row, col + 1));
            return squares;
        }

        public void DisplayBoard()
        {
            if (GameLost)
                Console.WriteLine(YouLost);

            for (var x = 0; x < rows; x++)
            {
                for (var y = 0; y < cols; y++)
                {
                    var nextSquare = FindSquare(x, y);
                    if (GameLost && nextSquare.IsBomb)
                    {
                        nextSquare.PickSquare();
                    }
                    Console.Write(nextSquare.ShowSquare());
                }
                Console.WriteLine();
            }
        }
    }
}
