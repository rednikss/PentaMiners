using App.Scripts.Game.Block.Types.Base;

namespace App.Scripts.Game.Block.Provider
{
    public interface IBlockProvider
    {
        public BlockBase GetBlock(int blockID);

        public T GetBlock<T>() where T : BlockBase;
    }
}