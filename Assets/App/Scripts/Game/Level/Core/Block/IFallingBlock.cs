using App.Scripts.Game.Block.Types.Base;
using UnityEngine;

namespace App.Scripts.Game.Level.Core.Block
{
    public interface IFallingBlock
    {
        public void SetBlock(BlockBase block, int i);
        
        public BlockBase GetBlock();
        
        public void DashToColumn(int i);

        public bool IsDropped();
        
        public void Drop();
    }
}