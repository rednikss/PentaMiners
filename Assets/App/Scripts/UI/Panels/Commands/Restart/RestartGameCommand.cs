using App.Scripts.Game.Modules.Cleaner;
using App.Scripts.Libs.Core.EntryPoint.Starter;
using App.Scripts.Libs.Patterns.Command.Default;
using App.Scripts.Libs.UI.Core.Container;
using App.Scripts.Libs.UI.Core.Panel.View;
using DG.Tweening;

namespace App.Scripts.UI.Panels.Commands.Restart
{
    public class RestartGameCommand<TPanelView> : ICommand where TPanelView : PanelView
    {
        private readonly ISceneStarter _sceneStarter;
        
        private readonly ISceneCleaner _sceneCleaner;
        
        private readonly IPanelContainer _container;

        public RestartGameCommand(ISceneStarter sceneStarter, ISceneCleaner sceneCleaner, IPanelContainer container)
        {
            _sceneStarter = sceneStarter;
            _sceneCleaner = sceneCleaner;
            _container = container;
        }

        public void Execute()
        {
            _container.GetPanel<TPanelView>().Hide();
            _sceneCleaner.Clear();
            _sceneStarter.StartScene();
        }
    }
}