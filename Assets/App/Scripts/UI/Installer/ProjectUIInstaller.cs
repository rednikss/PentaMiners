using App.Scripts.Libs.Core.Service.Container;
using App.Scripts.Libs.Core.Service.Installer;
using App.Scripts.Libs.UI.Core.Container;
using App.Scripts.UI.Builder;
using App.Scripts.UI.Builder.Config;
using UnityEngine;

namespace App.Scripts.UI.Installer
{
    public class ProjectUIInstaller : MonoInstaller
    {
        [SerializeField] private PanelBuilderConfig _builderConfig;
        
        [SerializeField] private Canvas _projectCanvas;
        
        public override void InstallBindings(ServiceContainer container)
        {
            container.SetServiceSelf(_projectCanvas);

            var panelContainer = new PanelContainer();
            container.SetService<IPanelContainer, PanelContainer>(panelContainer);
            
            var builder = new PanelBuilder(_builderConfig, panelContainer, container);
            container.SetService<IPanelBuilder, PanelBuilder>(builder);
        }
    }
}