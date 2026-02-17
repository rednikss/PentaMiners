using System.Collections.Generic;
using App.Scripts.Libs.UI.Core.Panel.View;

namespace App.Scripts.Libs.UI.Core.Container
{
    public class PanelContainer : IPanelContainer
    {
        private readonly List<PanelView> _panels = new();

        public T GetPanel<T>() where T : PanelView
        {
            foreach (var panel in _panels)
            {
                if (panel.GetType() != typeof(T)) continue;
                
                return panel as T;
            }
            
            return null;
        }

        public bool HasPanel<T>() where T : PanelView => GetPanel<T>() is not null;

        public void AddPanel(PanelView panel) => _panels.Add(panel);

        public void RemovePanel(PanelView panel) => _panels.Remove(panel);
    }
}