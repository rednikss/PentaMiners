using App.Scripts.Game.Panel.View;
using App.Scripts.Libs.UI.Core.Panel.Controller;

namespace App.Scripts.Game.Panel.Controller
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