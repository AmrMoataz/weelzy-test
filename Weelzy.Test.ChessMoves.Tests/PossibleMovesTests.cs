using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelzy.Test.ChessMoves.Tests
{
	public class PossibleMovesTests
	{
		[Fact]
		public void TestGetPossibleMoves()
		{
			// Test case 1: Knight at the center of the board
			Assert.Equal(new List<(int, int)> { (1, 2), (2, 1), (0, 2), (2, 3), (3, 2), (1, 0), (0, 0), (3, 1) },
							ChessKnight.GetPossibleMoves(2, 2));

			// Test case 2: Knight at the corner of the board
			Assert.Equal(new List<(int, int)> { (1, 2), (2, 1) },
							ChessKnight.GetPossibleMoves(0, 0));

			// Test case 3: Knight near the edge of the board
			Assert.Equal(new List<(int, int)> { (1, 0), (2, 1), (3, 0), (3, 2) },
							ChessKnight.GetPossibleMoves(2, 0));

			// Test case 4: Invalid position (outside of the board)
			Assert.Equal(new List<(int, int)> { },
							ChessKnight.GetPossibleMoves(8, 8));
		}
	}
}
