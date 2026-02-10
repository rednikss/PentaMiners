using App.Scripts.Game.Block.Types.Base;
using UnityEngine;

namespace App.Scripts.Game.Level.Core.Grid
{
    public interface ILevelGrid
    {
        public void Init(Vector2Int size);
        
        public Vector2Int GetSize();
        
        public void SetBlock(BlockBase block, int i, int j);

        public BlockBase GetBlock(int i, int j);
        
        public void RemoveBlock(int i, int j);
    }
}