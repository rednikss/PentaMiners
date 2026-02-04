using App.Scripts.Libs.UI.Core.Panel.View;
using App.Scripts.Libs.UI.Elements.Button;
using App.Scripts.Libs.UI.Elements.Click;
using UnityEngine;

namespace App.Scripts.Game.UI.View
{
    public class GamePanelView : PanelView
    {
        [field: SerializeField] public ClickZone clickZone;
        
        [field: SerializeField] public ActionButton PauseButton;

        public void Construct()
        {
            PanelElement.Construct();
        }
    }
}