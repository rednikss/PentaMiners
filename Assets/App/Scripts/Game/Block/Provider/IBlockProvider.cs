using App.Scripts.Game.Block.Base;

namespace App.Scripts.Game.Block.Provider
{
    public interface IBlockProvider
    {
        public BlockBase GetBlock(int blockID);

        public T GetBlock<T>() where T : BlockBase;
    }
}