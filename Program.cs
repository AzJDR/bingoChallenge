using System;

class BingoCard
{
    private const int Rows = 5;
    private const int Columns = 5;
    private const int MiddleRow = Rows / 2;
    private const int MiddleColumn = Columns / 2;
    private const string FreeSpace = "FREE";

    private static readonly object[,] card = new object[Rows, Columns];

    static void Main()
    {
        Console.Clear();
        InitializeCard();
        DisplayCard();

        while (true)
        {
            int patternNumber = GetPatternNumber();
            Console.Clear();

            switch (patternNumber)
            {
                case 1:
                    ExtractRow("Top", 0);
                    break;
                case 2:
                    ExtractRow("Bottom", Rows - 1);
                    break;
                case 3:
                    ExtractRow("Middle", MiddleRow);
                    break;
                case 4:
                    ExtractColumn("Left", 0);
                    break;
                case 5:
                    ExtractColumn("Right", Columns - 1);
                    break;
                case 6:
                    ExtractColumn("Middle", MiddleColumn);
                    break;
                case 7:
                    ExtractDiagonal("Left to Right");
                    break;
                case 8:
                    ExtractDiagonal("Right to Left");
                    break;
                case 9:
                    ExtractSquareRows("Top-Left");
                    break;
                case 10:
                    ExtractSquareRows("Bottom-Right", Rows - 2);
                    break;
                default:
                    Console.WriteLine("Invalid pattern number. Please try again.");
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to enter a new pattern number...");
            Console.ReadKey();
            Console.Clear();
            DisplayCard();
            Console.WriteLine();
        }
    }

    static void InitializeCard()
    {
        Random random = new Random();

        for (int column = 0; column < Columns; column++)
        {
            int minValue = 1;
            int maxValue = 15;

            for (int row = 0; row < Rows; row++)
            {
                if (row == MiddleRow && column == MiddleColumn)
                {
                    card[row, column] = FreeSpace;
                }
                else
                {
                    card[row, column] = random.Next(minValue, maxValue + 1);
                }
            }
        }
    }

    static void DisplayCard()
    {
        Console.WriteLine("BINGO Sosyal App\n");
        Console.WriteLine("B\tI\tN\tG\tO");

        for (int row = 0; row < Rows; row++)
        {
            for (int column = 0; column < Columns; column++)
            {
                Console.Write($"{card[row, column]}\t");
            }
            Console.WriteLine();
        }
    }

    static int GetPatternNumber()
    {
        int patternNumber;

        while (true)
        {
            Console.WriteLine("Enter pattern number (1-10):");
            if (int.TryParse(Console.ReadLine(), out patternNumber) && patternNumber >= 1 && patternNumber <= 10)
                break;

            Console.WriteLine("Invalid pattern number. Please try again.");
        }

        return patternNumber;
    }

    static void ExtractRow(string name, int row)
    {
        Console.WriteLine($"Pattern #{name} Row");

        for (int column = 0; column < Columns; column++)
        {
            Console.Write($"{card[row, column]}\t");
        }

        Console.WriteLine("\n");
    }

    static void ExtractColumn(string name, int column)
    {
        Console.WriteLine($"Pattern #{name} Column");

        for (int row = 0; row < Rows; row++)
        {
            Console.WriteLine(card[row, column]);
        }

        Console.WriteLine();
    }

    static void ExtractDiagonal(string name)
    {
        Console.WriteLine($"Pattern #{name} Diagonal");

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                if ((name == "Left to Right" && j == i) || (name == "Right to Left" && j == Rows - 1 - i))
                    Console.Write($"{card[i, j]}\t");
                else
                    Console.Write("\t");
            }
            Console.WriteLine();
        }

        Console.WriteLine();
    }

    static void ExtractSquareRows(string name, int startRow = 0)
    {
        Console.WriteLine($"Pattern #{name} Rows");

        for (int row = startRow; row < Rows; row++)
        {
            for (int column = Columns - 2; column < Columns; column++)
            {
                Console.Write($"{card[row, column]}\t");
            }
            Console.WriteLine();
        }

        Console.WriteLine();
    }
}
