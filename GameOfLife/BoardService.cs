using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.GameModels;

namespace GameOfLife
{
    public class BoardService : IBoardService
    {
        private Board _board;
        public bool BoardInitialized => _board != null;

        public void CreateBoard(int width, int height, int cellSize)
        {
            _board = new Board(width, height, cellSize);
        }

        public string RenderBoard()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int x = 0; x < _board.Col; x++)
            {
                for (int y = 0; y < _board.Row; y++)
                {
                    stringBuilder.Append(_board.Grid[x, y].IsAlive == CellState.Alive ? " ¤ " : "   ");
                }

                stringBuilder.AppendLine();
            }
            _board.GenerateNextGeneration();
            return stringBuilder.ToString();
        }

        public void ResetBoard()
        {
            _board.RandomizeCells();
        }
    }
}
