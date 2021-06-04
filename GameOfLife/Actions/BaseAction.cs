using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.UserInterface;

namespace GameOfLife.Actions
{
    public abstract class BaseAction : IAction
    {
        protected IBoardService _boardService;
        protected IUserInterface _userInterface;

        protected BaseAction(IUserInterface userInterface, IBoardService boardService)
        {
            _userInterface = userInterface;
            _boardService = boardService;
        }

        public abstract void Execute(List<string> args);
    }
}
