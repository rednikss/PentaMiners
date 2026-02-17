using System;
using App.Scripts.Game.Level.Core.Cycle;
using App.Scripts.Libs.Patterns.Command.Value;
using App.Scripts.Libs.Services.Time.Tickable.Handler;
using App.Scripts.Libs.Services.Tween.ManualManager;
using App.Scripts.Libs.UI.Core.Container;
using App.Scripts.UI.Panels.Pause.View;
using UnityEngine;

namespace App.Scripts.UI.Panels.Commands.Pause
{
    public class PauseGameCommand : ICommandCancelable
    {
        private readonly ITickableHandler _handler;
        
        private readonly ILevelCycle _cycle;
        
        private readonly IPanelContainer _panelContainer;

        private readonly ITweenManager _tweenManager;

        public PauseGameCommand(ITickableHandler handler, ILevelCycle cycle, 
            IPanelContainer panelContainer, ITweenManager tweenManager)
        {
            _handler = handler;
            _cycle = cycle;
            _panelContainer = panelContainer;
            _tweenManager = tweenManager;
        }

        public void Execute()
        {
            _handler.RemoveTickable(_tweenManager);
            _handler.RemoveTickable(_cycle);
            
            var p = _panelContainer.GetPanel<PausePanelView>();
            _ = p.ShowAnimated();
        }

        public async void Cancel()
        {
            try
            {
                var p = _panelContainer.GetPanel<PausePanelView>();
                await p.HideAnimated();
            
                _handler.AddTickable(_tweenManager);
                _handler.AddTickable(_cycle);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}