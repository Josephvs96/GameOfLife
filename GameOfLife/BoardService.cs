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

        public void RenderBoard()
        {
            for (int x = 0; x < _board.Col; x++)
            {
                for (int y = 0; y < _board.Row; y++)
                {
                    Console.Write(_board.Grid[x, y].IsAlive == CellState.Alive ? " ¤ " : "   ");
                }
                Console.WriteLine();
            }
            _board.GenerateNextGeneration();
        }

        public void ResetBoard()
        {
            _board.RandomizeCells();
        }
    }
}
