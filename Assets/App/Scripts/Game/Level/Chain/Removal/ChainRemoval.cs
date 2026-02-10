using System.Collections.Generic;
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
        
        private readonly IGridData _gridData;
        
        private readonly IGridAnimator _animator;

        public ChainRemoval(ChainHandler chainHandler, ILevelGrid levelGrid, IGridData gridData, IGridAnimator animator)
        {
            _chainHandler = chainHandler;
            _levelGrid = levelGrid;
            _gridData = gridData;
            _animator = animator;
        }

        public async UniTask Remove()
        {
            while (true)
            {
                HashSet<int> columns = RemoveChains();
                if (columns.Count == 0) break;
                
                DropColumns(columns);
                await _animator.UpdateGrid();
            }
        }

        private HashSet<int> RemoveChains()
        {
            var changedColumns = new HashSet<int>();
            
            var blockList = _chainHandler.Handle();
            if (blockList.Count == 0) return changedColumns;
                
            foreach (var index in blockList)
            {
                _levelGrid.RemoveBlock(index.x, index.y);
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
            for (int read = 0, write = 0; read < _gridData.GetSize().y; read++)
            {
                var block = _levelGrid.GetBlock(i, read);
                if (block is null) continue;
                
                _levelGrid.SetBlock(null, i, read);
                _levelGrid.SetBlock(block, i, write++);
            }
        }
    }
}