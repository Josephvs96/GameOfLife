using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Actions;
using GameOfLife.UserInterface;

namespace GameOfLife
{
    public class GameOfLifeContext
    {
        private readonly IBoardService _boardService;
        private readonly IUserInterface _userInterface;

        public GameOfLifeContext(IUserInterface userInterface, IBoardService boardService)
        {
            _userInterface = userInterface;
            _boardService = boardService;
        }

        public void Run()
        {
            Dictionary<string, IAction> actions = new Dictionary<string, IAction>()
            {
                {"s", new InitializeDefaultAction(_userInterface,_boardService)},
                {"c", new InitializeCustomAction(_userInterface,_boardService)},
                {"n",new RenderNextGenerationAction(_userInterface,_boardService)},
                {"r", new ResetAction(_userInterface,_boardService)},
            };

            _userInterface.WriteMessage(WelcomeMessage());

            string inputAction;
            while ((inputAction = FetchAction().ToLower()) != "e")
            {
                IAction action = actions.GetValueOrDefault(inputAction, new UnknownAction(_userInterface, _boardService));
                action.Execute();
            }
        }

        private string WelcomeMessage()
        {
            const string message = "Welcome to the game of life :) \n\nList of the available actions:\n";
            return message;
        }

        private string FetchAction()
        {
            StringBuilder availableActions = new StringBuilder();
            availableActions.AppendLine(_boardService.BoardInitialized ? GameActions() : MainMenuActions());
            availableActions.AppendLine("\nPlease enter an action");
            return _userInterface.GetInput(availableActions.ToString());
        }

        private string MainMenuActions()
        {
            const string availableActions = "¤ S : Start a game with the default board settings (100X100 and a cell size of 10)\n" +
                                            "¤ C : Start a game with custom board settings\n" +
                                            "¤ E : Exit the game";
            return availableActions;
        }

        private string GameActions()
        {
            const string availableActions = "\n¤ N : Render next generation\n" +
                                            "¤ R : Randomize the cells and render the board\n" +
                                            "¤ E : Exit the game";
            return availableActions;
        }
    }
}
