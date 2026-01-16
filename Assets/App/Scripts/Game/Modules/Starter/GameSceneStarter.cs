using App.Scripts.Game.Modules.Background;
using App.Scripts.Game.Panel.Controller;
using App.Scripts.Libs.Infrastructure.Core.EntryPoint.Starter;
using App.Scripts.Libs.UI.Core.Container;

namespace App.Scripts.Game.Modules.Starter
{
    public class GameSceneStarter : ISceneStarter
    {
        private readonly IPanelContainer _panelContainer;
        
        private readonly IBackgroundAdapter _backgroundAdapter;

        public GameSceneStarter(IPanelContainer panelContainer, IBackgroundAdapter backgroundAdapter)
        {
            _panelContainer = panelContainer;
            _backgroundAdapter = backgroundAdapter;
        }

        public void StartScene()
        {
            var panel = _panelContainer.GetPanel<GamePanelController>();
            panel.ShowAnimated();
            
            _backgroundAdapter.SetSize(new(2, 10));
        }
    }
}