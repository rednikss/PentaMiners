using App.Scripts.Game.Level.Commands.Dash;
using App.Scripts.Game.Level.Core.Grid;
using App.Scripts.Game.Level.Core.Manager;
using App.Scripts.Game.UI.Controller;
using App.Scripts.Game.UI.View;
using App.Scripts.Libs.Core.Service.Container;
using App.Scripts.Libs.Services.Screen;
using App.Scripts.Libs.UI.Core.Builder.Config;
using App.Scripts.Libs.UI.Core.Container;
using UnityEngine;

namespace App.Scripts.Libs.UI.Core.Builder
{
    public class PanelBuilder : IPanelBuilder
    {
        private readonly IPanelProvider _config;
        
        private readonly IPanelContainer _container;
        
        private readonly ServiceContainer _serviceContainer;
        
        private readonly Transform _canvasTransform;

        public PanelBuilder(IPanelProvider config, IPanelContainer container, ServiceContainer serviceContainer)
        {
            _config = config;
            _container = container;
            _serviceContainer = serviceContainer;
            
            _canvasTransform = _serviceContainer.GetService<Canvas>().transform;
        }

        public void BuildGamePanel()
        {
            if (_container.HasPanel<GamePanelController>()) return;

            var view = Object.Instantiate(_config.GetPanelView<GamePanelView>(), _canvasTransform);

            var screen = _serviceContainer.GetService<IProjectScreen>();
            var grid = _serviceContainer.GetService<ILevelGrid>();
            var manager = _serviceContainer.GetService<IGameManager>();
            var command = new BlockDashCommand(screen, grid, manager);
            
            var controller = new GamePanelController(view, command);
            
            view.Construct();
            _container.AddPanel(controller);
        }

        public void BuildPausePanel()
        {
            
        }

        public void BuildOptionsPanel()
        {
        }
    }
}