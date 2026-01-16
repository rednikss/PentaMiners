using App.Scripts.Libs.Infrastructure.Core.Context.Options;
using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer;
using App.Scripts.Libs.Mechanics.Time.Tickable.Handler;
using App.Scripts.Libs.Mechanics.Time.Tickable.Handler.Default;
using App.Scripts.Libs.Mechanics.Time.Tickable.Handler.Fixed;
using App.Scripts.Libs.Mechanics.Time.Timer;
using UnityEngine;

namespace App.Scripts.Libs.Infrastructure.Core.Context.Installer
{
    public class ProjectContextInstaller : MonoInstaller
    {
        [SerializeField, Min(1)] private int TargetFrameRate = 60;
        
        [SerializeField] private MonoTickableHandler defaultTickableHandler;
        
        [SerializeField] private FixedTickableHandler fixedTickableHandler;

        public override void InstallBindings(ServiceContainer container)
        {
            container.SetService<ITickableHandler, MonoTickableHandler>(defaultTickableHandler);
            container.SetServiceSelf(fixedTickableHandler);
            
            var timer = new Timer();
            defaultTickableHandler.AddTickable(timer);
            container.SetServiceSelf(timer);

            var optionsInstaller = new ProjectOptionsInstaller(TargetFrameRate);
            optionsInstaller.Execute();
        }
    }
}