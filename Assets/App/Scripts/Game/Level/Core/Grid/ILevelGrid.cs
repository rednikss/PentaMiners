using App.Scripts.Game.Block.Base;
using UnityEngine;

namespace App.Scripts.Game.Level.Core.Grid
{
    public interface ILevelGrid
    {
        public void Init(Vector2Int size, Vector3 bottomLeftPosition, float scale);

        public void SetBlock(BlockBase block, int i, int j);

        public void AddBlock(BlockBase block, int i);

        public Vector2Int GetSize();
        
        public Vector3 GetPosition(int i, int j);
        
        public bool HasDropped(BlockBase fallingBlock, int i);

        public bool IsFull();
        
        public bool IsEmpty();
    }
}