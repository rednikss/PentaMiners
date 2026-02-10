using System.Collections.Generic;
using App.Scripts.Game.Level.Core.Grid.Data;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Game.Level.Core.Grid.Animator.Wave
{
    public class WaveGridAnimator : IGridAnimator
    {
        private readonly ILevelGrid _levelGrid;
        
        private readonly IGridData _gridData;

        public WaveGridAnimator(ILevelGrid levelGrid, IGridData gridData)
        {
            _levelGrid = levelGrid;
            _gridData = gridData;
        }

        public async UniTask UpdateGrid()
        {
            for (var i = 0; i < _gridData.GetSize().x; i++)
            {
                await UpdateColumn(i);
            }
        }

        private async UniTask UpdateColumn(int i)
        {
            var tList = new List<UniTask>();

            for (var j = 0; j < _gridData.GetSize().y; j++)
            {
                var block = _levelGrid.GetBlock(i, j);
                if (block is null) break;
            
                var position = _gridData.GetPosition(i, j).y;
                if (Mathf.Approximately(block.GetPosition().y, position))continue;
                
                tList.Add(block.DashToY(position)); 
            }
            
            await UniTask.WhenAll(tList);
        }
    }
}