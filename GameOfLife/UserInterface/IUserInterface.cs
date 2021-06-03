namespace GameOfLife.UserInterface
{
    public interface IUserInterface
    {
        string GetInput(string message);
        void WriteMessage(string message);
        void ClearInterface();
    }
}