using App.Scripts.Game.Block.Base;

namespace App.Scripts.Game.Level.Core.Queue
{
    public interface IBlockQueue
    {
        public BlockBase GetNext();
    }
}