using System.ComponentModel;
using System.Numerics;
using Raylib_cs;
class SudokuBoard
{
    public int BoardOffsetX { get; private set; }
    public int BoardOffsetY { get; private set; }
    public int CellSize { get; private set; }
    private int[,] _sudokuBoard;

    public SudokuBoard (int windowWidth, int windowHeight, int cellSize)
    {
        CellSize = cellSize;
        BoardOffsetX = (windowWidth - (9 * cellSize)) / 2;
        BoardOffsetY = (windowHeight - (9 * cellSize)) / 2;
        _sudokuBoard = new int[9, 9];

        //Init th board with some random value
        _sudokuBoard[0, 0] = 5;
        _sudokuBoard[1, 1] = 3;
        _sudokuBoard[4, 4] = 7;
    }

    public void DrawGrid()
    {
        for (int i = 0; i <= 9; i++)
        {
            int thickness = (i % 3 == 0) ? 4 : 1;
            Raylib.DrawLine(BoardOffsetX + i * CellSize, BoardOffsetY, BoardOffsetX + i * CellSize, BoardOffsetY + 9 * CellSize, Color.Black);
            Raylib.DrawLine(BoardOffsetX, BoardOffsetY + i * CellSize, BoardOffsetX + 9 * CellSize, BoardOffsetY + i * CellSize, Color.Black);
        }
    }

    public void DrawBoard()
    {
        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                int number = _sudokuBoard[row,col];
                if(number != 0)
                {
                    string text = number.ToString();
                    Vector2 position = new Vector2(BoardOffsetX + col * CellSize + CellSize / 2 - 10, BoardOffsetY + row * CellSize + CellSize / 2 - 10);
                    Raylib.DrawText(text, (int)position.X, (int)position.Y, 40, Color.Black);
                }
            }
        }
    }

    public void HighlightCell(int row, int col)
    {
        if (row >= 0 && row < 9 && col >= 0 && col < 9)
        {
            Raylib.DrawRectangleLines(BoardOffsetX + col * CellSize, BoardOffsetY + row * CellSize, CellSize, CellSize, Color.Red);
        }
    }

    public void InsertNumber(int row, int col, int number)
    {
        if (row >= 0 && row < 9 && col >= 0 && col < 9)
        {
            _sudokuBoard[row, col] = number;
        }
    }
    public void HandleInput(int selectedRow, int selectedCol)
    {
        for (int i = 0; i <= 9; i++)
        {
            if (Raylib.IsKeyPressed(KeyboardKey.Zero + i))
            {
                InsertNumber(selectedRow, selectedCol, i);
            }
        }
    }
}