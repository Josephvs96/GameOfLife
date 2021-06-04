using System.Collections.Generic;

namespace GameOfLife.Actions
{
    public interface IAction
    {
        void Execute(List<string> args);
    }
}
