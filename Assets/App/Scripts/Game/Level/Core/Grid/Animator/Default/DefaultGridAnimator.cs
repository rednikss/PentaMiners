using App.Scripts.Game.Level.Core.Grid.Data;
using Cysharp.Threading.Tasks;

namespace App.Scripts.Game.Level.Core.Grid.Animator.Default
{
    public class DefaultGridAnimator :  IGridAnimator
    {
        private readonly ILevelGrid _levelGrid;
        
        private readonly IGridData _gridData;

        public DefaultGridAnimator(ILevelGrid levelGrid, IGridData gridData)
        {
            _levelGrid = levelGrid;
            _gridData = gridData;
        }

        public UniTask UpdateGrid()
        {
            for (var i = 0; i < _gridData.GetSize().x; i++)
            for (var j = 0; j < _gridData.GetSize().y; j++)
            {
                UpdatePos(i, j);
            }
            
            return UniTask.CompletedTask;
        }

        private void UpdatePos(int i, int j)
        {
            var block = _levelGrid.GetBlock(i, j);
            if (block is null) return;
            
            var position = _gridData.GetPosition(i, j);
            if (block.GetPosition() == position)return;
                
            _levelGrid.GetBlock(i, j).SetPosition(_gridData.GetPosition(i, j)); 
        }
    }
}