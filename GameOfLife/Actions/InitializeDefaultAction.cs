﻿using System;
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
        public override void Execute()
        {
            _userInterface.ClearInterface();
            _boardService.CreateBoard(100, 100, 10);
            _boardService.RenderBoard();
        }
    }
}