using App.Scripts.Game.Level.Loader;
using App.Scripts.Game.Modules.Background;
using App.Scripts.Game.Modules.Starter;
using App.Scripts.Libs.Core.EntryPoint.Starter;
using App.Scripts.Libs.Core.Service.Container;
using App.Scripts.Libs.Core.Service.Installer;
using App.Scripts.Libs.UI.Core.Container;
using UnityEngine;

namespace App.Scripts.Game.Modules.Installer
{
    public class GameModulesInstaller : MonoInstaller
    {
        [Header("Background")]

        [SerializeField] private SpriteRenderer backSprite;

        [SerializeField] private Transform backTransform;
        
        [SerializeField] private Camera sceneCamera;
        
        public override void InstallBindings(ServiceContainer container)
        {
            BuildBackground(container);
            BuildSceneStarter(container);
        }

        private void BuildBackground(ServiceContainer container)
        {
            var backAdapter = new BackgroundAdapter(backSprite, backTransform);
            
            container.SetService<IBackgroundAdapter, BackgroundAdapter>(backAdapter);
        }

        private static void BuildSceneStarter(ServiceContainer container)
        {
            var panelContainer = container.GetService<IPanelContainer>();
            var backAdapter = container.GetService<IBackgroundAdapter>();
            
            var starter = new GameSceneStarter(panelContainer, new LevelLoader("Level"));

            container.SetService<ISceneStarter, GameSceneStarter>(starter);
        }
    }
}