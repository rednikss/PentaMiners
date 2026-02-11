using App.Scripts.Game.Block.Types.Base;
using UnityEngine;

namespace App.Scripts.Game.Level.Core.Block
{
    public interface IFallingBlock
    {
        public void SetBlock(BlockBase block, int i);
        
        public void Move(Vector3 delta);
        
        public void DashToColumn(int i);

        public bool IsDropped();
        
        public void Drop();
    }
}