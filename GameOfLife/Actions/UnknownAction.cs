using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.UserInterface;

namespace GameOfLife.Actions
{
    public class UnknownAction : BaseAction
    {
        public override void Execute()
        {
            _userInterface.ClearInterface();
            _userInterface.WriteMessage("Cannot find the requested action! please enter a valid action and try again.\n");
        }

        public UnknownAction(IUserInterface userInterface, IBoardService boardService) : base(userInterface, boardService)
        {
        }
    }

}
