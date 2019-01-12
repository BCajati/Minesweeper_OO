using System;
using System.Collections.Generic;

namespace Minesweeper
{
    public class Board
    {
        private readonly List<Square> squares = new List<Square>();
        private readonly int rows;
        private readonly int cols;

        public Board(int numRows, int numCols)
        {
            rows = numRows;
            cols = numCols;

            bool isBomb = false;
            Random rnd = new Random();
            for(var x=0; x < numRows; x++)
            {
                for (var y = 0; y < numCols; y++)
                {
                    int mIndex = rnd.Next();
                    isBomb = mIndex % 2 == 0;
                    squares.Add(new Square() { xCoordinate = x, yCoordinate = y, IsBomb = isBomb });
                }
            }
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
        }

        //public List<Square> FindAdjacentSquares(int row, int col)
        //{
        //    var adjacentSquares = new List<Square>();

        //    // row above
        //    if (row > 0)
        //    {
        //        adjacentSquares.AddRange(AdjacentRow(row - 1, col));
        //    }
        //    // row below
        //    if (row < rows)
        //    {
        //        adjacentSquares.AddRange(AdjacentRow(row + 1, col));
        //    }

        //    return new List<Square>();
        //}


        public List<Square> FindAdjacentSquares(int row, int col)
        {
            var adjacentSquares = new List<Square>();

            //// range of squares
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

        public void DisplayBombs()
        {
            foreach (Square s in squares)
            {
                Console.Write($"{s.xCoordinate}, {s.yCoordinate}, {s.IsBomb}  ");
            }
            Console.ReadLine();
        }

        public void DisplayBoard()
        {
            for (var x = 0; x < rows; x++)
            {
                for (var y = 0; y < cols; y++)
                {
                    var nextSquare = FindSquare(x, y);
                    Console.Write(nextSquare.ShowSquare());

                }
                Console.WriteLine();
            }
        }
    }
}
