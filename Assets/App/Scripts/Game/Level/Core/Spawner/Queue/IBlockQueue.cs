using App.Scripts.Game.Block.Types.Base;

namespace App.Scripts.Game.Level.Core.Spawner.Queue
{
    public interface IBlockQueue
    {
        public BlockBase GetNext();
    }
}