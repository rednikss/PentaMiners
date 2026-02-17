using System.Collections.Generic;
using System.Threading;
using App.Scripts.Game.Level.Core.Grid.Data;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Game.Level.Core.Grid.Animator.Wave
{
    public class WaveGridAnimator : IGridAnimator
    {
        private readonly ILevelGrid _levelGrid;
        
        private readonly IGridInfo _gridInfo;
        

        public WaveGridAnimator(ILevelGrid levelGrid, IGridInfo gridInfo)
        {
            _levelGrid = levelGrid;
            _gridInfo = gridInfo;
        }

        public async UniTask UpdateGrid(CancellationToken ctsToken)
        {
            for (var i = 0; i < _gridInfo.GetSize().x - 1; i++)
            {
                ctsToken.ThrowIfCancellationRequested();
                await UpdateColumn(i, ctsToken);
            }
            
        }

        private async UniTask UpdateColumn(int i, CancellationToken ctsToken)
        {
            var t = new List<UniTask>();
            
            for (var j = 0; j < _gridInfo.GetSize().y; j++)
            {
                var block = _levelGrid.GetBlock(i, j);
                
                if (block is null) break;
            
                var position = _gridInfo.IndexToWorldPos(i, j).y;
                if (Mathf.Approximately(block.GetPosition().y, position)) continue;
                
                t.Add(block.DashToY(position)); 
            }
            
            await UniTask.WhenAll(t);
        }
    }
}