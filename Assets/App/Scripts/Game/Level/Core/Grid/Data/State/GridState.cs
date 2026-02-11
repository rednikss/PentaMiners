using App.Scripts.Game.Block.Types.Default;

namespace App.Scripts.Game.Level.Core.Grid.Data.State
{
    public class GridState : IGridState
    {
        private readonly ILevelGrid _grid;

        public GridState(ILevelGrid grid)
        {
            _grid = grid;
        }

        public bool IsFull()
        {
            var size = _grid.GetSize();
            for (int i = 0, j = size.y - 1; i < size.x; i++)
            {
                if (_grid.GetBlock(i, j) is null) return false;
            }

            return true;
        }

        public bool IsEmpty()
        {
            var size = _grid.GetSize();
            for (var i = 0; i < size.x; i++)
            for (var j = 0; j < size.y; j++)
            {
                if  (_grid.GetBlock(i, j) is ColorBlock) return false;
            }
            
            return true;
        }
    }
}