using App.Scripts.Game.Block.Types.Base;
using App.Scripts.Game.Block.Types.Default;
using UnityEngine;

namespace App.Scripts.Game.Level.Core.Grid.Data
{
    public class GridData : IGridData
    {
        private readonly ILevelGrid _grid;

        private Vector3 _blPosition;

        private float _blockScale;

        public GridData(ILevelGrid grid)
        {
            _grid = grid;
        }
        
        public void Init(Vector3 blPosition, float blockScale)
        {
            _blPosition = blPosition;
            _blockScale = blockScale;
        }

        public Vector2Int GetSize()
        {
            return _grid.GetSize();
        }

        public Vector3 GetPosition(int i, int j)
        {
            return _blPosition + new Vector3(0.5f + i,  0.5f + j, 0) * _blockScale;
        }

        public int GetDropIndex(int i)
        {
            var j = GetSize().y;
            while (j > 0 && _grid.GetBlock(i, j - 1) is null) j--;

            return j;
        }

        public bool IsDropped(BlockBase block, int i)
        {
            var worldPos = GetPosition(i, GetDropIndex(i));
            
            return block.GetPosition().y <= worldPos.y;
        }

        public bool IsFull()
        {
            for (int i = 0, j = GetSize().y - 1; i < GetSize().x; i++)
            {
                if (_grid.GetBlock(i, j) is null) return false;
            }

            return true;
        }

        public bool IsEmpty()
        {
            for (var i = 0; i < GetSize().x; i++)
            for (var j = 0; j < GetSize().y; j++)
            {
                if  (_grid.GetBlock(i, j) is ColorBlock) return false;
            }
            
            return true;
        }

        public int ClampDashAbility(BlockBase block, int from, int to)
        {
            if (block is null) return to;
            
            var isRight = from < to;
            var dir = isRight ? 1 : -1;
        
            var end = to - dir;
            for (var i = from; isRight ? i < end : i > end; i += dir)
            {
                if (IsDropped(block, i + dir)) return i;
            }
            
            return to;
        }
    }
}