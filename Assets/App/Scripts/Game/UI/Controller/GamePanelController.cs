using App.Scripts.Game.UI.View;
using App.Scripts.Libs.Patterns.Command.Value;
using App.Scripts.Libs.UI.Core.Panel.Controller;
using UnityEngine;

namespace App.Scripts.Game.UI.Controller
{
    public class GamePanelController : PanelController
    {
        private readonly GamePanelView _panelView;

        private readonly ICommand<Vector2> _clickCommand;
        
        public GamePanelController(GamePanelView panelView, ICommand<Vector2> clickCommand) : base(panelView)
        {
            _panelView = panelView;
            _clickCommand = clickCommand;
            
            InitInput();
        }

        private void InitInput()
        {
            _panelView.clickZone.OnClick += _clickCommand.Execute;
        }

        public override void Dispose()
        {
            _panelView.clickZone.OnClick -= _clickCommand.Execute;
        }
    }
}