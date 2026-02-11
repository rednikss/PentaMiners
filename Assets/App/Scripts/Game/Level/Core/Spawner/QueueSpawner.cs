using App.Scripts.Game.Level.Core.Block;
using App.Scripts.Game.Level.Core.Grid.Data;
using App.Scripts.Game.Level.Core.Spawner.Queue;
using UnityEngine;

namespace App.Scripts.Game.Level.Core.Spawner
{
    public class QueueSpawner : IQueueSpawner
    {
        private readonly IGridInfo _gridInfo;
        
        private readonly IFallingBlock _fallingBlock;
        
        private IBlockQueue _queue;

        public QueueSpawner(IGridInfo gridInfo, IFallingBlock fallingBlock)
        {
            _gridInfo = gridInfo;
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
            var worldPos = _gridInfo.IndexToWorldPos(gridPos.x, gridPos.y);
            
            block.SetPosition(worldPos);
            _fallingBlock.SetBlock(block, gridPos.x);
        }

        private Vector2Int GetStartPos()
        {
            var startPos = _gridInfo.GetSize();
            startPos.x /= 2;
            
            return startPos;
        }
    }
}