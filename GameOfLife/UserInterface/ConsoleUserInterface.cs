using System;

namespace GameOfLife.UserInterface
{
    public class ConsoleUserInterface : IUserInterface
    {
        public string GetInput(string message)
        {
            Console.Write(message);
            Console.WriteLine("> ");
            return Console.ReadLine();
        }

        public void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void ClearInterface()
        {
            Console.Clear();
        }
    }
}
