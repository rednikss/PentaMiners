using Cysharp.Threading.Tasks;

namespace App.Scripts.Libs.UI.Core.Panel.View
{
    public interface IPanelView
    {
        public UniTask ShowAnimated();

        public UniTask HideAnimated();

        public void Show();

        public void Hide();
    }
}