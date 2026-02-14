using App.Scripts.Libs.UI.Core.Panel.View;

namespace App.Scripts.Libs.UI.Core.Container
{
    public interface IPanelContainer
    {
        public T GetPanel<T>() where T : class, IPanelView;

        public bool HasPanel<T>() where T : class, IPanelView;

        public void AddPanel(IPanelView panel);

        public void RemovePanel(IPanelView panel);
    }
}