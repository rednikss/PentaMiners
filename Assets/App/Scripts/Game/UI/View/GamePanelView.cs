using App.Scripts.Game.Panel.Click;
using App.Scripts.Libs.UI.Core.Panel.View;
using App.Scripts.Libs.UI.Elements.Button;
using UnityEngine;

namespace App.Scripts.Game.Panel.View
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