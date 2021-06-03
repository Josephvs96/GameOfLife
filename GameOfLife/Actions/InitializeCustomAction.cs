using System;
using System.Collections.Generic;
using System.Linq;
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

        public override void Execute()
        {
            _userInterface.ClearInterface();

            if (_boardService.BoardInitialized)
            {
                _userInterface.WriteMessage("Action not available!\n");
                return;
            }

            //TODO: Add validation for the input
            int width, height, cellSize;
            width = int.Parse(_userInterface.GetInput("Enter the width of the board"));
            height = int.Parse(_userInterface.GetInput("Enter the height of the board"));
            cellSize = int.Parse(_userInterface.GetInput("Enter the size of the cells on board"));

            _userInterface.ClearInterface();
            _boardService.CreateBoard(width, height, cellSize);
            _userInterface.WriteMessage(_boardService.RenderBoard());
        }

    }
}
