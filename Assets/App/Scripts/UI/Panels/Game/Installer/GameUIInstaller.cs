using App.Scripts.Libs.Core.Service.Container;
using App.Scripts.Libs.Core.Service.Installer;
using App.Scripts.UI.Builder;

namespace App.Scripts.UI.Panels.Game.Installer
{
    public class GameUIInstaller : MonoInstaller
    {
        public override void InstallBindings(ServiceContainer container)
        {
            var builder = container.GetService<IPanelBuilder>();
            
            builder.BuildGamePanel();
        }
    }
}