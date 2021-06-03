namespace GameOfLife
{
    public interface IBoardService
    {
        bool BoardInitialized { get; }
        void CreateBoard(int width, int height, int cellSize);
        void RenderBoard();
        void ResetBoard();
    }
}