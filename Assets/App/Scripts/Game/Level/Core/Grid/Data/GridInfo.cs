using UnityEngine;

namespace App.Scripts.Game.Level.Core.Grid.Data
{
    public class GridInfo : IGridInfo
    {
        private readonly ILevelGrid _grid;

        private Vector3 _blPosition;

        private float _blockScale;

        public GridInfo(ILevelGrid grid)
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

        public Vector3 IndexToWorldPos(int i, int j)
        {
            return _blPosition + new Vector3(0.5f + i,  0.5f + j, 0) * _blockScale;
        }
    }
}