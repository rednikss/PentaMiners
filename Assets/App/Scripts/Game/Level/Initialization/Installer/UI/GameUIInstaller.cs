using App.Scripts.Libs.Core.Service.Container;
using App.Scripts.Libs.Core.Service.Installer;
using App.Scripts.Libs.UI.Builder;

namespace App.Scripts.Game.Level.Initialization.Installer.UI
{
    public class GameUIInstaller : MonoInstaller
    {
        public override void InstallBindings(ServiceContainer container)
        {
            var builder = container.GetService<IPanelBuilder>();
            
            builder.BuildGamePanel();
            builder.BuildPausePanel();
        }
    }
}