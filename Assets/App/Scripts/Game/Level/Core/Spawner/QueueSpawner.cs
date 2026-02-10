using App.Scripts.Game.Level.Core.Block;
using App.Scripts.Game.Level.Core.Grid.Data;
using App.Scripts.Game.Level.Core.Spawner.Queue;
using UnityEngine;

namespace App.Scripts.Game.Level.Core.Spawner
{
    public class QueueSpawner : IQueueSpawner
    {
        private readonly IGridData _gridData;
        
        private readonly IFallingBlock _fallingBlock;
        
        private IBlockQueue _queue;

        public QueueSpawner(IGridData gridData, IFallingBlock fallingBlock)
        {
            _gridData = gridData;
            _fallingBlock = fallingBlock;
        }

        public void Init(IBlockQueue queue)
        {
            _queue =  queue;
        }

        public void SpawnNext()
        {
            var block = _queue.GetNext();
            var gridPos = GetStartPos();
            
            _fallingBlock.SetBlock(block, gridPos.x, gridPos.y);
        }

        private Vector2Int GetStartPos()
        {
            var startPos = _gridData.GetSize();
            startPos.x /= 2;
            
            return startPos;
        }
    }
}