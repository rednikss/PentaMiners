using App.Scripts.Game.Level.Block.View;
using App.Scripts.Libs.Time.Tickable;
using UnityEngine;

namespace App.Scripts.Game.Level.Block.Controller
{
    public class BlockController : ITickable
    {
        private readonly BlockView _blockView;
        
        private float _velocity;
        
        public void Tick(float deltaTime)
        {
            Move(_velocity * deltaTime * Vector3.down);
        }

        private void Move(Vector3 delta) => _blockView.Move(delta);
    }
}