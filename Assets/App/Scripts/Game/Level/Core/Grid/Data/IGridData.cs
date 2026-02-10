using App.Scripts.Game.Block.Types.Base;
using UnityEngine;

namespace App.Scripts.Game.Level.Core.Grid.Data
{
    public interface IGridData
    {
        public void Init(Vector3 pos, float scale);
        
        public Vector2Int GetSize();
        
        public Vector3 GetPosition(int i, int j);
        
        public int GetDropIndex(int i);
        
        public bool IsDropped(BlockBase block, int i);
        
        public bool IsFull();
        
        public bool IsEmpty();
        
        public int ClampDashAbility(BlockBase block, int from, int to);
    }
}