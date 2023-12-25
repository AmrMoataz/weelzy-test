using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelzy.Test.ChessMoves
{
	public static class ChessKnight
	{
		public static List<(int, int)> GetPossibleMoves(int currentRow, int currentCol)
		{
			List<(int, int)> possibleMoves = new List<(int, int)>();

			int[,] knightMoves = {
			{ -2, -1 }, { -1, -2 }, { 1, -2 }, { 2, -1 },
			{ 2, 1 }, { 1, 2 }, { -1, 2 }, { -2, 1 }
		};

			for (int i = 0; i < knightMoves.GetLength(0); i++)
			{
				int newRow = currentRow + knightMoves[i, 0];
				int newCol = currentCol + knightMoves[i, 1];

				if (IsValidMove(newRow, newCol))
				{
					possibleMoves.Add((newRow, newCol));
				}
			}

			return possibleMoves;
		}

		private static bool IsValidMove(int row, int col)
		{
			return row >= 0 && row < 8 && col >= 0 && col < 8;
		}
	}
}
