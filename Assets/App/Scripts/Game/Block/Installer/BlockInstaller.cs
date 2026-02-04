using App.Scripts.Game.Block.Provider;
using App.Scripts.Game.Block.Types.Default;
using App.Scripts.Game.Block.Types.Default.Factory;
using App.Scripts.Game.Block.Types.Rock;
using App.Scripts.Game.Block.Types.Rock.Factory;
using App.Scripts.Game.Level.Initialization.Config.Blocks;
using App.Scripts.Libs.Core.Service.Container;
using App.Scripts.Libs.Core.Service.Installer;
using App.Scripts.Libs.Patterns.ObjectPool;
using UnityEngine;

namespace App.Scripts.Game.Block.Installer
{
    public class BlockInstaller : MonoInstaller
    {
        [SerializeField] private LevelBlockConfig config;
        
        [SerializeField] private Transform blocksParent;
        
        public override void InstallBindings(ServiceContainer container)
        {
            var colorPool = new MonoBehaviourPool<ColorBlock>(config.colorBlock, blocksParent, 25);
            var rockPool = new MonoBehaviourPool<RockBlock>(config.rockBlock.Value, blocksParent, 3);
            
            var provider = new BlockProvider();

            foreach (var pair in config._colors)
            {
                var factory = new ColorBlockFactory(colorPool, pair.Value);
                
                provider.AddBlock(pair.ID, factory);
            }

            var rockFactory = new RockBlockFactory(rockPool);
            provider.AddBlock(config.rockBlock.ID, rockFactory);
            
            container.SetService<IBlockProvider, BlockProvider>(provider);
        }
    }
}