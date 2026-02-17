using App.Scripts.Game.Level.Core.Cycle;
using App.Scripts.Game.Level.Core.Grid;
using App.Scripts.Game.Level.Initialization.Builder;
using App.Scripts.Game.Level.Initialization.Loader;
using App.Scripts.Game.Modules.Cleaner;
using App.Scripts.Game.Modules.Starter;
using App.Scripts.Libs.Core.EntryPoint.Starter;
using App.Scripts.Libs.Core.Project.Model;
using App.Scripts.Libs.Core.Service.Container;
using App.Scripts.Libs.Core.Service.Installer;
using App.Scripts.Libs.Services.Screen;
using App.Scripts.Libs.Services.Screenshot;
using App.Scripts.Libs.Services.Time.Tickable.Handler;
using App.Scripts.Libs.UI.Core.Container;
using UnityEngine;

namespace App.Scripts.Game.Modules.Installer
{
    public class GameModulesInstaller : MonoInstaller
    {
        [SerializeField] private string levelPath;
        
        public override void InstallBindings(ServiceContainer container)
        {
            BuildScreenshotProvider(container);
            BuildSceneStarter(container);
            BuildSceneCleaner(container);
        }

        private void BuildSceneCleaner(ServiceContainer container)
        {
            var grid = container.GetService<ILevelGrid>();
            var cycle = container.GetService<ILevelCycle>();
            var handler = container.GetService<ITickableHandler>();
            
            var cleaner = new SceneCleaner(grid, cycle, handler);
            container.SetService<ISceneCleaner, SceneCleaner>(cleaner);
        }

        private void BuildScreenshotProvider(ServiceContainer container)
        {
            var screen = container.GetService<IProjectScreen>();
            var screenshot = new ScreenshotProvider(this, screen);
            container.SetService<IScreenshotProvider, ScreenshotProvider>(screenshot);
        }

        private void BuildSceneStarter(ServiceContainer container)
        {
            var playerModel = container.GetService<IPlayerModel>();
            var loader = new LevelLoader(levelPath);
            var builder = container.GetService<ILevelBuilder>();
            var panelContainer = container.GetService<IPanelContainer>();
            
            var starter = new GameSceneStarter(playerModel, loader, builder, panelContainer);
            container.SetService<ISceneStarter, GameSceneStarter>(starter);
        }
    }
}