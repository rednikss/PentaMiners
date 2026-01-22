using App.Scripts.Game.UI.View;
using App.Scripts.Libs.UI.Core.Panel.Controller;

namespace App.Scripts.Game.UI.Controller
{
    public class GamePanelController : PanelController
    {
        public GamePanelController(GamePanelView panelView) : base(panelView)
        {
        }

        public override void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}