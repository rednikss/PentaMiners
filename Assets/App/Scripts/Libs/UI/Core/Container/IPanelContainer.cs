using App.Scripts.Libs.UI.Core.Panel.View;

namespace App.Scripts.Libs.UI.Core.Container
{
    public interface IPanelContainer
    {
        public T GetPanel<T>() where T : PanelView;

        public bool HasPanel<T>() where T : PanelView;

        public void AddPanel(PanelView panel);

        public void RemovePanel(PanelView panel);
    }
}