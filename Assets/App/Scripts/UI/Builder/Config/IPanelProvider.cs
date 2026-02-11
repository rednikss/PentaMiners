using App.Scripts.Libs.UI.Core.Panel.View;

namespace App.Scripts.UI.Builder.Config
{
    public interface IPanelProvider
    {
        public T GetPanelView<T>() where T : PanelView;
    }
}