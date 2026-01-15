using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.UI.Core.Container.Builder.Config;

namespace App.Scripts.Libs.UI.Core.Container.Builder
{
    public class PanelBuilder
    {
        private readonly PanelBuilderConfig _config;
        
        private readonly PanelContainer _container;
        
        private readonly ServiceContainer _serviceContainer;

        public PanelBuilder(PanelBuilderConfig config, PanelContainer container, ServiceContainer serviceContainer)
        {
            _config = config;
            _container = container;
            _serviceContainer = serviceContainer;
        }

        public void BuildGamePanel()
        {
            //var view = _config.GetConfig<GamePanelView>();
        }

        public void BuildPausePanel()
        {
            
        }
    }
}