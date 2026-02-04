using App.Scripts.Libs.Patterns.Factory;
using App.Scripts.Libs.Patterns.ObjectPool;

namespace App.Scripts.Game.Block.Types.Rock.Factory
{
    public class RockBlockFactory : IFactory<RockBlock>
    {
        private readonly IObjectPool<RockBlock> _pool;

        public RockBlockFactory(IObjectPool<RockBlock> pool)
        {
            _pool = pool;
        }
        
        public RockBlock Create()
        {
            var block = _pool.Get();
            
            return block;
        }
    }
}