using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.UserInterface;

namespace GameOfLife.Actions
{
    public class InitializeDefaultAction : BaseAction
    {
        public InitializeDefaultAction(IUserInterface userInterface, IBoardService boardService) : base(userInterface, boardService)
        {
        }
        public override void Execute(List<string> args = null)
        {
            _userInterface.ClearInterface();

            if (_boardService.BoardInitialized)
            {
                _userInterface.WriteMessage("Action not available!\n");
                return;
            }

            _boardService.CreateBoard(100, 100, 10);
            _boardService.CreatePattern();
            _userInterface.WriteMessage(_boardService.RenderBoard());
        }
    }
}
