using App.Scripts.Game.Block.Types.Base;
using App.Scripts.Game.Level.Core.Grid;
using App.Scripts.Game.Level.Core.Grid.Data;

namespace App.Scripts.Game.Level.Core.Block.Drop
{
    public class GridDropData : IGridDropData
    {
        private readonly ILevelGrid _grid;
        
        private readonly IGridInfo _gridInfo;
        
        public GridDropData(ILevelGrid levelGrid, IGridInfo gridInfo)
        {
            _gridInfo = gridInfo;
            _grid = levelGrid;
        }
        
        public int GetDropIndex(int i)
        {
            var j = _gridInfo.GetSize().y - 1;
            while (j >= 0 && _grid.GetBlock(i, j) is null) j--;

            return j + 1;
        }

        private bool IsDropped(BlockBase block, int i)
        {
            var worldPos = _gridInfo.IndexToWorldPos(i, GetDropIndex(i));
            
            return block.GetPosition().y <= worldPos.y;
        }

        public int ClampDashAbility(BlockBase block, int from, int to)
        {
            if (block is null) return to;
            
            var dir = from < to ? 1 : -1;
            for (var i = from; i != to; i += dir)
            {
                if (IsDropped(block, i + dir)) return i;
            }
            
            return to;
        }
    }
}