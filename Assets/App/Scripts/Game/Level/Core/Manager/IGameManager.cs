using App.Scripts.Game.Block.Base;
using App.Scripts.Libs.Time.Tickable;

namespace App.Scripts.Game.Level.Core.Manager
{
    public interface IGameManager : ITickable
    {
        public void InitGrid(int width, int height, float step);
        
        public void SetSpeed(float speed);
        
        public void SetBlock(BlockBase block, int i, int j);

        public void SetFallingBlockToColumn(int i);
        
        public void SpawnFallingBlock();
    }
}