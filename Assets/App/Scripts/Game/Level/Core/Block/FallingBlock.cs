using App.Scripts.Game.Block.Types.Base;
using App.Scripts.Game.Level.Core.Block.Drop;
using App.Scripts.Game.Level.Core.Grid;
using App.Scripts.Game.Level.Core.Grid.Data;
using JetBrains.Annotations;

namespace App.Scripts.Game.Level.Core.Block
{
    public class FallingBlock : IFallingBlock
    {
        private readonly ILevelGrid _grid;
        
        private readonly IGridDropData _dropData;
        
        private readonly IGridInfo _gridInfo;

        [CanBeNull] private BlockBase _block;
        
        private int _curColumn;

        public FallingBlock(ILevelGrid grid, IGridDropData dropData, IGridInfo gridInfo)
        {
            _dropData = dropData;
            _gridInfo = gridInfo;
            _grid = grid;
        }
        
        public void SetBlock(BlockBase fallingBlock, int i)
        {
            _curColumn = i;
            _block = fallingBlock;
        }
        
        public BlockBase GetBlock() => _block;
        
        public void DashToColumn(int newColumn)
        {
            _curColumn = _dropData.ClampDashAbility(_block, _curColumn, newColumn);
            var newX = _gridInfo.IndexToWorldPos(_curColumn, 0).x;
            
            _block?.DashToX(newX);
        }
        
        public bool IsDropped()
        {
            if (_block is null) return false;
            
            var height = _dropData.GetDropIndex(_curColumn);
            var worldPos = _gridInfo.IndexToWorldPos(_curColumn, height);
            
            return _block.GetPosition().y < worldPos.y;
        }

        public void Drop()
        {
            var block = _block;
            _block = null;
            
            var height = _dropData.GetDropIndex(_curColumn);
            var worldPos = _gridInfo.IndexToWorldPos(_curColumn, height);
            
            block?.SetPosition(worldPos);
            
            if (height < _gridInfo.GetSize().y) _grid.SetBlock(block, _curColumn,  height);
            
            block?.OnDrop();
        }
    }
}