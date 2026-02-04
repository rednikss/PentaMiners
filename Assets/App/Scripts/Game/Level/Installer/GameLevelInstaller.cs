using App.Scripts.Game.Block.Provider;
using App.Scripts.Game.Level.Background;
using App.Scripts.Game.Level.Core.FallingBlock;
using App.Scripts.Game.Level.Core.Grid;
using App.Scripts.Game.Level.Core.Manager;
using App.Scripts.Game.Level.Core.Queue;
using App.Scripts.Game.Level.Initialization.Builder;
using App.Scripts.Game.Level.Initialization.Loader;
using App.Scripts.Libs.Core.Service.Container;
using App.Scripts.Libs.Core.Service.Installer;
using App.Scripts.Libs.Services.Screen;
using App.Scripts.Libs.Services.Time.Tickable.Handler;
using UnityEngine;

namespace App.Scripts.Game.Level.Installer
{
    public class GameLevelInstaller : MonoInstaller
    {
        [SerializeField] private string levelPath;

        [SerializeField] private Camera sceneCamera;
        
        [Header("Background")]
        
        [SerializeField] private Transform backgroundTransform;
        
        [SerializeField] private SpriteRenderer backgroundSprite;

        public override void InstallBindings(ServiceContainer container)
        {
            BuildLevelSystem(container);
            BuildLevelBuilder(container);
        }

        private void BuildLevelSystem(ServiceContainer container)
        {
            var loader = new LevelLoader(levelPath);
            container.SetService<ILevelLoader, LevelLoader>(loader);
            
            var backAdapter = new BackgroundAdapter(backgroundSprite, backgroundTransform);
            container.SetService<IBackgroundAdapter, BackgroundAdapter>(backAdapter);

            var provider = container.GetService<IBlockProvider>();
            
            var levelGrid = new LevelGrid();
            container.SetService<ILevelGrid, LevelGrid>(levelGrid);
            
            var block = new FallingBlock(levelGrid);
            var queue = new BlockQueue(provider);
            var tickableHandler = container.GetService<ITickableHandler>();
            
            var gameManager = new GameManager(levelGrid, block, queue, tickableHandler);
            container.SetService<IGameManager, GameManager>(gameManager);
        }

        private void BuildLevelBuilder(ServiceContainer container)
        {
            var sceneScreen = container.GetService<IProjectScreen>();
            var grid = container.GetService<ILevelGrid>();
            var backAdapter = container.GetService<IBackgroundAdapter>();
            var provider = container.GetService<IBlockProvider>();
            var gameManager = container.GetService<IGameManager>();
            
            var builder = new LevelBuilder(sceneScreen, grid, backAdapter, provider, gameManager);
            container.SetService<ILevelBuilder, LevelBuilder>(builder);
        }
    }
}