using App.Scripts.Libs.Patterns.Command.Value;
using App.Scripts.Libs.UI.Core.Panel.Controller;
using App.Scripts.UI.Panels.Game.View;
using UnityEngine;

namespace App.Scripts.UI.Panels.Game.Controller
{
    public class GamePanelController : PanelController
    {
        private readonly GamePanelView _panelView;

        private readonly ICommand<Vector2> _clickCommand;
        
        private readonly ICommand<Vector2> _swipeCommand;
        
        public GamePanelController(GamePanelView panelView, ICommand<Vector2> clickCommand, 
            ICommand<Vector2> swipeCommand) : base(panelView)
        {
            _panelView = panelView;
            _clickCommand = clickCommand;
            _swipeCommand = swipeCommand;
            
            InitInput();
        }

        private void InitInput()
        {
            _panelView.clickZone.OnClick += _clickCommand.Execute;
            _panelView.swipeZone.OnSwipe += _swipeCommand.Execute;
        }

        public override void Dispose()
        {
            _panelView.clickZone.OnClick -= _clickCommand.Execute;
            _panelView.swipeZone.OnSwipe -= _swipeCommand.Execute;
        }
    }
}