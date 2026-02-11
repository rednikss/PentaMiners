using System;
using App.Scripts.Game.Level.Chain.Removal;
using App.Scripts.Game.Level.Core.Block;
using App.Scripts.Game.Level.Core.Grid.Data.State;
using App.Scripts.Game.Level.Core.Spawner;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Game.Level.Core.Cycle
{
    public class LevelCycle : ILevelCycle
    {
        private readonly IGridState _gridState;
        
        private readonly IQueueSpawner _queue;
        
        private readonly IChainRemoval _chainRemoval;

        private readonly IFallingBlock _fallingBlock;
        
        private float _speed;
        
        public event Action OnLevelFail;
        
        public event Action OnLevelComplete;
        
        public LevelCycle(IGridState gridState, IFallingBlock fallingBlock, IQueueSpawner queue,
            IChainRemoval chainRemoval)
        {
            _gridState = gridState;
            _fallingBlock = fallingBlock;
            _queue = queue;
            _chainRemoval = chainRemoval;
        }
        
        public void Start()
        {
            _queue.SpawnNext();
        }

        public void Tick(float deltaTime)
        {
            _fallingBlock.Move(_speed * deltaTime * Vector3.down);

            if (!_fallingBlock.IsDropped()) return;
            
            _ = DropEvent();
        }

        public void SetSpeed(float speed) => _speed = speed;

        private async UniTask DropEvent()
        {
            _fallingBlock.Drop();
            
            await _chainRemoval.Remove();
            
            if (CheckGameEnded()) return;
            
            _queue.SpawnNext();
        }

        private bool CheckGameEnded()
        {
            if (_gridState.IsFull())
            {
                OnLevelFail?.Invoke();
                return true;
            }
            
            if (_gridState.IsEmpty())
            {
                OnLevelComplete?.Invoke();
                return true;
            }

            return false;
        }
    }
}