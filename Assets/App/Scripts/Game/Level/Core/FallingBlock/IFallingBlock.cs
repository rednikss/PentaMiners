using System.Threading.Tasks;
using App.Scripts.Game.Block.Base;
using App.Scripts.Libs.Services.Time.Tickable;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Game.Level.Core.FallingBlock
{
    public interface IFallingBlock : ITickable
    {
        public void SetSpeed(float speed);
        
        public void SetPosition(Vector3 position);
        
        public UniTask DashToColumn(int i);

        public bool IsDropped();

        public void Drop();
        
        public void SetBlock(BlockBase fallingBlock);
    }
}