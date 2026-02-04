using System;
using App.Scripts.Game.Level.Core.FallingBlock;
using App.Scripts.Game.Level.Core.Grid;
using App.Scripts.Game.Level.Core.Queue;
using App.Scripts.Libs.Services.Time.Tickable.Handler;

namespace App.Scripts.Game.Level.Core.Manager
{
    public class GameManager : IGameManager
    {
        private readonly IFallingBlock _fallingBlock;
        
        private readonly ILevelGrid _levelGrid;
        
        private readonly IBlockQueue _queue;
        
        private readonly ITickableHandler _tickableHandler;
        
        public event Action OnBlockDropped;
        
        public event Action OnLevelFail;
        
        public event Action OnLevelComplete;
        
        public GameManager(ILevelGrid levelGrid, IFallingBlock fallingBlock, IBlockQueue queue,
            ITickableHandler handler)
        {
            _fallingBlock = fallingBlock;
            _levelGrid = levelGrid;
            _queue = queue;
            _tickableHandler = handler;
            
            OnBlockDropped += fallingBlock.Drop;
            OnBlockDropped += OnDrop;
        }

        public void Start()
        {
            UpdateBlock();
            _tickableHandler.AddTickable(this);
        }

        public void SetSpeed(float speed) => _fallingBlock.SetSpeed(speed);
        
        public void DashBlock(int column) => _fallingBlock.DashToColumn(column);
        
        public void Stop()
        {
            _tickableHandler.RemoveTickable(this);
        }

        public void Tick(float deltaTime)
        {
            _fallingBlock.Tick(deltaTime);
            
            if (!_fallingBlock.IsDropped()) return;
            
            OnBlockDropped?.Invoke();
        }

        private void OnDrop()
        {
            if (_levelGrid.IsFull())
            {
                OnLevelFail?.Invoke();
                return;
            }

            if (_levelGrid.IsEmpty())
            {
                OnLevelComplete?.Invoke();
                return;
            }
            
            UpdateBlock();
        }
        
        private void UpdateBlock()
        {
            _fallingBlock.SetBlock(_queue.GetNext());

            var startPos = _levelGrid.GetSize();
            startPos.x /= 2;
            
            _fallingBlock.SetPosition(_levelGrid.GetPosition(startPos.x, startPos.y));
            _fallingBlock.DashToColumn(startPos.x);
        }
    }
}