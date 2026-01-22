using App.Scripts.Libs.Core.Service.Container;
using App.Scripts.Libs.Core.Service.Installer;
using App.Scripts.Libs.UI.Core.Builder;

namespace App.Scripts.Game.UI.Installer
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