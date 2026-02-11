using System.Collections.Generic;
using App.Scripts.Game.Level.Core.Grid.Data;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Game.Level.Core.Grid.Animator.Wave
{
    public class WaveGridAnimator : IGridAnimator
    {
        private readonly ILevelGrid _levelGrid;
        
        private readonly IGridInfo _gridInfo;
        
        private readonly float _stepTime;

        public WaveGridAnimator(ILevelGrid levelGrid, IGridInfo gridInfo, float stepTime)
        {
            _levelGrid = levelGrid;
            _gridInfo = gridInfo;
            _stepTime = stepTime;
        }

        public async UniTask UpdateGrid()
        {
            for (var i = 0; i < _gridInfo.GetSize().x - 1; i++)
            {
                await UpdateColumn(i);
            }
        }

        private async UniTask UpdateColumn(int i)
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