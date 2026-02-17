using App.Scripts.Libs.UI.Core.Panel.View;

namespace App.Scripts.Libs.UI.Builder.Config
{
    public interface IPanelProvider
    {
        public PanelConfig GetPanelConfig<T>() where T : PanelView;
    }
}