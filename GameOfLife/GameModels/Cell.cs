using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.GameModels
{
    public enum CellState { Dead, Alive }

    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public CellState IsAlive { get; set; }
        private CellState _isAliveNextGen;

        public List<Cell> NeighborCells { get; set; } = new List<Cell>();

        //Any live cell with fewer than two live neighbours dies, as if by underpopulation.
        //Any live cell with more than three live neighbours dies, as if by overpopulation.
        //Any live cell with two or three live neighbours lives on to the next generation.
        //Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
        public void CheckState()
        {
            var aliveNeighbors = NeighborCells.Count(x => x.IsAlive == CellState.Alive);
            switch (IsAlive)
            {
                case CellState.Alive:
                    _isAliveNextGen = (aliveNeighbors == 2 || aliveNeighbors == 3) ? CellState.Alive : CellState.Dead;
                    break;
                case CellState.Dead:
                    _isAliveNextGen = aliveNeighbors == 3 ? CellState.Alive : CellState.Dead;
                    break;
            }
        }

        public void NextGeneration()
        {
            IsAlive = _isAliveNextGen;
        }
    }
}
