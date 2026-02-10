using App.Scripts.Libs.Patterns.Factory;
using App.Scripts.Libs.Patterns.ObjectPool;
using UnityEngine;

namespace App.Scripts.Game.Block.Types.Default.Factory
{
    public class ColorBlockFactory : IFactory<ColorBlock>
    {
        private readonly IObjectPool<ColorBlock> _pool;
        
        private readonly Color _color;

        public ColorBlockFactory(IObjectPool<ColorBlock> pool, Color color)
        {
            _pool = pool;
            _color = color;
        }

        public ColorBlock Create()
        {
            var block = _pool.Get();
            block.Construct(_pool);
            block.Color = _color;
            
            return block;
        }
    }
}