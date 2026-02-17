using App.Scripts.Libs.Patterns.Command.Default;
using App.Scripts.Libs.UI.Core.Container;
using App.Scripts.UI.Panels.Game.View;
using App.Scripts.UI.Panels.Lose.View;

namespace App.Scripts.Game.Commands.GameOver
{
    public class GameOverCommand : ICommand
    {
        private readonly IPanelContainer _container;

        public GameOverCommand(IPanelContainer container)
        {
            _container = container;
        }

        public void Execute()
        {
            var gamePanelView = _container.GetPanel<GamePanelView>();
            gamePanelView.Hide();
            
            var losePanelView = _container.GetPanel<LosePanelView>();
            _ = losePanelView.ShowAnimated();
        }
    }
}