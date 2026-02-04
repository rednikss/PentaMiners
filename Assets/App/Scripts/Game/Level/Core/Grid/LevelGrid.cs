using System.Linq;
using App.Scripts.Game.Block.Base;
using App.Scripts.Game.Block.Types.Default;
using App.Scripts.Game.Level.Core.Grid.Column;
using UnityEngine;

namespace App.Scripts.Game.Level.Core.Grid
{
    public class LevelGrid : ILevelGrid
    {
        private LevelColumn[] _columns;
        
        private Vector2Int _size;
        
        public void Init(Vector2Int size, Vector3 bottomLeftPosition, float scale)
        {
            _size = size;
            _columns = new LevelColumn[_size.x];
            
            var position = bottomLeftPosition + new Vector3(0.5f, 0.5f, 0) * scale;
            
            for (var i = 0; i < _columns.Length; i++)
            {
                _columns[i] = new LevelColumn(_size.y, position, scale);
                position += Vector3.right * scale;
            }
        }

        public Vector2Int GetSize() => _size;

        public Vector3 GetPosition(int i, int j) => _columns[i].GetPosition(j);
        
        public bool HasDropped(BlockBase fallingBlock, int i) => _columns[i].IsBlockDropped(fallingBlock);
        
        public bool IsFull() => _columns.Any(column => column.IsFull());
        
        public bool IsEmpty() => _columns.All(column => !column.OfType<ColorBlock>().Any());

        public void SetBlock(BlockBase block, int i, int j) => _columns[i].Set(block, j);
        
        public void AddBlock(BlockBase block, int i) => _columns[i].Add(block);
    }
}