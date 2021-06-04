using System;

namespace GameOfLife.GameModels
{
    public class Board
    {
        public int Col { get; }
        public int Row { get; }

        private readonly Random _random = new();
        public Cell[,] Grid { get; private set; }

        public Board(int width, int height, int cellSize)
        {
            Col = width / cellSize;
            Row = height / cellSize;
            CreateBoard();
        }

        public void CreateBoard()
        {
            Grid = new Cell[Col, Row];
            for (int x = 0; x < Col; x++)
            {
                for (int y = 0; y < Row; y++)
                {
                    Grid[x, y] = new Cell { X = x, Y = y, IsAlive = CellState.Dead };
                }
            }

            ConnectNeighbors();
        }

        /// <summary>
        /// This method gets if the cell at a specific position x,y is a boarder cell
        /// A border cell would have one position as 0 or the last cell in the array
        /// It then adds the neighbors to the list of each cell
        /// </summary>
        private void ConnectNeighbors()
        {
            for (int x = 0; x < Col; x++)
            {
                for (int y = 0; y < Row; y++)
                {

                    bool isLeftEdge = (x == 0);
                    bool isRightEdge = (x == Col - 1);
                    bool isTopEdge = (y == 0);
                    bool isBottomEdge = (y == Row - 1);

                    int xLeft = isLeftEdge ? Grid.GetLength(0) - 1 : x - 1;
                    int xRight = isRightEdge ? 0 : x + 1;
                    int yTop = isTopEdge ? Grid.GetLength(1) - 1 : y - 1;
                    int yBottom = isBottomEdge ? 0 : y + 1;

                    Grid[x, y].NeighborCells.Add(Grid[xLeft, yTop]);
                    Grid[x, y].NeighborCells.Add(Grid[x, yTop]);
                    Grid[x, y].NeighborCells.Add(Grid[xRight, yTop]);
                    Grid[x, y].NeighborCells.Add(Grid[xLeft, y]);
                    Grid[x, y].NeighborCells.Add(Grid[xRight, y]);
                    Grid[x, y].NeighborCells.Add(Grid[xLeft, yBottom]);
                    Grid[x, y].NeighborCells.Add(Grid[x, yBottom]);
                    Grid[x, y].NeighborCells.Add(Grid[xRight, yBottom]);
                }
            }
        }

        public void RandomizeCells()
        {
            foreach (var cell in Grid)
            {
                cell.IsAlive = (CellState)_random.Next(2);
            }
        }

        public void GenerateNextGeneration()
        {
            foreach (var cell in Grid)
                cell.CheckState();
            foreach (var cell in Grid)
                cell.NextGeneration();
        }
    }
}
