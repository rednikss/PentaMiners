using App.Scripts.Game.Level.Initialization.Builder;
using App.Scripts.Game.Level.Initialization.Loader;
using App.Scripts.Game.Modules.Starter;
using App.Scripts.Libs.Core.EntryPoint.Starter;
using App.Scripts.Libs.Core.Project.Model;
using App.Scripts.Libs.Core.Service.Container;
using App.Scripts.Libs.Core.Service.Installer;
using App.Scripts.Libs.UI.Core.Container;
using UnityEngine;

namespace App.Scripts.Game.Modules.Installer
{
    public class GameModulesInstaller : MonoInstaller
    {
        [SerializeField] private string levelPath;
        
        
        public override void InstallBindings(ServiceContainer container)
        {
            BuildSceneStarter(container);
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