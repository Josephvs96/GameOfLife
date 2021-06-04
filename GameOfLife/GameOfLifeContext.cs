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
                {"start", new InitializeDefaultAction(_userInterface,_boardService)},
                {"custom", new InitializeCustomAction(_userInterface,_boardService)},
                {"next",new RenderNextGenerationAction(_userInterface,_boardService)},
                {"reset", new ResetAction(_userInterface,_boardService)},
                {"play",new AutoViewNextGenerationAction(_userInterface,_boardService)}
            };

            _userInterface.WriteMessage(WelcomeMessage());

            string inputAction;
            while ((inputAction = FetchAction().ToLower()) != "exit")
            {
                List<string> args = inputAction.Split(" ").ToList();
                IAction action = actions.GetValueOrDefault(args[0].ToLower(), new UnknownAction(_userInterface, _boardService));
                args.RemoveAt(0);
                action.Execute(args);
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
            const string availableActions = "¤ Start : Start a game with the default board settings\n" +
                                            "¤ Custom : Start a game with custom board settings | Format: Custom <width> <height> <cell size>\n" +
                                            "¤ Exit : Exit the game";
            return availableActions;
        }

        private string GameActions()
        {
            const string availableActions = "\n¤ Play : auto plays a number of generations | Format Play <number>\n" +
                                            "¤ Next : Render next generation\n" +
                                            "¤ Reset : Randomize the cells and render the board\n" +
                                            "¤ Exit : Exit the game";
            return availableActions;
        }
    }
}
