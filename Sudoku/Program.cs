using System.Numerics;
using Raylib_cs;

namespace Sudoku
{
    /*
     * Create a a class for the gameboard.
     * Create a class for the game logic: User input, constrains, winning conditions.
     * Create a class for different automatic solving alghorithms.
     * Create the GUI : menu , game board, user interactions.
     */

    class Program
    {
        static void Main(string[] args)
        {
            //Init Window        
            const int screenWidth = 1280;
            const int screenHeight = 720;
            const int cellSize = 80;

            Raylib.InitWindow(screenWidth, screenHeight, "Sudoku");
            Raylib.SetTargetFPS(60);

            SudokuBoard board = new SudokuBoard(screenWidth, screenHeight, cellSize);
            //main loop
            while (!Raylib.WindowShouldClose())
            {
            // Update
                Vector2 mousePosition = Raylib.GetMousePosition();
                int selectedRow = (int)(mousePosition.Y - board.BoardOffsetY) / board.CellSize;
                int selectedCol = (int)(mousePosition.X - board.BoardOffsetX) / board.CellSize;

                board.HandleInput(selectedRow, selectedCol);
            // Draw
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.RayWhite);

                board.DrawGrid();
                board.DrawBoard();
                board.HighlightCell(selectedRow, selectedCol);

            Raylib.EndDrawing();
        }
            Raylib.CloseWindow();
        }
    }
}