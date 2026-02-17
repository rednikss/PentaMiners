using App.Scripts.Game.Level.Core.Block;
using App.Scripts.Game.Level.Core.Cycle;
using App.Scripts.Game.Level.Core.Grid.Data;
using App.Scripts.Game.Modules.Cleaner;
using App.Scripts.Libs.Core.EntryPoint.Starter;
using App.Scripts.Libs.Core.Service.Container;
using App.Scripts.Libs.Services.Screen;
using App.Scripts.Libs.Services.Screenshot;
using App.Scripts.Libs.Services.Time.Tickable.Handler;
using App.Scripts.Libs.Services.Tween.ManualManager;
using App.Scripts.Libs.UI.Builder;
using App.Scripts.Libs.UI.Builder.Config;
using App.Scripts.Libs.UI.Core.Container;
using App.Scripts.Libs.UI.Core.Panel.Animator.Fade;
using App.Scripts.Libs.UI.Core.Panel.Animator.Move;
using App.Scripts.UI.Panels.Commands.Dash;
using App.Scripts.UI.Panels.Commands.Drop;
using App.Scripts.UI.Panels.Commands.Pause;
using App.Scripts.UI.Panels.Commands.Restart;
using App.Scripts.UI.Panels.Game.View;
using App.Scripts.UI.Panels.Lose.Animator;
using App.Scripts.UI.Panels.Lose.Config;
using App.Scripts.UI.Panels.Lose.View;
using App.Scripts.UI.Panels.Pause.View;
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
            if (_container.HasPanel<GamePanelView>()) return;

            var gridInfo = _serviceContainer.GetService<IGridInfo>();
            var block = _serviceContainer.GetService<IFallingBlock>();
            var screen = _serviceContainer.GetService<IProjectScreen>();
            var cycle = _serviceContainer.GetService<ILevelCycle>();
            var handler = _serviceContainer.GetService<ITickableHandler>();
            var tweenManager = _serviceContainer.GetService<ITweenManager>();
            
            var config = _config.GetPanelConfig<GamePanelView>();
            var view = Object.Instantiate(config.View as GamePanelView, _canvasTransform);
            
            var animator = new FadePanelAnimator(config.Animator);
            var dash = new BlockDashCommand(gridInfo, block, screen);
            var drop = new DropBlockCommand(gridInfo, block);
            var pause = new PauseGameCommand(handler, cycle, _container, tweenManager);
            
            view.Construct(animator, screen);
            view.clickZone.OnClick += dash.Execute;
            view.swipeZone.OnSwipe += drop.Execute;
            view.pauseButton.OnClick += pause.Execute;
            view.Hide();
            
            _container.AddPanel(view);
        }

        public void BuildPausePanel()
        {
            if (_container.HasPanel<PausePanelView>()) return;
            
            var screen = _serviceContainer.GetService<IProjectScreen>();
            var cycle = _serviceContainer.GetService<ILevelCycle>();
            var handler = _serviceContainer.GetService<ITickableHandler>();
            var tweenManager = _serviceContainer.GetService<ITweenManager>();
            var starter =  _serviceContainer.GetService<ISceneStarter>();
            var cleaner =  _serviceContainer.GetService<ISceneCleaner>();
            
            var config = _config.GetPanelConfig<PausePanelView>();
            var view = Object.Instantiate(config.View as PausePanelView, _canvasTransform);

            var animator = new MovePanelAnimator(config.Animator, Vector2.down, screen);
            var pause = new PauseGameCommand(handler, cycle, _container, tweenManager);
            var restart = new RestartGameCommand<PausePanelView>(starter, cleaner, _container);
            
            view.Construct(animator);
            view.resumeButton.OnClick += pause.Cancel;
            view.restartButton.OnClick += pause.Cancel;
            view.restartButton.OnClick += restart.Execute;
            view.Hide();
            
            _container.AddPanel(view);
        }

        public void BuildLosePanel()
        {
            if (_container.HasPanel<LosePanelView>()) return;
            
            var screenshot = _serviceContainer.GetService<IScreenshotProvider>();
            var starter =  _serviceContainer.GetService<ISceneStarter>();
            var cleaner =  _serviceContainer.GetService<ISceneCleaner>();
            
            var config = _config.GetPanelConfig<LosePanelView>();
            var view = Object.Instantiate(config.View as LosePanelView, _canvasTransform);

            var animator = new LosePanelAnimator(config.Animator as LosePanelViewConfig, view, screenshot);
            var restart = new RestartGameCommand<LosePanelView>(starter, cleaner, _container);
            
            view.Construct(animator);
            view.restartButton.OnClick += restart.Execute;
            view.Hide();
            
            _container.AddPanel(view);
        }
    }
}