using App.Scripts.Game.Block.Types.Base;
using App.Scripts.Game.Level.Core.Grid;
using App.Scripts.Game.Level.Core.Grid.Data;
using JetBrains.Annotations;
using UnityEngine;

namespace App.Scripts.Game.Level.Core.Block
{
    public class FallingBlock : IFallingBlock
    {
        private readonly ILevelGrid _grid;
        
        private readonly IGridData _gridData;

        private float _speed;

        [CanBeNull] private BlockBase _block;
        
        private int _curColumn;

        public FallingBlock(ILevelGrid grid, IGridData gridData)
        {
            _gridData = gridData;
            _grid = grid;
        }
        
        public void SetBlock(BlockBase fallingBlock, int i, int j)
        {
            _curColumn = i;
            _block = fallingBlock;
            
            var worldPos = _gridData.GetPosition(i, j);
            _block?.SetPosition(worldPos);
        }

        public void Move(Vector3 delta) => _block?.Move(delta);
        
        public void DashToColumn(int newColumn)
        {
            _curColumn = _gridData.ClampDashAbility(_block, _curColumn, newColumn);
            var newX = _gridData.GetPosition(_curColumn, 0).x;
            
            _block?.DashToX(newX);
        }
        
        public bool IsDropped()
        {
            return _block is not null && _gridData.IsDropped(_block, _curColumn);
        }

        public void Drop()
        {
            var height = _gridData.GetDropIndex(_curColumn);
            _grid.SetBlock(_block, _curColumn,  height);
            
            var worldPos = _gridData.GetPosition(_curColumn, height);
            _block?.SetPosition(worldPos);
            
            _block?.OnDrop();
            _block = null;
        }
    }
}