using System.Collections.Generic;
using System.Threading;
using App.Scripts.Game.Level.Chain.Handler;
using App.Scripts.Game.Level.Core.Grid;
using App.Scripts.Game.Level.Core.Grid.Animator;
using App.Scripts.Game.Level.Core.Grid.Data;
using Cysharp.Threading.Tasks;

namespace App.Scripts.Game.Level.Chain.Removal
{
    public class ChainRemoval : IChainRemoval
    {
        private readonly ChainHandler _chainHandler;
        
        private readonly ILevelGrid _levelGrid;
        
        private readonly IGridInfo _gridInfo;
        
        private readonly IGridAnimator _animator;

        public ChainRemoval(ChainHandler chainHandler, ILevelGrid levelGrid, IGridInfo gridInfo, IGridAnimator animator)
        {
            _chainHandler = chainHandler;
            _levelGrid = levelGrid;
            _gridInfo = gridInfo;
            _animator = animator;
        }

        public async UniTask Remove(CancellationToken ctsToken)
        {
            while (true)
            {
                ctsToken.ThrowIfCancellationRequested();
                var columns = RemoveChains();
                if (columns.Count == 0) break;
                
                DropColumns(columns);
                await _animator.UpdateGrid(ctsToken);
            }
        }

        private HashSet<int> RemoveChains()
        {
            var changedColumns = new HashSet<int>();
            
            var blockList = _chainHandler.Handle();
            foreach (var index in blockList)
            {
                var b = _levelGrid.GetBlock(index.x, index.y);
                _levelGrid.SetBlock(null, index.x, index.y);
                
                b.Return();
                changedColumns.Add(index.x);
            }

            return changedColumns;
        }

        private void DropColumns(IEnumerable<int> columns)
        {
            foreach (var iD in columns)
            {
                DropColumn(iD);
            }
        }
        
        private void DropColumn(int i)
        {
            for (int read = 0, write = 0; read < _gridInfo.GetSize().y; read++)
            {
                var block = _levelGrid.GetBlock(i, read);
                if (block is null) continue;
                
                _levelGrid.SetBlock(null, i, read);
                _levelGrid.SetBlock(block, i, write++);
            }
        }
    }
}