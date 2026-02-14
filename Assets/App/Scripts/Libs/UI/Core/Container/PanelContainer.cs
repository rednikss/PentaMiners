using System.Collections.Generic;
using App.Scripts.Libs.UI.Core.Panel.View;

namespace App.Scripts.Libs.UI.Core.Container
{
    public class PanelContainer : IPanelContainer
    {
        private readonly List<IPanelView> _panels = new();

        public T GetPanel<T>() where T : class, IPanelView
        {
            foreach (var panel in _panels)
            {
                if (panel.GetType() != typeof(T)) continue;
                
                return panel as T;
            }
            
            return null;
        }

        public bool HasPanel<T>() where T : class, IPanelView => GetPanel<T>() is not null;

        public void AddPanel(IPanelView panel) => _panels.Add(panel);

        public void RemovePanel(IPanelView panel) => _panels.Remove(panel);
    }
}