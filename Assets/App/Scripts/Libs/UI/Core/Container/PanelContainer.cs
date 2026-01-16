using System;
using System.Collections.Generic;
using App.Scripts.Libs.UI.Core.Panel.Controller;

namespace App.Scripts.Libs.UI.Core.Container
{
    public class PanelContainer : IPanelContainer
    {
        private readonly List<PanelController> _panels = new();

        public T GetPanel<T>() where T : PanelController
        {
            foreach (var panel in _panels)
            {
                if (panel.GetType() != typeof(T)) continue;
                
                return (T) panel;
            }

            return null;
        }

        public bool HasPanel<T>() where T : PanelController => GetPanel<T>() != null;

        public void AddPanel(PanelController panel) => _panels.Add(panel);

        public void RemovePanel(PanelController panel) => _panels.Remove(panel);

        public void Dispose()
        {
            while (_panels.Count > 0)
            {
                _panels[0].Destroy();
                _panels.RemoveAt(0);
            }
        }
    }
}