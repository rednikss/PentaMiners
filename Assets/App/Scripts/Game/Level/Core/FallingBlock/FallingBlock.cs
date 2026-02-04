using App.Scripts.Game.Block.Base;
using App.Scripts.Game.Level.Core.Grid;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Game.Level.Core.FallingBlock
{
    public class FallingBlock : IFallingBlock
    {
        private readonly ILevelGrid _levelGrid;
        
        private BlockBase _fallingBlock;

        private float _speed;

        private int _currentColumn;

        public FallingBlock(ILevelGrid levelGrid)
        {
            _levelGrid = levelGrid;
        }
        
        public void SetSpeed(float speed) => _speed = speed;

        public void SetPosition(Vector3 position) => _fallingBlock.SetPosition(position);

        public async UniTask DashToColumn(int i)
        {
            i = CheckPossibility(i);
            _currentColumn = i;
            
            var newPos = _levelGrid.GetPosition(i, 0).x;
            await _fallingBlock.DashToX(newPos);
        }

        private int CheckPossibility(int index)
        {
            var movingRight = _currentColumn < index;
            var direction = movingRight ? 1 : -1;

            for (int i = _currentColumn + direction; movingRight ? i < index : i > index; i += direction)
            {
                if (_levelGrid.HasDropped(_fallingBlock, i)) return i - direction;
            }
            
            return index;
        }

        public bool IsDropped() => _levelGrid.HasDropped(_fallingBlock, _currentColumn);

        public void Drop()
        {
            _levelGrid.AddBlock(_fallingBlock,  _currentColumn);
            
            _fallingBlock.OnDrop();
            _fallingBlock = null;
        }

        public void SetBlock(BlockBase fallingBlock) => _fallingBlock = fallingBlock;

        public void Tick(float deltaTime) => _fallingBlock.Move(deltaTime * _speed * Vector3.down);
    }
}