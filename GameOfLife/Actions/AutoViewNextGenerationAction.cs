using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GameOfLife.UserInterface;

namespace GameOfLife.Actions
{
    public class AutoViewNextGenerationAction : BaseAction
    {
        public AutoViewNextGenerationAction(IUserInterface userInterface, IBoardService boardService) : base(userInterface, boardService)
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

            //TODO: Add validation for the input
            if (args?.Count != 1)
            {
                _userInterface.WriteMessage("Invalid input arguments, please check the parameters and try again\n" +
                                            "Format: Play <number of generations>");
                return;
            }

            int numberOfGenerations = int.Parse(args[0]);
            int counter = 0;

            while (counter < numberOfGenerations)
            {
                counter++;
                Thread.Sleep(250);
                _userInterface.ClearInterface();
                _userInterface.WriteMessage(_boardService.RenderBoard());
            }
        }
    }
}
