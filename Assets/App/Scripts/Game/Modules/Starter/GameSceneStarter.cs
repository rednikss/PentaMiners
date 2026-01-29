using App.Scripts.Game.Level.Initialization.Builder;
using App.Scripts.Game.Level.Initialization.Loader;
using App.Scripts.Game.UI.Controller;
using App.Scripts.Libs.Core.EntryPoint.Starter;
using App.Scripts.Libs.Core.Project.Model;
using App.Scripts.Libs.UI.Core.Container;

namespace App.Scripts.Game.Modules.Starter
{
    public class GameSceneStarter : ISceneStarter
    {
        private readonly IPlayerModel _playerModel;

        private readonly ILevelLoader _levelLoader;
        
        private readonly ILevelBuilder _levelBuilder;

        private readonly IPanelContainer _panelContainer;

        public GameSceneStarter(IPlayerModel playerModel, ILevelLoader levelLoader, 
            ILevelBuilder levelBuilder, IPanelContainer panelContainer)
        {
            _panelContainer = panelContainer;
            _playerModel = playerModel;
            _levelLoader = levelLoader;
            _levelBuilder = levelBuilder;
        }

        public void StartScene()
        {
            var panel = _panelContainer.GetPanel<GamePanelController>();
            panel.ShowAnimated();

            var counter = _playerModel.GetCurrentLevelCounter();
            var level = _levelLoader.LoadLevel(counter);
            
            _levelBuilder.Build(level);
        }
    }
}