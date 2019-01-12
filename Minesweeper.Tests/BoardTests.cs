using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Minesweeper.Tests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void BoardExists()
        {
            var board = new Board(5,5);
            Assert.IsNotNull(board);
        }

        [TestMethod]
        public void BoardSizeMatchesContructor()
        {
            var board = new Board(5,5);
            Assert.AreEqual(board.GetSquares().Count, 25);
        }

        [TestMethod]
        public void FindAdjacentSquares_0_0()
        {
            var board = new Board(5, 5);
            var adjacent = board.FindAdjacentSquares(0,0);
            Assert.AreEqual(3,adjacent.Count);

            var topRight = adjacent.Select(x => x.xCoordinate == 0 && x.yCoordinate == 1).FirstOrDefault();
            Assert.IsNotNull(topRight);

            var row1_0 = adjacent.Select(x => x.xCoordinate == 1 && x.yCoordinate == 0).FirstOrDefault();
            Assert.IsNotNull(row1_0);

            var row1_1 = adjacent.Select(x => x.xCoordinate == 1 && x.yCoordinate == 1).FirstOrDefault();
            Assert.IsNotNull(row1_1);
        }

        [TestMethod]
        public void FindAdjacentSquares_0_5()
        {
            var board = new Board(5, 5);
            var adjacent = board.FindAdjacentSquares(0, 5);
            Assert.AreEqual(3, adjacent.Count);

            var topRight = adjacent.Select(x => x.xCoordinate == 0 && x.yCoordinate == 3).FirstOrDefault();
            Assert.IsNotNull(topRight);

            var row1_3 = adjacent.Select(x => x.xCoordinate == 1 && x.yCoordinate == 3).FirstOrDefault();
            Assert.IsNotNull(row1_3);

            var row1_4 = adjacent.Select(x => x.xCoordinate == 1 && x.yCoordinate == 4).FirstOrDefault();
            Assert.IsNotNull(row1_4);
        }

        [TestMethod]
        public void FindAdjacentSquares_1_3()
        {
            var board = new Board(5, 5);
            var adjacent = board.FindAdjacentSquares(1, 3);
            Assert.AreEqual(8, adjacent.Count);

            var row_0_2 = adjacent.Select(x => x.xCoordinate == 0 && x.yCoordinate == 2).FirstOrDefault();
            Assert.IsNotNull(row_0_2);

            var row0_3 = adjacent.Select(x => x.xCoordinate == 0 && x.yCoordinate == 3).FirstOrDefault();
            Assert.IsNotNull(row0_3);

            var row0_4 = adjacent.Select(x => x.xCoordinate == 0 && x.yCoordinate == 4).FirstOrDefault();
            Assert.IsNotNull(row0_4);

            var row1_2 = adjacent.Select(x => x.xCoordinate == 1 && x.yCoordinate == 2).FirstOrDefault();
            Assert.IsNotNull(row1_2);

            var row1_4 = adjacent.Select(x => x.xCoordinate == 1 && x.yCoordinate == 4).FirstOrDefault();
            Assert.IsNotNull(row1_4);

            var row2_2 = adjacent.Select(x => x.xCoordinate == 2 && x.yCoordinate == 2).FirstOrDefault();
            Assert.IsNotNull(row2_2);

            var row2_3 = adjacent.Select(x => x.xCoordinate == 2 && x.yCoordinate == 3).FirstOrDefault();
            Assert.IsNotNull(row2_3);

            var row2_4 = adjacent.Select(x => x.xCoordinate == 2 && x.yCoordinate == 4).FirstOrDefault();
            Assert.IsNotNull(row2_4);

        }

        [TestMethod]
        public void FindAdjacentSquares_4_4()
        {
            var board = new Board(5, 5);
            var adjacent = board.FindAdjacentSquares(4, 4);
            Assert.AreEqual(3, adjacent.Count);

            var row_3_3 = adjacent.Select(x => x.xCoordinate == 03&& x.yCoordinate == 3).FirstOrDefault();
            Assert.IsNotNull(row_3_3);

            var row3_4 = adjacent.Select(x => x.xCoordinate == 3 && x.yCoordinate == 4).FirstOrDefault();
            Assert.IsNotNull(row3_4);

            var row4_4 = adjacent.Select(x => x.xCoordinate == 4 && x.yCoordinate == 4).FirstOrDefault();
            Assert.IsNotNull(row4_4);

        }

    }
}
