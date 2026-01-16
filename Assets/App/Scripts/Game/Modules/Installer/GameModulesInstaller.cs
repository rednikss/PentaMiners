using App.Scripts.Game.Modules.Background;
using App.Scripts.Game.Modules.Starter;
using App.Scripts.Libs.Infrastructure.Core.EntryPoint.Starter;
using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer;
using App.Scripts.Libs.UI.Core.Container;
using UnityEngine;

namespace App.Scripts.Game.Installers.Modules
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
            var backAdapter = new BackgroundAdapter(backSprite, backTransform, sceneCamera);
            
            container.SetService<IBackgroundAdapter, BackgroundAdapter>(backAdapter);
        }

        private static void BuildSceneStarter(ServiceContainer container)
        {
            var panelContainer = container.GetService<IPanelContainer>();
            var backAdapter = container.GetService<IBackgroundAdapter>();
            
            var starter = new GameSceneStarter(panelContainer, backAdapter);

            container.SetService<ISceneStarter, GameSceneStarter>(starter);
        }
    }
}