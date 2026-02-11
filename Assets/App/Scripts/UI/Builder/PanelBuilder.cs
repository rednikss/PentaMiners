using App.Scripts.Game.Level.Core.Block;
using App.Scripts.Game.Level.Core.Grid.Data;
using App.Scripts.Libs.Core.Service.Container;
using App.Scripts.Libs.Services.Screen;
using App.Scripts.Libs.UI.Core.Container;
using App.Scripts.Libs.UI.Core.Panel.View;
using App.Scripts.UI.Builder.Config;
using App.Scripts.UI.Panels.Game.Commands.Dash;
using App.Scripts.UI.Panels.Game.Commands.Drop;
using App.Scripts.UI.Panels.Game.Controller;
using App.Scripts.UI.Panels.Game.View;
using UnityEngine;

namespace App.Scripts.UI.Builder
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

            var view = GetView<GamePanelView>();
            
            var screen = _serviceContainer.GetService<IProjectScreen>();
            view.Construct(screen);
            
            var gridInfo = _serviceContainer.GetService<IGridInfo>();
            var block = _serviceContainer.GetService<IFallingBlock>();
            var dash = new BlockDashCommand(gridInfo, block, screen);
            var drop = new DropBlockCommand(gridInfo, block);
            
            var controller = new GamePanelController(view, dash, drop);
            
            _container.AddPanel(controller);
        }

        public void BuildPausePanel()
        {
            
        }

        public void BuildOptionsPanel()
        {
        }

        private T GetView<T>() where T : PanelView
        {
            return Object.Instantiate(_config.GetPanelView<T>(), _canvasTransform);
        }
    }
}