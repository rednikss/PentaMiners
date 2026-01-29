using App.Scripts.Libs.Core.Project.Options;
using App.Scripts.Libs.Core.Service.Container;
using App.Scripts.Libs.Core.Service.Installer;
using App.Scripts.Libs.Services.Screen;
using App.Scripts.Libs.Time.Tickable.Handler;
using App.Scripts.Libs.Time.Tickable.Handler.Default;
using App.Scripts.Libs.Time.Tickable.Handler.Fixed;
using App.Scripts.Libs.Time.Timer;
using UnityEngine;

namespace App.Scripts.Libs.Core.Project.Installer
{
    public class ProjectContextInstaller : MonoInstaller
    {
        [SerializeField, Min(1)] private int TargetFrameRate = 60;
        
        [SerializeField] private MonoTickableHandler defaultTickableHandler;
        
        [SerializeField] private FixedTickableHandler fixedTickableHandler;

        [SerializeField] private Camera _camera;
        
        public override void InstallBindings(ServiceContainer container)
        {
            new ProjectOptionsInstaller(TargetFrameRate).Execute();
            
            container.SetService<ITickableHandler, MonoTickableHandler>(defaultTickableHandler);
            container.SetServiceSelf(fixedTickableHandler);
            
            var timer = new Timer();
            container.SetServiceSelf(timer);
            
            var sceneScreen = new ProjectScreen(_camera);
            container.SetService<IProjectScreen, ProjectScreen>(sceneScreen);
            
            defaultTickableHandler.AddTickable(timer);
        }
    }
}