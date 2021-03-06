using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.UserInterface;

namespace GameOfLife.Actions
{
    public class RenderNextGenerationAction : BaseAction
    {
        public RenderNextGenerationAction(IUserInterface userInterface, IBoardService boardService) : base(userInterface, boardService)
        {
        }

        public override void Execute(List<string> args)
        {
            _userInterface.ClearInterface();

            if (!_boardService.BoardInitialized)
            {
                _userInterface.WriteMessage("Action not available!\n");
                return;
            }

            _userInterface.WriteMessage(_boardService.RenderBoard());

        }
    }
}
