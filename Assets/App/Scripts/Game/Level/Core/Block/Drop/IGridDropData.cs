using App.Scripts.Game.Block.Types.Base;

namespace App.Scripts.Game.Level.Core.Block.Drop
{
    public interface IGridDropData
    {
        public int GetDropIndex(int i);
        
        public int ClampDashAbility(BlockBase block, int from, int to);
    }
}