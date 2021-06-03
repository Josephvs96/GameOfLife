using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.UserInterface;

namespace GameOfLife.Actions
{
    public class ResetAction : BaseAction
    {
        public override void Execute()
        {
            _userInterface.ClearInterface();

            if (!_boardService.BoardInitialized)
            {
                _userInterface.WriteMessage("Action not available!\n");
                return;
            }

            _boardService.ResetBoard();
            _userInterface.WriteMessage(_boardService.RenderBoard());
        }

        public ResetAction(IUserInterface userInterface, IBoardService boardService) : base(userInterface, boardService)
        {
        }
    }
}

