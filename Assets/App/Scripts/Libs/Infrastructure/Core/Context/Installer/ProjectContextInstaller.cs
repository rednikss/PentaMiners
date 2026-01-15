using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer;
using App.Scripts.Libs.Mechanics.Time.Tickable.Handler;
using App.Scripts.Libs.Mechanics.Time.Tickable.Handler.Default;
using App.Scripts.Libs.Mechanics.Time.Timer;
using App.Scripts.Libs.UI.Core.Container;
using UnityEngine;

namespace App.Scripts.Libs.Infrastructure.Core.Context.Installer
{
    public class ProjectContextInstaller : MonoInstaller
    {
        [SerializeField] private Canvas _projectCanvas;

        [SerializeField] private MonoTickableHandler defaultTickableHandler;

        public override void InstallBindings(ServiceContainer container)
        {
            var panelContainer = new PanelContainer();
            
            var timer = new Timer();
            defaultTickableHandler.AddTickable(timer);
            
            container.SetServiceSelf(_projectCanvas);
            
            container.SetServiceSelf(panelContainer);
            
            container.SetService<ITickableHandler, MonoTickableHandler>(defaultTickableHandler);
            container.SetServiceSelf(timer);
        }
    }
}