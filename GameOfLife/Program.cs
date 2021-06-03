using GameOfLife.UserInterface;

namespace GameOfLife
{
    public class Program
    {
        private static void Main()
        {
            //Any live cell with fewer than two live neighbours dies, as if by underpopulation.
            //Any live cell with more than three live neighbours dies, as if by overpopulation.
            //Any live cell with two or three live neighbours lives on to the next generation.
            //Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.

            GameOfLifeContext context = new GameOfLifeContext(new ConsoleUserInterface(), new BoardService());
            context.Run();
        }
    }
}