using App.Scripts.Game.Block.Provider;
using App.Scripts.Game.Level.Background;
using App.Scripts.Game.Level.Core.GameOver;
using App.Scripts.Game.Level.Core.Manager;
using App.Scripts.Game.Level.Initialization.Builder;
using App.Scripts.Game.Level.Initialization.Loader;
using App.Scripts.Libs.Core.Service.Container;
using App.Scripts.Libs.Core.Service.Installer;
using App.Scripts.Libs.Services.Screen;
using App.Scripts.Libs.Time.Tickable.Handler;
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
            
            var screen = container.GetService<IProjectScreen>();
            var pos = screen.GetPositionByPercent(Vector2.zero);
            
            var backAdapter = new BackgroundAdapter(backgroundSprite, backgroundTransform, pos);
            container.SetService<IBackgroundAdapter, BackgroundAdapter>(backAdapter);

            var provider = container.GetService<IBlockProvider>();
            var gameOverCommand = new GameOverCommand();
            var gameManager = new GameManager(pos, provider, gameOverCommand);
            container.SetService<IGameManager, GameManager>(gameManager);
            
            var tickableHandler = container.GetService<ITickableHandler>();
            tickableHandler.AddTickable(gameManager);
        }

        private void BuildLevelBuilder(ServiceContainer container)
        {
            var sceneScreen = container.GetService<IProjectScreen>();
            var provider = container.GetService<IBlockProvider>();
            var gameManager = container.GetService<IGameManager>();
            var backAdapter = container.GetService<IBackgroundAdapter>();
            
            var builder = new LevelBuilder(sceneScreen, backAdapter, provider, gameManager);
            container.SetService<ILevelBuilder, LevelBuilder>(builder);
        }
    }
}