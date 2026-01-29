using App.Scripts.Game.Block.Base;
using App.Scripts.Game.Block.Base.Color;
using App.Scripts.Game.Block.Base.Rock;
using App.Scripts.Game.Level.Initialization.Config.Blocks;
using App.Scripts.Libs.Patterns.ObjectPool;
using UnityEngine;

namespace App.Scripts.Game.Block.Provider
{
    public class BlockProvider : IBlockProvider
    {
        private readonly LevelBlockConfig _config;
        
        private readonly IObjectPool<ColorBlock> _colorPool;
        
        private readonly IObjectPool<RockBlock> _rockPool;

        public BlockProvider(LevelBlockConfig config, IObjectPool<ColorBlock> colorPool,
            IObjectPool<RockBlock> rockPool)
        {
            _colorPool = colorPool;
            _rockPool = rockPool;
            _config = config;
        }
        
        public BlockBase GetBlock(int blockID)
        {
            if (blockID == _config.rockBlock.ID) return _rockPool.Get();
            
            var colorBlock = _colorPool.Get();
            colorBlock.SetColor(_config.GetColor(blockID));
            
            return colorBlock;
        }

        public BlockBase GetNext()
        {
            return GetRandomColorBlock();
        }

        private BlockBase GetRandomColorBlock()
        {
            var id = Random.Range(0, _config._colors.Length);

            var block = _colorPool.Get();
            block.SetColor(_config._colors[id].Value);
            
            return block;
        }
    }
}