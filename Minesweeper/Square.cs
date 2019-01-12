using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    public class Square
    {
        private string Hidden = "X";
        private string Bomb = "*";

        public int xCoordinate { get; set; }
        public int yCoordinate { get; set; }
        public bool IsBomb { get; set; }
        private bool IsVisible;
        public int NumBombNeighbors { get; set; }

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
            if (!IsVisible)
                return Hidden;

            if (IsBomb)
                return Bomb;

            return NumBombNeighbors.ToString();

        }
   
    }
}
