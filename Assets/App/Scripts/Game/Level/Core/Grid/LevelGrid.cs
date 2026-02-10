using App.Scripts.Game.Block.Types.Base;
using UnityEngine;

namespace App.Scripts.Game.Level.Core.Grid
{
    public class LevelGrid : ILevelGrid
    {
        private BlockBase[,] _blocks;
        
        private Vector2Int _size;
        
        public void Init(Vector2Int size)
        {
            _size = size;
            _blocks = new BlockBase[_size.x, _size.y];
        }

        public Vector2Int GetSize() => _size;

        public void SetBlock(BlockBase block, int i, int j) => _blocks[i, j] = block;

        public BlockBase GetBlock(int i, int j) => _blocks[i, j];
        
        public void RemoveBlock(int i, int j)
        {
            _blocks[i, j].Return();
            _blocks[i, j] = null;
        }
    }
}