using System.Threading;
using App.Scripts.Game.Level.Core.Grid.Data;
using Cysharp.Threading.Tasks;

namespace App.Scripts.Game.Level.Core.Grid.Animator.Default
{
    public class DefaultGridAnimator :  IGridAnimator
    {
        private readonly ILevelGrid _levelGrid;
        
        private readonly IGridInfo _gridInfo;

        public DefaultGridAnimator(ILevelGrid levelGrid, IGridInfo gridInfo)
        {
            _levelGrid = levelGrid;
            _gridInfo = gridInfo;
        }

        public UniTask UpdateGrid(CancellationToken ctsToken)
        {
            for (var i = 0; i < _gridInfo.GetSize().x; i++)
            for (var j = 0; j < _gridInfo.GetSize().y; j++)
            {
                UpdatePos(i, j);
            }
            
            return UniTask.CompletedTask;
        }

        private void UpdatePos(int i, int j)
        {
            var block = _levelGrid.GetBlock(i, j);
            if (block is null) return;
            
            var position = _gridInfo.IndexToWorldPos(i, j);
            if (block.GetPosition() == position)return;
                
            _levelGrid.GetBlock(i, j).SetPosition(_gridInfo.IndexToWorldPos(i, j)); 
        }
    }
}