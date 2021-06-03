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
            _boardService.ResetBoard();
            _boardService.RenderBoard();
        }

        public ResetAction(IUserInterface userInterface, IBoardService boardService) : base(userInterface, boardService)
        {
        }
    }
}
