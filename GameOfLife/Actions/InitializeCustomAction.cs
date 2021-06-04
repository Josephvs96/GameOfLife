using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.UserInterface;

namespace GameOfLife.Actions
{
    public class InitializeCustomAction : BaseAction
    {
        public InitializeCustomAction(IUserInterface userInterface, IBoardService boardService) : base(userInterface, boardService)
        {
        }

        public override void Execute(List<string> args)
        {
            _userInterface.ClearInterface();

            if (_boardService.BoardInitialized)
            {
                _userInterface.WriteMessage("Action not available!\n");
                return;
            }

            //TODO: Add validation for the input
            if (args?.Count != 3)
            {
                _userInterface.WriteMessage("Invalid input arguments, please check the parameters and try again\n" +
                                            "Format: Custom <width> <height> <cell size>");
                return;
            }
            int width, height, cellSize;
            width = int.Parse(args[0]);
            height = int.Parse(args[1]);
            cellSize = int.Parse(args[2]);

            _userInterface.ClearInterface();
            _boardService.CreateBoard(width, height, cellSize);
            _boardService.ResetBoard();
            _userInterface.WriteMessage(_boardService.RenderBoard());
        }

    }
}
