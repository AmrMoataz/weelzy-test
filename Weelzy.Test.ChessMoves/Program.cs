using System;
using Weelzy.Test.ChessMoves;

Console.WriteLine("KNIGHT CHESS MOVES");
Console.Write("Current position will be shown in ");
Console.ForegroundColor = ConsoleColor.Blue;
Console.Write("BLUE");
Console.ResetColor();

Console.WriteLine("");
Console.Write("Possible moves will be shown in ");
Console.ForegroundColor = ConsoleColor.Red;
Console.Write("RED");
Console.ResetColor();
Console.WriteLine("");

Console.WriteLine("--------------------------");

Console.WriteLine("Enter knight current position in x axis (should be from 0 - 7)");
var xAxisCurrentPostionInput = Console.ReadLine();
Console.WriteLine("Enter knight current position in y axis (should be from 0 - 7)");
var yAxisCurrentPostionInput = Console.ReadLine();

var validxAxis = int.TryParse(xAxisCurrentPostionInput, out var xAxisCurrentPosition);
var validyAxis = int.TryParse(yAxisCurrentPostionInput, out var yAxisCurrentPosition);

if (!validxAxis || !validyAxis)
{
	Console.WriteLine("Invalid position input");
}
else
{
	var possibleMoves = ChessKnight.GetPossibleMoves(yAxisCurrentPosition, xAxisCurrentPosition);
	for (int i = 0; i <= 7; i++)
	{
		for (int j = 0; j <= 7; j++)
		{
			if (i == yAxisCurrentPosition && j == xAxisCurrentPosition)
			{
				Console.ForegroundColor = ConsoleColor.Blue;
			}

			if (possibleMoves.Contains((i, j)))
			{
				Console.ForegroundColor = ConsoleColor.Red;
			}

			Console.Write(" * ");
			Console.ResetColor();
		}

		Console.WriteLine("");
	}
}

Console.ReadLine();



