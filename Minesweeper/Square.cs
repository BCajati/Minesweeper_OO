using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    public class Square
    {
        private string Hidden = "X";

        public int xCoordinate { get; set; }
        public int yCoordinate { get; set; }
        public bool IsBomb { get; set; }
        private bool IsVisible;
        private int NumBombNeighbors { get; set; }

        public Square()
        {
            IsVisible = false;
        }

        public void PickSquare()
        {
            IsVisible = true;
        }

        public string ShowSquare()
        {
            return IsVisible ? NumBombNeighbors.ToString() : Hidden;
        }
   
    }
}
