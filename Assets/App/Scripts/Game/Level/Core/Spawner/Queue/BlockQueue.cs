using App.Scripts.Game.Block.Provider;
using App.Scripts.Game.Block.Types.Base;
using App.Scripts.Game.Block.Types.Default;

namespace App.Scripts.Game.Level.Core.Spawner.Queue
{
    public class BlockQueue : IBlockQueue
    {
        private readonly IBlockProvider _blockProvider;

        public BlockQueue(IBlockProvider blockProvider)
        {
            _blockProvider = blockProvider;
        }

        public BlockBase GetNext()
        {
            return _blockProvider.GetBlock<ColorBlock>();
        }
    }
}