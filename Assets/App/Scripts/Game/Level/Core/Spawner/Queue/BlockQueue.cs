using App.Scripts.Game.Block.Provider;
using App.Scripts.Game.Block.Types.Base;
using App.Scripts.Game.Block.Types.Default;
using App.Scripts.Game.Level.Core.Grid.Data.Blocks;
using UnityEngine;

namespace App.Scripts.Game.Level.Core.Spawner.Queue
{
    public class BlockQueue : IBlockQueue
    {
        private readonly IBlockProvider _blockProvider;
        
        private readonly IGridBlocksData _blocksData;

        public BlockQueue(IBlockProvider blockProvider, IGridBlocksData blocksData)
        {
            _blockProvider = blockProvider;
            _blocksData = blocksData;
        }

        public BlockBase GetNext()
        {
            return GetRandomColorBlock();
        }

        private ColorBlock GetRandomColorBlock()
        {
            var block = _blockProvider.GetBlock<ColorBlock>();
            
            var colors = _blocksData.GetRemainingColors();
            var id = Random.Range(0, colors.Count);
            block.Color = colors[id];
            
            return block;
        }
    }
}