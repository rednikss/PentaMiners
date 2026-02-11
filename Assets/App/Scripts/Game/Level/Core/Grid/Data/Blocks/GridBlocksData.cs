using System.Collections.Generic;
using App.Scripts.Game.Block.Types.Default;
using UnityEngine;

namespace App.Scripts.Game.Level.Core.Grid.Data.Blocks
{
    public class GridBlocksData : IGridBlocksData
    {
        private readonly ILevelGrid _grid;

        public GridBlocksData(ILevelGrid grid)
        {
            _grid = grid;
        }

        public IList<Color> GetRemainingColors()
        {
            var colors = new HashSet<Color>();
            var size = _grid.GetSize();
            
            for (var i = 0; i < size.x; i++)
            for (var j = 0; j < size.y; j++)
            {
                if (_grid.GetBlock(i, j) is ColorBlock block)
                {
                    colors.Add(block.Color);
                }
            }
            
            return new List<Color>(colors);
        }
    }
}