using App.Scripts.Libs.Services.Screen;
using App.Scripts.Libs.UI.Core.Panel.View;
using App.Scripts.Libs.UI.Elements.Button;
using App.Scripts.Libs.UI.Elements.Invisible.Click;
using App.Scripts.Libs.UI.Elements.Invisible.Swipe;
using UnityEngine;

namespace App.Scripts.UI.Panels.Game.View
{
    public class GamePanelView : PanelView
    {
        [field: SerializeField] public ClickZone clickZone;
        
        [field: SerializeField] public SwipeZone swipeZone;
        
        [field: SerializeField] public ActionButton PauseButton;

        public void Construct(IProjectScreen projectScreen)
        {
            swipeZone.Construct(projectScreen);
            PanelElement.Construct();
        }
    }
}