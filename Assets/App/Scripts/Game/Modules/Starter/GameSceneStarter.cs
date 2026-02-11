using System.Threading.Tasks;
using App.Scripts.Game.Level.Initialization.Builder;
using App.Scripts.Game.Level.Initialization.Loader;
using App.Scripts.Libs.Core.EntryPoint.Starter;
using App.Scripts.Libs.Core.Project.Model;
using App.Scripts.Libs.UI.Core.Container;
using App.Scripts.UI.Panels.Game.Controller;

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

        public async Task StartScene()
        {
            var counter = _playerModel.GetCurrentLevelCounter();
            var level = _levelLoader.LoadLevel(counter);
            var manager = _levelBuilder.Build(level);
            
            var panel = _panelContainer.GetPanel<GamePanelController>();
            await panel.ShowAnimated();
            
            manager.Start();
        }
    }
}